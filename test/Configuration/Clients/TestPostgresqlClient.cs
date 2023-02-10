using Dapper;
using Npgsql;

namespace test.Configuration.Clients;

public class TestPostgresqlClient
{
     private readonly string _connectionString;
    private readonly string[] _tableNames =
    {
        "collection_processed_account"
    };

    public TestPostgresqlClient(string connectionString)
    {
        _connectionString = connectionString;
    }

    private async Task ExecuteQueryAsync(string query, DynamicParameters? parameters = null)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.ExecuteAsync(query, parameters);
    }

    private async Task<T> ExecuteQuerySingle<T>(string query, DynamicParameters? parameters = null)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QuerySingleOrDefaultAsync<T>(query, parameters);
    }

    public async Task CreateTablesIfNotExists()
    {
        await CreateCollectionProcessedAccountTableIfNotExists();
    }

    private async Task CreateCollectionProcessedAccountTableIfNotExists()
    {
        var query = "";
        await ExecuteQueryAsync(query);
    }

    public async Task PopulateTables()
    {
        await PopulateCollectionProcessedAccountTable();
    }

    private async Task PopulateCollectionProcessedAccountTable()
    {
        var query = "";
        await ExecuteQueryAsync(query);
    }

    public async Task TruncateAllTablesAndRestartSequencesAsync()
    {
        foreach (var tableName in _tableNames) await TruncateTableAndRestartSequenceAsync(tableName);
    }

    private async Task TruncateTableAndRestartSequenceAsync(string tableName)
    {
        var query = $"TRUNCATE TABLE public.{tableName} RESTART IDENTITY RESTRICT;";
        await ExecuteQueryAsync(query);
    }

    public async Task DeleteAllItemsFromTablesAsync()
    {
        foreach (var tableName in _tableNames) await DeleteAllItemsFromTableAsync(tableName);
    }

    private async Task DeleteAllItemsFromTableAsync(string tableName)
    {
        var query = $"DELETE FROM {tableName}";
        await ExecuteQueryAsync(query);
    }

    public async Task<int> GetAllCountsSuccessCollectedAccounts()
    {
        var query = @"SELECT COUNT(*) FROM collection_processed_account WHERE status = 'Success';";
        return await ExecuteQuerySingle<int>(query);
    }
}