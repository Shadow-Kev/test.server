using test.server.Application.Ize.TypeChambres;

namespace test.server.Host.Controllers.Ize;

public class TypeChambresController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TypeChambres)]
    [OpenApiOperation("Create a new TypeChambre", "")]
    public Task<Guid> CreateAsync(CreateTypeChambreRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost("search")]
    [MustHavePermission(FSHAction.View, FSHResource.TypeChambres)]
    [OpenApiOperation("Search typeChambres using available filter", "")]
    public Task<PaginationResponse<TypeChambreDto>> SearchAsync(TypeChambresBySearchRequest request)
    {
        return Mediator.Send(request);
    }
}
