using Application.Products;
using Application.Products.Delete;
using Application.Products.Get;
using Application.Products.Update;
using Carter;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.EndPoints;

public class Product : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("products", async (CreateProductCommand command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.Ok();
        });

        app.MapGet("products/{id:guid}", async (Guid Id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetProductQuery(new ProductId(Id))));
            }
            catch (ProductNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        app.MapPut("products/{id:guid}", async (Guid id, [FromBody] UpdateProductRequest request, ISender sender) =>
        {
            var command = new UpdateProductCommand(
                new ProductId(id),
                request.Name,
                request.Sku,
                request.Currency,
                request.Amount);

            await sender.Send(command);

            return Results.NoContent();
        });

        app.MapDelete("products/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteProductCommand(new ProductId(id)));
                return Results.NoContent();
            }
            catch (ProductNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });
    }
}
