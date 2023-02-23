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
            var query = DatabaseManager.GetQueryBySchema();
            var userData = InitData.LoadUsers();
            var postData = InitData.LoadPosts();
            for (var i = 0; i < 3; i++)
            {
                await ExecuteQueryAsync(query[0], new DynamicParameters(userData[i]));
                await ExecuteQueryAsync(query[1], new DynamicParameters(postData[i]));
            }
        }
    }

    public async Task DeleteAllItemsFromTableAsync()
    {
        foreach (var table in DatabaseManager.Tables)
        {
            var query = $"DELETE FROM {table};";
            await ExecuteQueryAsync(query);
        }
    }

    private async Task<int> ValidateExistDataOnTable(string schema)
    {
        var query = $"SELECT * FROM {schema};";
        var result = await ExecuteQuerySingle(query);
        return result.Count();
    }

}