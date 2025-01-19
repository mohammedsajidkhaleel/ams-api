﻿using ams.domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ams.infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext _dbContext;
        protected Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .Set<T>()
                .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }
        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
        }
    }
}
