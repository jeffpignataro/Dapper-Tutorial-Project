using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Dapper;

namespace Dapper_Tutorial_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private string ConnectionString { get; set; }
        public PersonController(IOptions<InternalOptions> options)
        {
            ConnectionString = options.Value.ConnectionString;
        }
        // GET api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var PersonQuery = "SELECT * FROM Person";

            using (var db = new MySqlConnection(ConnectionString))
            {
                var people = db.Query<Person>(PersonQuery);
                return people;
            }
        }
        // GET api/Person/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                var person = db.Get<Person>(id); // Using SimpleCRUD Extensions
                return person;
            }
        }

        // POST api/Person
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}