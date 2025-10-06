using App.FCG.Core.Entities.Base;

namespace App.FCG.Core.Interfaces;

public interface IRepository<T> : IDisposable where T : EntityBase
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T?> GetById(Guid id);
    public void Update(T entity);
    public void Delete(Guid id);
    public void Insert(T entity);
}
