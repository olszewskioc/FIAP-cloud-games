using FCG.Core.Data;
using FluentValidation.Results;

namespace FCG.Core.Services
{
    public abstract class GenericService : IGenericService
    {
        protected ValidationResult ValidationResult;

        protected GenericService() 
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string msg)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, msg));
        }

        public async Task<ValidationResult> Commit(IUnitOfWork uow)
        {
            if (!await uow.Commit())
                AddError("Houve um erro ao persistir os dados.");
            return ValidationResult;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
