using FCG.Core.Entities.Base;

namespace FCG.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<T>> GetAll ();
        Task<T?> GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
