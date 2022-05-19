using HotChocolate.AspNetCore.Authorization;
using Models;
using System.Security.Claims;

namespace OrderService.GraphQL
{
    public class Mutation
    {
        //ORDER
        [Authorize(Roles = new[] { "BUYER" })]
        public async Task<OrderData> AddOrderAsync(
            OrderData input,
            ClaimsPrincipal claimsPrincipal,
            [Service] foodieappContext context)
        {
            using var transaction = context.Database.BeginTransaction();
            var userName = claimsPrincipal.Identity.Name;

            try
            {
                var user = context.Users.Where(o => o.Username == userName).FirstOrDefault();
                var courier = context.Couriers.Where(c => c.Id == input.CourierId ).FirstOrDefault();
                if (user != null)
                {
                    var order = new Order
                    {
                        Code = Guid.NewGuid().ToString(), // generate random chars using GUID
                        UserId = user.Id,
                        CourierId = input.CourierId
                    };

                    foreach (var item in input.Details)
                    {
                        var detail = new OrderDetail
                        {
                            OrderId = order.Id,
                            FoodId = item.FoodId,
                            Quantity = item.Quantity
                        };
                        order.OrderDetails.Add(detail);
                    }
                    context.Orders.Add(order);
                    context.SaveChanges();
                    await transaction.CommitAsync();
                }
                else
                    throw new Exception("user was not found");
            }
            catch (Exception err)
            {
                transaction.Rollback();
            }

            return input;
        }

        [Authorize(Roles = new[] { "MANAGER" })]
        public async Task<Order> UpdateOrderAsync(
           OrderData input,
           [Service] foodieappContext context)
        {
            var order = context.Orders.Where(o => o.Id == input.Id).FirstOrDefault();
            var courier = context.Couriers.Where(c => c.Id == input.CourierId).FirstOrDefault();
            if (order != null)
            {
                order.Code = input.Code;
                order.UserId = (int)input.UserId;
                order.CourierId = input.CourierId;

                context.Orders.Update(order);
                await context.SaveChangesAsync();
            }
            return await Task.FromResult(order);
        }

        [Authorize(Roles = new[] { "MANAGER" })]
        public async Task<Order> DeleteOrderByIdAsync(
            int id,
            [Service] foodieappContext context)
        {
            var order = context.Orders.Where(o => o.Id == id).FirstOrDefault();
            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
            return await Task.FromResult(order);
        }
    }
}
