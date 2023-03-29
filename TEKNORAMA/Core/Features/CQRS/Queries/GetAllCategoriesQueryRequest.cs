using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetAllCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
