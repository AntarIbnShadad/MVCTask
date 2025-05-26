namespace Task.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Product> Products { get; set; }
        
    }
}
