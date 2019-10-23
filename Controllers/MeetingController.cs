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
    public class MeetingController : ControllerBase
    {
        private string ConnectionString { get; set; }
        public MeetingController(IOptions<InternalOptions> options)
        {
            ConnectionString = options.Value.ConnectionString;
        }
        // GET api/Meeting
        [HttpGet]
        public IEnumerable<Meeting> Get()
        {
            var MeetingQuery = "SELECT * FROM Meeting";

            using (var db = new MySqlConnection(ConnectionString))
            {
                var meetings = db.Query<Meeting>(MeetingQuery);
                return meetings;
            }
        }
        // GET api/Meeting/5
        [HttpGet("{id}")]
        public Meeting Get(int id)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                var meeting = db.Get<Meeting>(id); // Using SimpleCRUD Extensions
                return meeting;
            }
        }

        // POST api/Meeting
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Meeting/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Meeting/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}