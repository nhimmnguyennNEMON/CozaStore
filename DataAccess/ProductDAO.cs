using System;
using BusinessObjects;
using DTO;
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

        public List<ProductDTO> GetProducts()
        {
            var list = new List<Product>();
            var listDTO = new List<ProductDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Products.ToList();
                    foreach(var item in list) {
                        listDTO.Add(new ProductDTO{
                            ProductId = item.ProductId,
                            CategoryId = item.CategoryId,
                            ProductName = item.ProductName,
                            Description = item.Description,
                            Price = item.Price,
                            Size = item.Size,
                            Color = item.Color,
                            Quantity = item.Quantity,
                            ImageUrl = item.ImageUrl
                        });
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listDTO;
        }
        //----------------------------------------------
        public ProductDTO FindProductById(int pid)
        {
            Product product = new Product();
            ProductDTO productDTO = new ProductDTO();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    product = context.Products.SingleOrDefault(x => x.ProductId == pid);
                    productDTO.ProductId = product.ProductId;
                    productDTO.CategoryId = product.CategoryId;
                    productDTO.ProductName = product.ProductName;
                    productDTO.Description = product.Description;
                    productDTO.Price = product.Price;
                    productDTO.Size = product.Size;
                    productDTO.Color = product.Color;
                    productDTO.Quantity = product.Quantity;
                    productDTO.ImageUrl = product.ImageUrl;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return productDTO;
        }
        //---------------------------------------------
        public void SaveProduct(ProductDTO product)
        {
            Product productTemp = new Product();
            //productTemp.ProductId = product.ProductId;
            productTemp.CategoryId = product.CategoryId;
            productTemp.ProductName = product.ProductName;
            productTemp.Description = product.Description;
            productTemp.Price = product.Price;
            productTemp.Size = product.Size;
            productTemp.Color = product.Color;
            productTemp.Quantity = product.Quantity;
            productTemp.ImageUrl = product.ImageUrl;

            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Products.Add(productTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
        public void UpdateProduct(ProductDTO product)
        {
            Product productTemp = new Product();
            productTemp.ProductId = product.ProductId;
            productTemp.CategoryId = product.CategoryId;
            productTemp.ProductName = product.ProductName;
            productTemp.Description = product.Description;
            productTemp.Price = product.Price;
            productTemp.Size = product.Size;
            productTemp.Color = product.Color;
            productTemp.Quantity = product.Quantity;
            productTemp.ImageUrl = product.ImageUrl;

            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Entry<Product>(productTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.Products.Update(productTemp);
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

        public List<ProductDTO> GetListProductsByCateId(int cateId)
        {
            var list = new List<Product>();
            var listDTO = new List<ProductDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Products.Where(p => p.CategoryId == cateId).ToList();
                    foreach(var item in list) {
                        listDTO.Add(new ProductDTO{
                            ProductId = item.ProductId,
                            CategoryId = item.CategoryId,
                            ProductName = item.ProductName,
                            Description = item.Description,
                            Price = item.Price,
                            Size = item.Size,
                            Color = item.Color,
                            Quantity = item.Quantity,
                            ImageUrl = item.ImageUrl
                        });
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listDTO;
        }

        public List<ProductDTO> GetListProductsByProductName(string productName)
        {
            var list = new List<Product>();
            var listDTO = new List<ProductDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Products.Where(x => x.ProductName.Contains(productName)).ToList();
                    foreach(var item in list) {
                        listDTO.Add(new ProductDTO{
                            ProductId = item.ProductId,
                            CategoryId = item.CategoryId,
                            ProductName = item.ProductName,
                            Description = item.Description,
                            Price = item.Price,
                            Size = item.Size,
                            Color = item.Color,
                            Quantity = item.Quantity,
                            ImageUrl = item.ImageUrl
                        });
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listDTO;
        }

        public List<ProductDTO> GetProductByPriceRange(decimal startPrice, decimal endPrice)
        {
            var list = new List<Product>();
            var listDTO = new List<ProductDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Products.Where(x => x.Price >= startPrice && x.Price <= endPrice).ToList();
                    foreach(var item in list) {
                        listDTO.Add(new ProductDTO{
                            ProductId = item.ProductId,
                            CategoryId = item.CategoryId,
                            ProductName = item.ProductName,
                            Description = item.Description,
                            Price = item.Price,
                            Size = item.Size,
                            Color = item.Color,
                            Quantity = item.Quantity,
                            ImageUrl = item.ImageUrl
                        });
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listDTO;
        }
        //----------------------------------------------
    }
}

