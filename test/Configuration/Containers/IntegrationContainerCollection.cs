namespace tests.Configuration.Containers;

[CollectionDefinition(nameof(IntegrationContainerCollection))]
public class IntegrationContainerCollection :
    ICollectionFixture<PostgresTestContainer>
    {
}
