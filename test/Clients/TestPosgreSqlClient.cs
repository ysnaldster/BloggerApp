using BlogApplication.Domain.Entities;
using Dapper;
using Npgsql;

namespace test.Clients;

public class TestPosgreSqlClient 
{
   private readonly string _connectionString;
    private readonly string[] _tableNames =
    {
        "collection_processed_account"
    };

    public TestPosgreSqlClient(string connectionString)
    {
        _connectionString = connectionString;
    }

    private async Task ExecuteQueryAsync(string query, DynamicParameters? parameters = null)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.ExecuteAsync(query, parameters);
    }

    private async Task<List<Post>> ExecuteQuerySingle<T>(string query, DynamicParameters? parameters = null)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return await connection.QuerySingleOrDefaultAsync<List<Post>>(query, parameters);
    }
    
    public async Task PopulateTables()
    {
        var count = await ValidateExistDataOnTable();
        if (count == 0)
        {
            foreach (var post in InitData.LoadPosts())
            {
  
                var query = "INSERT INTO post VALUES (@Id, @UserId, @CategoryId, @Title, @PublicationDate, @Content, @Author, @Status)";
                await ExecuteQueryAsync(query, new DynamicParameters(post));    
            }
        }
    }

    public async Task DeleteAllItemsFromTableAsync(string tableName)
    {
        var query = @"DELETE FROM post;";
        await ExecuteQueryAsync(query);
    }

    private async Task<int> ValidateExistDataOnTable()
    {
        var query = @"SELECT * FROM post;";
        var result = await ExecuteQuerySingle<List<Post>>(query);
        return result.Count;
    }
}