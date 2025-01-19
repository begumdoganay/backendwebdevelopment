using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Application.Features.Authors.Commands.DeleteAuthor
{
    public record DeleteAuthorCommand(int Id) : IRequest;

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
   
        public Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
