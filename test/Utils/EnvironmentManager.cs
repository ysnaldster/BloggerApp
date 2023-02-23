namespace test.Utils;

public static class EnvironmentManager
{
    public static void SetEnvironmentVariables()
    {
        Environment.SetEnvironmentVariable("LOCALHOST_TESTS", "http://localhost:5082/");
        Environment.SetEnvironmentVariable("POSTGRES_DATABASE_NAME", "test_db");
        Environment.SetEnvironmentVariable("POSTGRES_DATABASE_USERNAME", "postgres");
        Environment.SetEnvironmentVariable("POSTGRES_DATABASE_PASSWORD", "postgres");
        Environment.SetEnvironmentVariable("POSTGRES_DATABASE_IMAGE", "postgres:latest");
        Environment.SetEnvironmentVariable("POSTGRES_DATABASE_EXPOSED_PORT", "5432");
    }

    public static string? LocalHostUrlTest => Environment.GetEnvironmentVariable("LOCALHOST_TESTS");
    public static string? PostgresDatabaseName => Environment.GetEnvironmentVariable("POSTGRES_DATABASE_NAME");
    public static string? PostgresDatabaseUserName => Environment.GetEnvironmentVariable("POSTGRES_DATABASE_USERNAME");

    public static string? PostgresDatabasePassword => Environment.GetEnvironmentVariable("POSTGRES_DATABASE_PASSWORD");

    public static string? PostgresDatabaseImage => Environment.GetEnvironmentVariable("POSTGRES_DATABASE_IMAGE");

    public static string? PostgresDatabaseExposedPort =>
        Environment.GetEnvironmentVariable("POSTGRES_DATABASE_EXPOSED_PORT");
}