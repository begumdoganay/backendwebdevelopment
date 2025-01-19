﻿using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Interfaces.Repositories; // IAuthorRepository için
using MediatR;

namespace BookStore_Web_Application.Application.Features.Authors.Commands.CreateAuthor // namespace'i düzelttik
{
    public record CreateAuthorCommand : IRequest<AuthorDto>
    {
        public string? Name { get; init; }
        public string? Biography { get; init; }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                Biography = request.Biography
            };

            await _authorRepository.AddAsync(author);
            return _mapper.Map<AuthorDto>(author);
        }
    }
}