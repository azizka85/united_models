using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitedModels.Models;

namespace UnitedModels.Http.Service.Controllers
{
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly Dictionary<long, Person> _data;

        private readonly Person _defaultPerson;

        public PersonController()
        {
            _data = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Person #1",
                    Timestamp = new DateTime(2023, 4,30, 12, 9, 0, DateTimeKind.Utc),
                    Address = new Address{
                        Id = 1,
                        Data = "Almaty, Kazakhstan",
                        LineIndex = 23
                    }
                },
                new Person
                {
                    Id = 2,
                    Name = "Person #2",
                    Timestamp = new DateTime(2023, 4,30, 12, 12, 0, DateTimeKind.Utc),
                    Address = new Address{
                        Id = 2,
                        Data = "Astana, Kazakhstan",
                        LineIndex = 13
                    }
                },
                new Person
                {
                    Id = 3,
                    Name = "Person #3",
                    Timestamp = new DateTime(2023, 4,30, 12, 13, 0, DateTimeKind.Utc),
                    Address = new Address{
                        Id = 3,
                        Data = "Shymkent, Kazakhstan",
                        LineIndex = 3
                    }
                }
            }.ToDictionary(item => item.Id);

            _defaultPerson = new Person
            {
                Id = 4,
                Name = "Person #4"
            };
        }
        
        [HttpGet("{id}")]
        public Task<IActionResult> Get(long id, CancellationToken _)
        {
            return Task.FromResult<IActionResult>(Ok(
                Get(id)));
        }

        [HttpGet("list")]
        public Task<IActionResult> List(CancellationToken _)
        {
            return Task.FromResult<IActionResult>(Ok(
                List()));
        }

        private Person Get(long id)
        {
            return _data.TryGetValue(id, out var value)
                ? value
                : _defaultPerson;
        }

        private List<Person> List()
        {
            var list = new List<Person>();

            for (int i = 0; i < 1000; i++)
            {
                list.Add(
                    Get(i % 4 + 1));
            }
            
            return list;
        }
    }
}