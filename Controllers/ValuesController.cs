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
    public class ValuesController : ControllerBase
    {
        private string ConnectionString { get; set; }
        public ValuesController(IOptions<InternalOptions> options)
        {
            ConnectionString = options.Value.ConnectionString;
        }
        // GET api/values
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

        // GET api/values/GetMeetings
        [HttpGet]
        [Route("/api/values/GetMeetings")]
        public IEnumerable<Person> GetMeetings()
        {
            var query = "SELECT * FROM Meeting";

            using (var db = new MySqlConnection(ConnectionString))
            {
                var meetings = db.Query<Person>(query);
                return meetings;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
