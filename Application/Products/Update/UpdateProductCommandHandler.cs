﻿using Domain.Products;
using Domain.Repositories;
using MediatR;

namespace Application.Products.Update;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if(product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        product.UpdateProduct(
            request.Name,
            new Money(request.Currency, request.Amount),
            Sku.Create(request.Sku));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
