using System;
using DTO;
using DataAccess;
using BusinessObjects;
namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO? instance = null;
        private static readonly object instanceLock = new object();
        public OrderDAO() { }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        //-----------------------------------------------
        public List<OrderDTO> GetOrder()
        {
            var list = new List<Order>();
            var listDTO = new List<OrderDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Orders.ToList();
                    foreach (var item in list)
                    {
                        listDTO.Add(new OrderDTO
                        {
                            OrderId = item.OrderId,
                            UserId = item.UserId,
                            OrderDate = item.OrderDate,
                            Status = item.Status
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
        public OrderDTO FindOrderById(int id)
        {
            Order order = new Order();
            OrderDTO orderDTO = new OrderDTO();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    order = context.Orders.SingleOrDefault(x => x.OrderId == id);
                    orderDTO.OrderId = order.OrderId;
                    orderDTO.UserId = order.UserId;
                    orderDTO.OrderDate = order.OrderDate;
                    orderDTO.Status = order.Status;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDTO;
        }
        //----------------------------------------------
        public List<OrderDTO> GetOrderByUserId(int id)
        {
            var list = new List<Order>();
            var listDTO = new List<OrderDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Orders.Where(x => x.UserId == id).ToList();
                    foreach (var item in list)
                    {
                        listDTO.Add(new OrderDTO
                        {
                            OrderId = item.OrderId,
                            UserId = item.UserId,
                            OrderDate = item.OrderDate,
                            Status = item.Status
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
        public void SaveOrder(OrderDTO order)
        {
            Order orderTemp = new Order();
            orderTemp.UserId = order.UserId;
            orderTemp.OrderDate = order.OrderDate;
            orderTemp.Status = order.Status;
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Orders.Add(orderTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
        public void UpdateOrder(OrderDTO order)
        {
            Order orderTemp = new Order();
            orderTemp.OrderId = order.OrderId;
            orderTemp.UserId = order.UserId;
            orderTemp.OrderDate = order.OrderDate;
            orderTemp.Status = order.Status;
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Entry<Order>(orderTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.Orders.Update(orderTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
        public void DeleteOrderById(int id)
        {
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    var order = context.Orders.SingleOrDefault(c => c.OrderId == id);
                    context.Orders.Remove(order);
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

