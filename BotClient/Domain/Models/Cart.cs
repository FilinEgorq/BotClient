namespace Domain.Models
{
    public partial class Cart
    {
        public int UserId { get; set; }
        public int GoodId { get; set; }
        public int Count { get; set; }

        public virtual Good Good { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}