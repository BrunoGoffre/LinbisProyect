using Application.Common.Base;
using MediatR;

namespace Application.Developers.Queries
{
    public class GetDevelopersRequest : PagerBase, IRequest<GetDevelopersRequest>
    {
        public string Id { get; set; }
    }
}
