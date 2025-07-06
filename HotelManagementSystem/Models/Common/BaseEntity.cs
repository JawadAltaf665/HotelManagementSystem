namespace HotelManagementSystem.Models.Common
{
    public abstract class BaseEntity
    {
        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

}
