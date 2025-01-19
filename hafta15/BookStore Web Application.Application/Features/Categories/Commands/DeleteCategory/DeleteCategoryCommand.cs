using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Exceptions;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using MediatR;


namespace BookStore_Web_Application.Application.Features.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(int Id) : IRequest;

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookRepository _bookRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IBookRepository bookRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            // Kategori altında kitap var mı kontrol et
            var hasBooks = await _bookRepository.GetBooksByCategoryAsync(request.Id);
            if (hasBooks.Any())
                throw new BusinessException("Bu kategoriye ait kitaplar bulunduğu için kategori silinemez.");

            await _categoryRepository.DeleteAsync(category);
        }
    }
}
