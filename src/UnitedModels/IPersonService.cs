using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnitedModels.Models;

namespace UnitedModels
{
    public interface IPersonService
    {
        Task<Person> GetAsync(long id, CancellationToken cancellationToken);

        Task<List<Person>> ListAsync(CancellationToken cancellationToken);
    }
}