using test.server.Domain.IZE;

namespace test.server.Application.Ize.TypeChambres;
public class CreateTypeChambreRequestValidator : CustomValidator<CreateTypeChambreRequest>
{
    public CreateTypeChambreRequestValidator(IReadRepository<TypeChambre> typeChambreRepo, IStringLocalizer<CreateTypeChambreRequestValidator> T)
    {
        RuleFor(tc => tc.Code)
            .NotEmpty()
            .MaximumLength(10)
            .WithMessage(T["Code est obligatoire"]);

        RuleFor(tc => tc.Libelle)
            .NotEmpty()
            .MaximumLength(30)
            .MustAsync(async (libelle, ct) => await typeChambreRepo.FirstOrDefaultAsync(new TypeChambreByLibelleSpec(libelle), ct) is null)
            .WithMessage((_, libelle) => T["Type chambre {0} existe déjà", libelle]);
    }
}
