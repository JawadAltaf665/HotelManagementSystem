using HotelManagementSystem.Dtos;
using HotelManagementSystem.IAppService;
using HotelManagementSystem.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.AppService
{
    public class MenuAppService : IMenuAppService
    {
        private readonly HMSDbContext _context;

        public MenuAppService(HMSDbContext context)
        {
            _context = context;
        }
        public async Task<Response> GetAllMenusAsync()
        {
            Response response = new Response();
            try
            {
                var menuList = await _context.MenuItems.ToListAsync();
                if (menuList != null)
                {
                    response.StatusCode = 200;
                    response.ResponseMessage = "Menus retrieved successfully.";
                    response.ResultData = menuList;
                }
                else
                {
                    response.StatusCode = 404;
                    response.ResponseMessage = "No menus found.";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while retrieving menus.";
            }
            return response;
        }

        public async Task<Response> GetMenuByIdAsync(int id)
        {
            Response response = new Response();
            try
            {
                var menuItem = await _context.MenuItems.FindAsync(id);
                if (menuItem != null)
                {
                    response.StatusCode = 200;
                    response.ResponseMessage = "Menu item retrieved successfully.";
                    response.ResultData = menuItem;
                }
                else
                {
                    response.StatusCode = 404;
                    response.ResponseMessage = "Menu item not found.";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while retrieving menus.";
            }
            return response;
        }

        //Image upload logic 
        public async Task<Response> UploadImageAsync(IFormFile file)
        {
            Response response = new Response();

            if (file == null || file.Length == 0)
            {
                response.StatusCode = 400;
                response.ResponseMessage = "No file uploaded.";
                return response;
            }

            try
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "MenuImages");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Just return the relative path (you can prepend host on frontend)
                var imageUrl = $"/Uploads/MenuImages/{fileName}";

                response.StatusCode = 200;
                response.ResponseMessage = "Image uploaded successfully.";
                response.ResultData = imageUrl; // If your Response class has Data field
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while uploading the image.";
            }

            return response;
        }

        public async Task<Response> CreateMenuAsync(MenuItemDTO input)
        {
            Response response = new Response();
            try
            {
                var menuItem = new MenuItem
                {
                    MenuItemName = input.Name,
                    Description = input.Description,
                    Category = input.Category,
                    Price = input.Price,
                    ImageUrl = input.ImageUrl,
                    CreatedBy = "System", // Assuming system user for now
                    CreatedDate = DateTime.UtcNow
                };

                _context.MenuItems.Add(menuItem);
                await _context.SaveChangesAsync();
                response.StatusCode = 201;
                response.ResponseMessage = "Menu item created successfully.";
                response.ResultData = menuItem; // Return the created menu item
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while retrieving menus.";
            }
            return response;
        }

        public async Task<Response> UpdateMenuAsync(MenuItemDTO input)
        {
            Response response = new Response();
            try
            {
                if (input == null)
                {
                    response.StatusCode = 400;
                    response.ResponseMessage = "Invalid menu item ID.";
                    return response;
                }
                var menuItem = await _context.MenuItems.FindAsync(input.Id);

                if (menuItem == null)
                {
                    response.StatusCode = 404;
                    response.ResponseMessage = "Menu item not found.";
                    return response;
                }
                menuItem.MenuItemName = input.Name;
                menuItem.Description = input.Description;
                menuItem.Category = input.Category;
                menuItem.Price = input.Price;
                menuItem.ImageUrl = input.ImageUrl ?? menuItem.ImageUrl;
                menuItem.CreatedBy = "System";
                menuItem.UpdatedBy = "System";
                menuItem.UpdatedDate = DateTime.UtcNow;

                _context.MenuItems.Update(menuItem);
                await _context.SaveChangesAsync();
                response.StatusCode = 200;
                response.ResponseMessage = "Menu item updated successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while retrieving menus.";
            }
            return response;
        }

        public async Task<Response> DeleteMenuAsync(int id)
        {
            Response response = new Response();
            try
            {
                var menuItem = await _context.MenuItems.FindAsync(id);
                if (menuItem == null)
                {
                    response.StatusCode = 404;
                    response.ResponseMessage = "Menu item not found.";
                    return response;
                }
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
                response.StatusCode = 200;
                response.ResponseMessage = "Menu item deleted successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while retrieving menus.";
            }
            return response;
        }
    }
}
