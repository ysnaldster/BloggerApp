namespace test.Utils;

public abstract class QueryBase
{
    public static string GetQueryBySchema(string schema)
    {
        var query = schema switch
        {
            "post" =>
                "INSERT INTO post VALUES (@Id, @UserId, @CategoryId, @Title, @PublicationDate, @Content, @Author, @Status)",
            "user" => "INSERT INTO user",
            _ => null!
        };
        return query;
    }
}