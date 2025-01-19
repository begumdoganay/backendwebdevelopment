using BookStore_Web_Application.Core.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Application.Features.Authors.Commands.UpdateAuthor
{
    public record UpdateAuthorCommand : IRequest<AuthorDto>
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Biography { get; init; }
    }
}
