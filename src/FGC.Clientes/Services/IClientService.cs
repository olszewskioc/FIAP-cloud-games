using FluentValidation.Results;
using FCG.Shared.Dtos;

namespace FCG.Clients.Services
{
    public interface IClientService : IDisposable
    {
        Task<ValidationResult> Insert(ClienteRegistro cliente);
    }
}
