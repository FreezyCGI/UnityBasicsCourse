using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnityBasicsCourseAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HighscoreController : ControllerBase
    {
        private static readonly string connString = "Host=localhost:5432;Username=postgres;Password=admin;Database=UnityBasicsCourse";
        NpgsqlDataSourceBuilder DataSourceBuilder { get; }
        NpgsqlDataSource DataSource { get; }

        public HighscoreController()
        {
            DataSourceBuilder = new NpgsqlDataSourceBuilder(connString);
            DataSource = DataSourceBuilder.Build();
        }

        // GET: api/<HighscoreController>
        [HttpGet]
        public async Task<Highscore> GetAsync()
        {
            NpgsqlConnection conn = DataSource.OpenConnection();

            await using var cmd = new NpgsqlCommand("select username, points from Highscore;", conn);
            await using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();

            Highscore highscore = new Highscore();
            highscore.Username = reader.GetString(0);
            highscore.Points = reader.GetInt32(1);

            return highscore;                        
        }

        // GET api/<HighscoreController>/5
        [HttpGet("{username}")]
        public async Task<Highscore> GetAsync(string username)
        {
            NpgsqlConnection conn = DataSource.OpenConnection();

            await using var cmd = new NpgsqlCommand("select username, points from Highscore where username = (@username);", conn);
            cmd.Parameters.AddWithValue("@username", username);

            await using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();

            Highscore highscore = new Highscore();
            highscore.Username = reader.GetString(0);
            highscore.Points = reader.GetInt32(1);

            return highscore;
        }

        // POST api/<HighscoreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HighscoreController>/5
        [HttpPut("{username}")]
        public async Task PutAsync(string username, [FromBody] Highscore highscore)
        {
            NpgsqlConnection conn = DataSource.OpenConnection();

            await using (var cmd = new NpgsqlCommand(
                "INSERT INTO Highscore (username, points) " +
                "VALUES((@username), (@points)) " +
                "ON CONFLICT (username) " +
                "DO " +
                "UPDATE SET points = (@points);", conn))
            {
                cmd.Parameters.AddWithValue("@username", highscore.Username);
                cmd.Parameters.AddWithValue("@points", highscore.Points);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        // DELETE api/<HighscoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
