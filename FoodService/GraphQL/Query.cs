using HotChocolate.AspNetCore.Authorization;
using Models;

namespace FoodService.GraphQL
{
    public class Query
    {
        [Authorize(Roles = new[] { "MANAGER", "BUYER" })]
        public IQueryable<Food> ViewFoods([Service] foodieappContext context) =>
            context.Foods;
    }
}
