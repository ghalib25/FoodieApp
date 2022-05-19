using FoodService.GraphQL;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);
var conString = builder.Configuration.GetConnectionString("MyDatabase");
builder.Services.AddDbContext<foodieappContext>(options =>
     options.UseSqlServer(conString)
);

// graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddAuthorization();

builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL("/");
app.MapGet("/hello", () => "Hello World!");

app.Run();
