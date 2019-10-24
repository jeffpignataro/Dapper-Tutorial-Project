using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.AspNetCore.Cors;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Net;

namespace Dapper_Tutorial_Project.Controllers
{
    // [EnableCors(Startup.AllowLocalhost)]
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
        public ActionResult Post([FromBody] Person value)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return Ok(db.Insert<Person>(value));
            }
            
        }

        // PUT api/Person/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Person value)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return Ok(db.Update<Person>(value));
            }
        }

        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                var person = Get(id);
                return Ok(db.Delete<Person>(person));
            }            
        }
    }
}