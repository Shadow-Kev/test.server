using test.server.Domain.IZE;

namespace test.server.Application.Ize.TypeChambres;
public class TypeChambreByLibelleSpec : Specification<TypeChambre>, ISingleResultSpecification
{
    public TypeChambreByLibelleSpec(string libelle) =>
        Query.Where(tc => tc.Libelle == libelle);
}
