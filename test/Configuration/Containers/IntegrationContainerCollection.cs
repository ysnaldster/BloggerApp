namespace test.Configuration.Containers;

[CollectionDefinition(nameof(IntegrationContainerCollection))]
public class IntegrationContainerCollection :
    ICollectionFixture<PostgresTestContainer>
    {
}
