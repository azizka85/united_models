using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using UnitedModels.Models;

namespace UnitedModels.Http
{
    public class PersonService : IPersonService
    {
        private readonly string _serviceUri;
        
        public PersonService(string serviceUri)
        {
            _serviceUri = serviceUri ?? throw new ArgumentNullException(nameof(serviceUri));
        }
        
        public Task<Person> GetAsync(long id, CancellationToken cancellationToken)
        {
            return _serviceUri
                .AppendPathSegment("person")
                .AppendPathSegment(id)
                .GetJsonAsync<Person>(cancellationToken);
        }

        public Task<List<Person>> ListAsync(CancellationToken cancellationToken)
        {
            return _serviceUri
                .AppendPathSegment("person")
                .AppendPathSegment("list")
                .GetJsonAsync<List<Person>>(cancellationToken);
        }
    }
}