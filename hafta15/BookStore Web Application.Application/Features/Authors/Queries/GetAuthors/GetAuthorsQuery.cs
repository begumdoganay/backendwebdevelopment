using BookStore_Web_Application.Core.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Application.Features.Authors.Queries.GetAuthors
{
    public record GetAuthorsQuery : IRequest<IEnumerable<AuthorDto>>;

    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorDto>>
    {
        // ... handler implementation ...
        public Task<IEnumerable<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
