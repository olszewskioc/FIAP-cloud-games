using FCG.Core.Data;
using FluentValidation.Results;

namespace FCG.Core.Services
{
    public interface IGenericService : IDisposable
    {
        Task<ValidationResult> Commit(IUnitOfWork uow);
    }
}
