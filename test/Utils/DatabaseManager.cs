namespace tests.Utils;

public abstract class DatabaseManager
{
    public static string[] GetQueryBySchema()
    {
        string[] queries =
        {
            "INSERT INTO net_user VALUES (@Id, @Name, @Password, @Nickname, @Email, @CreationDate, @UpdateDate)",
            "INSERT INTO post VALUES (@Id, @UserId, @CategoryId, @Title, @PublicationDate, @Content, @Author, @Status)",
            "INSERT INTO comment VALUES (@Id, @UserId, @PostId, @Content, @PublicationDate)"
        };
        return queries;
    }

    public static readonly string[] Tables = { "post", "net_user", "comment"};
}