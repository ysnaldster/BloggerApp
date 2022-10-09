using BlogApplication.Domain.interfaces;

namespace BlogApplication.Domain.Services;

public class PostService : IPost
{
    public Task SavePost()
    {
        Thread.Sleep(10000);
        Console.WriteLine("Termino la tarea");
        return Task.CompletedTask;
    }
}