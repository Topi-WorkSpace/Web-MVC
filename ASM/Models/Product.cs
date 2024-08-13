using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? ProductName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Places { get; set; }
        [Required]
        public double Price { get; set; }
        public string TittleProduct {  get; set; }
        public string? Image {  get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<CartDetail> CartDetails { get; set; }
        
        // Không hiển thị categoryname trong bảng product, chỉ dành để biến chuỗi categoryId thành 
        [NotMapped]
        public string CategoryName { get; set; }
    }
}
