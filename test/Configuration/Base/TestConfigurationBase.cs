﻿using test.Configuration.Containers;

namespace test.Configuration.Base;

public class TestConfigurationBase : IAsyncLifetime
{
    
    private readonly PostgresTestContainer _postgresContainer;
    protected readonly HttpClient HttpClient;
    private readonly string _schema;

    protected TestConfigurationBase(PostgresTestContainer postgresContainer, string schema)
    {
        _schema = schema;
        _postgresContainer = postgresContainer;
        HttpClient = postgresContainer.CreateDefaultClient();
        HttpClient.BaseAddress = new Uri("http://localhost:5082/");
    }

    public async Task InitializeAsync()
    {
         await _postgresContainer.PopulateTablesAsync(_schema);
    }

    public async Task DisposeAsync()
    {
        await _postgresContainer.DeleteAllItemsFromTableAsync(_schema);
    }
    
}