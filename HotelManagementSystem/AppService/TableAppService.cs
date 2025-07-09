using HotelManagementSystem.Dtos;
using HotelManagementSystem.IAppService;
using HotelManagementSystem.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.AppService
{
    public class TableAppService: ITableAppService
    {
        private readonly HMSDbContext _context;
        public TableAppService(HMSDbContext context)
        {
            _context = context;
        }

        public async Task<Response> GetAllTablesAsync()
        {
            Response response = new Response();
            try
            {
                var tables = await _context.Tables
                    .Include(t => t.Orders) // Include related Orders
                    .ToListAsync();
                response.StatusCode = 200;
                response.ResponseMessage = "Tables retrieved successfully.";
                response.ResultData = tables;
            }
            catch(Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while retrieving tables.";
            }
            return response;
        }


        public async Task<Response> GetTableByIdAsync(int id)
        {
            Response response = new Response();
            try
            {
                var table = await _context.Tables
                    .Include(t => t.Orders)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (table != null)
                {
                    response.StatusCode = 200;
                    response.ResponseMessage = "Table retrieved successfully.";
                    response.ResultData = table;
                }
                else
                {
                    response.StatusCode = 404;
                    response.ResponseMessage = "Table not found.";
                }  
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while retrieving the table.";
            }
            return response;
        }
        public async Task<Response> CreateTableAsync(TableDTO input)
        {
            Response response = new Response();
            try
            {
                var table = new Table
                {
                    TableNumber = input.TableNumber,
                    QRCodeUrl = input.QRCodeUrl,
                    CreatedBy = "Jawad",
                };

                _context.Tables.Add(table);
                await _context.SaveChangesAsync();
                response.StatusCode = 201;
                response.ResponseMessage = "Table created successfully.";
                response.ResultData = input;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while creating the table.";
            }
            return response;
        }
        public async Task<Response> UpdateTableAsync(int id, TableDTO input)
        {
            Response response = new Response();
            try
            {
                var updatedTable = new Table
                {
                    Id = id,
                    TableNumber = input.TableNumber,
                    QRCodeUrl = input.QRCodeUrl,
                    CreatedBy = "Jawad", // Assuming CreatedBy is set to the same user
                    UpdatedBy = "Jawad",
                    UpdatedDate = DateTime.UtcNow
                };

                if (input.Id == 0 || string.IsNullOrWhiteSpace(updatedTable.TableNumber))
                {
                    response.StatusCode = 400;
                    response.ResponseMessage = "Invalid input.";
                    return response;
                }

                _context.Tables.Update(updatedTable);
                await _context.SaveChangesAsync();
                response.StatusCode = 200;
                response.ResponseMessage = "Table updated successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred: " + ex.Message;
            }

            return response;
        }

        public async Task<Response> DeleteTableAsync(int id)
        {
            Response response = new Response();
            try
            {
                var table = await _context.Tables.FindAsync(id);
                if (table == null)
                {
                    response.StatusCode = 404;
                    response.ResponseMessage = "Table not found.";
                    return response;
                }
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
                response.StatusCode = 200;
                response.ResponseMessage = "Table deleted successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while deleting the table.";
            }
            return response;
        }
    }
}
