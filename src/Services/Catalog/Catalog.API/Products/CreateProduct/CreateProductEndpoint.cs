namespace Catalog.API.Products.CreateProduct;

//public record CreateProductRequest
//{
//    public string Name { get; }
//    public List<string> Category { get; }
//    public string Description { get; }
//    public string ImageFile { get; }
//    public decimal Price { get; }
//    public CreateProductRequest(string name, List<string> cate, string description, string imagefile, decimal price) => (Name, Category, Description, ImageFile, Price) = (name, cate, description, imagefile, price);
//}

public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>();

            return Results.Created($"/products/{response.Id}", response);
        })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Creates a new product.")
            .WithDescription("Creates a new product in the catalog.");
    }
}

