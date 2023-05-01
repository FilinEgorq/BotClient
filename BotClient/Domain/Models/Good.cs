namespace Domain.Models
{
    public partial class Good
    {
        public Good()
        {
            Carts = new HashSet<Cart>();
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public byte[]? Preview { get; set; }
        public DateTime? IsDeleted { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}