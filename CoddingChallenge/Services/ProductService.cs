using CoddingChallenge.DataBase;
using CoddingChallenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoddingChallenge.Services
{
    public class ProductService : IProductService
    {
        private readonly ChallengeContext _context;
       public ProductService()
        {
            _context = new ChallengeContext();
        }
        public List<Product> GetAllProducts()
        {
            try
            {
                return _context.products.ToList(); 
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddProduct(Product product)
        {
            try
            {
                _context.products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                Product product = _context.products.SingleOrDefault(p => p.ProductId == productId);
                _context.products.Remove(product);
                _context.SaveChanges();
            }

           
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProductById(int productId)
        {
            Product product = _context.products.SingleOrDefault(p => p.ProductId == productId);
            return product;
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _context.products.Update(product);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        
    }
}
