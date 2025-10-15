using FCG.Clients.Models;
using FCG.Core.Data;

namespace FCG.Clients.Data.Repository
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client?> GetByCpf(string cpf);
    }
}
