using test.Setup;
namespace test.Containers;

[CollectionDefinition(nameof(IntegrationContainerSetup))]
public class IntegrationContainerSetup : 
    ICollectionFixture<PostgresTestContainer>
    //ICollectionFixture<AppFactoryTestContainer>
{
       
}