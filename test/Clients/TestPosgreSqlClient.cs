using BlogApplication.Domain.Entities;
using Dapper;
using Npgsql;
using test.Utils;

namespace test.Clients;

public class TestPosgreSqlClient 
{
   private readonly string _connectionString;
   
   public TestPosgreSqlClient(string connectionString)
    {
        _connectionString = connectionString;
    }

    private async Task ExecuteQueryAsync(string query, DynamicParameters? parameters = null)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.ExecuteAsync(query, parameters);
    }

    private async Task<IEnumerable<dynamic>> ExecuteQuerySingle(string query)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return await connection.QueryAsync(query);
    }
    
    public async Task PopulateTables(string schema)
    {
        var count = await ValidateExistDataOnTable(schema);
        if (count == 0)
        {
            foreach (var post in InitData.LoadPosts())
            {
                var query = QueryBase.GetQueryBySchema(schema);
                //var query = "INSERT INTO post VALUES (@Id, @UserId, @CategoryId, @Title, @PublicationDate, @Content, @Author, @Status)";
                await ExecuteQueryAsync(query, new DynamicParameters(post));    
            }
        }
    }

    public async Task DeleteAllItemsFromTableAsync(string schema)
    {
        var query = $"DELETE FROM {schema};";
        await ExecuteQueryAsync(query);
    }

    private async Task<int> ValidateExistDataOnTable(string schema)
    {
        var query = $"SELECT * FROM {schema};";
        var result = await ExecuteQuerySingle(query);
        return result.Count();
    }
}