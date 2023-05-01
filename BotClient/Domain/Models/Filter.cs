namespace Domain.Models
{
    public partial class Filter
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public DateTime? IsDeleted { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}