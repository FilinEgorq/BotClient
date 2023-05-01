namespace Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Filters = new HashSet<Filter>();
            InverseParent = new HashSet<Category>();
            Goods = new HashSet<Good>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? IsDeleted { get; set; }

        public virtual Category? Parent { get; set; }
        public virtual ICollection<Filter> Filters { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}