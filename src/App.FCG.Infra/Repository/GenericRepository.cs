using Microsoft.EntityFrameworkCore;
using App.FCG.Core.Entities.Base;
using App.FCG.Core.Interfaces;

namespace App.FCG.Infra.Repository;

public abstract class GenericRepository<T> : IRepository<T> where T : EntityBase
{
    public ApplicationDbContext _context;
    protected DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

    public async Task<T?> GetById(Guid id) => await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);

    public void Insert(T entity) => _dbSet.Add(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public async void Delete(Guid id)
    {
        // implementar unit of work
        var entity = await GetById(id);

        if (entity is not null)
        {
            _dbSet.Remove(entity);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
