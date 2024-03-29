﻿using System.Net;
using System.Net.Http.Json;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using tests.Configuration.Base;
using tests.Configuration.Containers;
using tests.Utils;
using tests.Utils.JSON;

namespace tests.BlogApplication.Api.Controllers.UserController;

[Collection(nameof(IntegrationContainerCollection))]
public class DeleteUser : TestConfigurationBase
{
    private readonly User? _user;

    public DeleteUser(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[1])
    {
        _user =  UserJson.BuildModel();
    }
    
    /// <summary>
    /// DeleteUserValidateStatusCodeOk
    /// </summary>
    [Fact]
    public async void DeleteUserShouldReturn200StatusCode()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}user/api/users/{_user!.Id}");
        var response = await HttpClient.DeleteAsync(uri);
        var result = response.Content.ReadFromJsonAsync<User>().Result;
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result!.Id.Should().Be(_user.Id.ToString());
    }

}