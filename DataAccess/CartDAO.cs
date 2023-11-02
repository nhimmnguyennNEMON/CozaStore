using System;
using DTO;
using BusinessObjects;
namespace DataAccess
{
	public class CartDAO
	{
		private static CartDAO instance = null;
        private static readonly object instanceLock = new object();
		public CartDAO() {}

		public static CartDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CartDAO();
                    }
                    return instance;
                }
            }
        }
		//-----------------------------------------------
        public List<CartDTO> GetCart()
        {
            var list = new List<Cart>();
            var listDTO = new List<CartDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Carts.ToList();
                    foreach (var item in list)
                    {
                        listDTO.Add(new CartDTO{
							CartdId = item.CartdId,
							ProductId = item.ProductId,
							UserId = item.UserId
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
        //-----------------------------------------------
        public CartDTO FindCartById(int id)
        {
            Cart cart = new Cart();
            CartDTO cartDTO = new CartDTO();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    cart = context.Carts.SingleOrDefault(x => x.CartdId == id);
                    cartDTO.CartdId = cart.CartdId;
                    cartDTO.ProductId = cart.ProductId;
                    cartDTO.UserId = cart.UserId;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cartDTO;
        }
		//----------------------------------------------
        public List<CartDTO> GetCartByUserId(int id)
        {
            var list = new List<Cart>();
            var listDTO = new List<CartDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
					list = context.Carts.Where(x => x.UserId == id).ToList();
                    foreach (var item in list)
                    {
                        listDTO.Add(new CartDTO{
							CartdId = item.CartdId,
							ProductId = item.ProductId,
							UserId = item.UserId
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
        public void SaveCart(CartDTO cart)
        {
            Cart cartTemp = new Cart();
			//cartTemp.CartdId = cart.CartdId;
			cartTemp.ProductId = cart.ProductId;
			cartTemp.UserId = cart.UserId;
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Carts.Add(cartTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
        public void UpdateCart(CartDTO cart)
        {
            Cart cartTemp = new Cart();
			cartTemp.CartdId = cart.CartdId;
			cartTemp.ProductId = cart.ProductId;
			cartTemp.UserId = cart.UserId;
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Entry<Cart>(cartTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.Carts.Update(cartTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
		public void DeleteCartById(int id)
        {
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    var cart = context.Carts.SingleOrDefault(c => c.CartdId == id);
                    context.Carts.Remove(cart);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
	}
}

