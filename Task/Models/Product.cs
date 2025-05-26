using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool ISActive { get; set; }
        public bool IsDeleted { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
