namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long? PhoneNumber { get; set; }
        public decimal Balance { get; set; }
        public string Role { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? IsDeleteted { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}