namespace Domain.Models
{
    public partial class GoodCharachteristic
    {
        public int GoodId { get; set; }
        public int FilterId { get; set; }
        public object? Value { get; set; }

        public virtual Filter FilterIdNavigation { get; set; } = null!;
        public virtual Good Good { get; set; } = null!;
    }
}