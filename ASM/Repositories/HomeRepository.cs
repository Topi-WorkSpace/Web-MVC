
using Microsoft.EntityFrameworkCore;

namespace ASM.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        // tao contructer
        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }

        //sTerm là chuỗi tìm kiếm
        public async Task<IEnumerable<Product>> GetProducts(string sTerm ="", int categoryId = 0)
        {
            // trả về 1 ds product 
            sTerm = sTerm.ToLower(); // chuyển đổi cụm tìm kiếm
            IEnumerable<Product> products = await (from product in _db.Products
                            join category in _db.Categories
                            on product.CategoryId equals category.Id
                            where string.IsNullOrWhiteSpace(sTerm) || (product!=null && product.ProductName.ToLower().StartsWith(sTerm))

                            select new Product
                            {
                                Id = product.Id,
                                Image = product.Image,
                                Places = product.Places,
                                ProductName = product.ProductName,
                                CategoryId = product.CategoryId,
                                Price = product.Price,
                                CategoryName = category.CategoryName
                            }
                            ).ToListAsync();
            if (categoryId >0)
            {
                products = products.Where(a => a.CategoryId == categoryId).ToList();
            }
            return products;
        }
    }
}
