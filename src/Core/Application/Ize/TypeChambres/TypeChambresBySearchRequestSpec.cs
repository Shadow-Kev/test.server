using test.server.Domain.IZE;

namespace test.server.Application.Ize.TypeChambres;
public class TypeChambresBySearchRequestSpec : EntitiesByPaginationFilterSpec<TypeChambre, TypeChambreDto>
{
    public TypeChambresBySearchRequestSpec(TypeChambresBySearchRequest request)
        : base(request)
        => Query.OrderBy(tc => tc.Libelle, !request.HasOrderBy());
}
