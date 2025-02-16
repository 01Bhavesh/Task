using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.Model.DTO;
using New_CRUDTask.Server;

namespace New_CRUDTask.ServiceImplementation
{
    public class OrderService : IOrderService
    {
        private readonly DbContextServer _db;
        public OrderService(DbContextServer db)
        {
            _db = db;
        }
        public async Task<bool> CreateOrder(OrderCreatedDTO order)
        {
            User? user = await _db.Users.FirstOrDefaultAsync(u => u.UserId == order.UserId);
            if(user.IsActive != true)
            {
                return false;
            }

            var productorder = new List<ProductOrder>();
            foreach (var orders in order.ProductOrders)
            {
                var product = await _db.Products.FindAsync(orders.ProductId);
                if (product.IsActive != true)
                {
                    return false;
                }
                productorder.Add(new ProductOrder
                { 
                    ProductId = orders.ProductId,
                    Quntity = orders.Quntity
                });
            }
            var newOrder = new Order
            {
                UserId = order.UserId,
                ProductOrders = productorder
            };
            _db.Orders.Add(newOrder);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            Order? order = GetOrderById(id);
            if (order == null)
            {
                return false;
            }
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return true;
        }

        public Order? GetOrderById(int id)
        {
            return _db.Orders
            .Include(o => o.ProductOrders)
            .FirstOrDefault(o => o.OrderId == id);
        }

        public async Task<List<Order>> GetOrders(int page, int pageSize)
        {
            return await _db.Orders
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(o => o.ProductOrders)
            .ToListAsync();
        }

        public async Task<List<OrderDTO>> GetOrdersByUserId(int userId)
        { 
            var orders = await _db.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.ProductOrders)
                .ThenInclude(p => p.Products)
                .ToListAsync();
            var orderDtos = orders.Select(order => new OrderDTO
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                Products = order.ProductOrders.Select(po => new ProductOrderDTO
                {
                    ProductId = po.ProductId,
                    Quntity = po.Quntity
                }).ToList()
            }).ToList();

            return orderDtos;
        
        }

        public async Task<bool> UpdateOrder(OrderCreatedDTO orderDto)
        {
            var previousOrder = await _db.Orders
                .Include(o => o.ProductOrders)
                .FirstOrDefaultAsync(o => o.OrderId == orderDto.OrderId);

            if (previousOrder.UserId != orderDto.UserId)
            {
                return false;
            }
            foreach (var order in orderDto.ProductOrders)
            {
                var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == order.ProductId);
                if (product.IsActive != true)
                {
                    return false;
                }
                var productOrder = previousOrder.ProductOrders.FirstOrDefault(p => p.ProductId == order.ProductId);

                if (productOrder != null)
                {
                    productOrder.Quntity = order.Quntity;
                }
                else
                {
                    previousOrder.ProductOrders.Add(new ProductOrder
                    {
                        OrderId = previousOrder.OrderId,
                        ProductId = order.ProductId,
                        Quntity = order.Quntity
                    });
                }
            }
            _db.Orders.Update(previousOrder);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
