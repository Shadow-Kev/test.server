﻿
using test.server.Domain.IZE;

namespace test.server.Application.Ize.TypeChambres;
public class TypeChambresBySearchRequest : PaginationFilter, IRequest<PaginationResponse<TypeChambreDto>>
{
}

public class TypeChambresBySearchRequestHandler : IRequestHandler<TypeChambresBySearchRequest, PaginationResponse<TypeChambreDto>>
{
    private readonly IReadRepository<TypeChambre> _repository;
    public TypeChambresBySearchRequestHandler(IReadRepository<TypeChambre> repository)
    {
        _repository = repository;
    }

    public async Task<PaginationResponse<TypeChambreDto>> Handle(TypeChambresBySearchRequest request, CancellationToken cancellationToken)
    {
        var spec = new TypeChambresBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
