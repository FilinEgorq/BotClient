namespace Domain.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal FullCost { get; set; }
        public string DeliveryMethod { get; set; } = null!;
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? IsDeleted { get; set; }

        public virtual User User { get; set; } = null!;
    }
}