using System;
using DTO;
using BusinessObjects;
namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        public OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        //-----------------------------------------------
        public List<OrderDetailDTO> GetOrderDetail()
        {
            var list = new List<OrderDetail>();
            var listDTO = new List<OrderDetailDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.OrderDetails.ToList();
                    foreach (var item in list)
                    {
                        listDTO.Add(new OrderDetailDTO
                        {
                            OrderDetailId = item.OrderDetailId,
                            OrderId = item.OrderId,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Description = item.Description,
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
        public OrderDetailDTO FindOrderDetailById(int id)
        {
            OrderDetail orderDetail = new OrderDetail();
            OrderDetailDTO orderDetailDTO = new OrderDetailDTO();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    orderDetail = context.OrderDetails.SingleOrDefault(x => x.OrderDetailId == id);
                    orderDetailDTO.OrderDetailId = orderDetail.OrderDetailId;
                    orderDetailDTO.OrderId = orderDetail.OrderId;
                    orderDetailDTO.ProductId = orderDetail.ProductId;
                    orderDetailDTO.Quantity = orderDetail.Quantity;
                    orderDetailDTO.Description = orderDetail.Description;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetailDTO;
        }
        //----------------------------------------------
        public List<OrderDetailDTO> GetOrderDetailByOrderId(int id)
        {
            var list = new List<OrderDetail>();
            var listDTO = new List<OrderDetailDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.OrderDetails.Where(x => x.OrderId == id).ToList();
                    foreach (var item in list)
                    {
                        listDTO.Add(new OrderDetailDTO
                        {
                            OrderDetailId = item.OrderDetailId,
                            OrderId = item.OrderId,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Description = item.Description,
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
        public void SaveOrderDetail(OrderDetailDTO orderDetail)
        {
            OrderDetail orderDetailTemp = new OrderDetail();
            orderDetailTemp.OrderId = orderDetail.OrderId;
            orderDetailTemp.ProductId = orderDetail.ProductId;
            orderDetailTemp.Quantity = orderDetail.Quantity;
            orderDetailTemp.Description = orderDetail.Description;
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.OrderDetails.Add(orderDetailTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
        public void UpdateOrderDetail(OrderDetailDTO orderDetail)
        {
            OrderDetail orderDetailTemp = new OrderDetail();
            orderDetailTemp.OrderDetailId = orderDetail.OrderDetailId;
            orderDetailTemp.OrderId = orderDetail.OrderId;
            orderDetailTemp.ProductId = orderDetail.ProductId;
            orderDetailTemp.Quantity = orderDetail.Quantity;
            orderDetailTemp.Description = orderDetail.Description;
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Entry<OrderDetail>(orderDetailTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.OrderDetails.Update(orderDetailTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
        public void DeleteOrderDetailById(int id)
        {
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    var orderDetail = context.OrderDetails.SingleOrDefault(c => c.OrderDetailId == id);
                    context.OrderDetails.Remove(orderDetail);
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

