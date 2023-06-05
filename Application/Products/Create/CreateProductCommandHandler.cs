using Domain.Products;
using Domain.Repositories;
using MediatR;

namespace Application.Products.Create
{
    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _producttRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(
            IProductRepository producttRepository,
            IUnitOfWork unitOfWork)
        {
            _producttRepository = producttRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                new ProductId(Guid.NewGuid()),
                request.Name,
                new Money(request.Currency, request.Amount),
                Sku.Create(request.Sku));
            
            // TODO: FluentValidaton

            _producttRepository.Add(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
