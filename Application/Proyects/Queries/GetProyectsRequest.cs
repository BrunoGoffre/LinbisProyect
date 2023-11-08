using Application.Common.Base;
using MediatR;

namespace Application.Developers.Queries
{
    public class GetProyectsRequest : PagerBase, IRequest<GetProyectsRequest>
    {
    }
}
