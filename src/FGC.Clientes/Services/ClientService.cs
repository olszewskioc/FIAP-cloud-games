using FCG.Clients.Data.Repository;
using FluentValidation.Results;
using FCG.Clients.Models;
using FCG.Core.Services;
using FCG.Shared.Dtos;

namespace FCG.Clients.Services
{
    public class ClientService : GenericService, IClientService
    {
        private readonly IClientRepository _clienteRepository;

        public ClientService(IClientRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Insert(ClienteRegistro cliente)
        {
            var user = new Client(cliente.Id, cliente.Nome, cliente.Email, cliente.Cpf);

            if (!user.ValidationResult.IsValid) return user.ValidationResult;

            var existentClient = await _clienteRepository.GetByCpf(cliente.Cpf);

            if (existentClient is not null)
            {
                return new ValidationResult(new List<ValidationFailure>
                {
                    new ValidationFailure("Cliente", "Já existe um cliente com este CPF")
                });
            }

            _clienteRepository.Insert(user);

            return await Commit(_clienteRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
