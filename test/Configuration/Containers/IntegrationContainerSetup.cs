namespace test.Configuration.Containers;

[CollectionDefinition(nameof(IntegrationContainerSetup))]
public class IntegrationContainerSetup : 
    ICollectionFixture<PostgresTestContainer>
    //ICollectionFixture<AppFactoryTestContainer>
{
       
}