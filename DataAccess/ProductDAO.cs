using System;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	public class ProductDAO
	{
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Product> GetProducts()
        {
            var list = new List<Product>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Products.ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        //----------------------------------------------
        public Product FindProductById(int pid)
        {
            Product product = new Product();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    product = context.Products.SingleOrDefault(x => x.ProductId == pid);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return product;
        }
        //---------------------------------------------
        public void SaveProduct(Product product)
        {
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
        public void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    //context.Products.Update(product);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //-----------------------------------------------
        public void DeleteProduct(Product product)
        {
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    var product1 = context.Products.SingleOrDefault(c => c.ProductId == product.ProductId);
                    context.Products.Remove(product1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteProductById(int productId)
        {
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    var product1 = context.Products.SingleOrDefault(c => c.ProductId == productId);
                    context.Products.Remove(product1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Product> GetListProductsByCateId(int cateId)
        {
            var list = new List<Product>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Products.Where(p => p.CategoryId == cateId).ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public List<Product> GetListProductsByProductName(string productName)
        {
            var list = new List<Product>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Products.Where(x => x.ProductName.Contains(productName)).ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public List<Product> GetProductByPriceRange(decimal startPrice, decimal endPrice)
        {
            var list = new List<Product>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Products.Where(x => x.Price >= startPrice && x.Price <= endPrice).ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        //----------------------------------------------
    }
}

