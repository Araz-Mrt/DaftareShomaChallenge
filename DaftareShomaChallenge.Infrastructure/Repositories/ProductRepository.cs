﻿using DaftareShomaChallenge.Domain.Entities;
using DaftareShomaChallenge.Domain.Repositories;
using DaftareShomaChallenge.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DaftareShomaChallenge.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Result<List<Product>>> GetProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return Result.Success(products);
    }
}