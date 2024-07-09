﻿using DaftareShomaChallenge.Application.Contracts.DTOs.Products;

namespace DaftareShomaChallenge.Application.Contracts.Interfaces;

public interface IProductService
{
    Task<Result<List<ProductDto>>> GetProductsAsync();
}