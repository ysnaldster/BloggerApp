namespace BlogApplication.Domain.Entities;

public class InitData
{
    public static List<User> LoadUsers()
    {
        List<User> users = new List<User>();
        users.Add(new User()
        {
            Id = Guid.Parse("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb"),
            Name = "John",
            Password = "123456",
            Nickname = "John23",
            Email = "john@mail.com"
        });
        users.Add(new User()
        {
            Id = Guid.Parse("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc"),
            Name = "Fabiana",
            Password = "123456",
            Nickname = "Fabiana50",
            Email = "fabiana@mail.com"
        });
        users.Add(new User()
        {
            Id = Guid.Parse("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd"),
            Name = "Alexa",
            Password = "123456",
            Nickname = "Alexa05",
            Email = "alexa@mail.com"
        });
        return users;
    }

    public static List<Post> LoadPosts()
    {
        List<Post> posts = new List<Post>();
        posts.Add(new Post()
        {
            Id = Guid.Parse("e97de533-9e22-4944-92bc-bdd799b6c785"),
            UserId = Guid.Parse("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb"),
            CategoryId = Guid.Parse("b7d0bbf0-a1e9-4dbd-845b-f8e751160000"),
            Title = "The new things of technology",
            Author = "Camila",
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
            Status = true,
        });
        posts.Add(new Post()
        {
            Id = Guid.Parse("e97de533-9e22-4944-92bc-bdd799b6c786"),
            UserId = Guid.Parse("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc"),
            CategoryId = Guid.Parse("b7d0bbf0-a1e9-4dbd-845b-f8e751160001"),
            Author = "Santiago",
            Title = "Clean House Tips",
            Content = "Proin finibus sodales purus, et luctus urna laoreet ullamcorper. Donec vitae dapibus massa. Suspendisse id maximus risus",
            Status = false,
        });
        posts.Add(new Post()
        {
            Id = Guid.Parse("e97de533-9e22-4944-92bc-bdd799b6c787"),
            UserId = Guid.Parse("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd"),
            CategoryId = Guid.Parse("b7d0bbf0-a1e9-4dbd-845b-f8e751160002"),
            Author = "Fernando",
            Title = "New's",
            Content = "Fusce iaculis sem nec tellus suscipit congue. Etiam pharetra posuere porta. Mauris semper quam ut sapien pharetra laoreet. Donec ultrices",
            Status = true,
        });
        return posts;
    }

    public static List<Comment> LoadComments()
    {
        List<Comment> comments = new List<Comment>();
        comments.Add(new Comment()
        {
            Id = Guid.Parse("3ee05129-86e3-4fe3-ac97-23510c79d1f6"),
            PostId = Guid.Parse("e97de533-9e22-4944-92bc-bdd799b6c785"),
            UserId = Guid.Parse("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb"),
            Content = "when an unknown"
        });
        comments.Add(new Comment()
        {
            Id = Guid.Parse("3ee05129-86e3-4fe3-ac97-23510c79d1f7"),
            PostId = Guid.Parse("e97de533-9e22-4944-92bc-bdd799b6c786"),
            UserId = Guid.Parse("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc"),
            Content = "when an unknown a."
        });
        comments.Add(new Comment()
        {
            Id = Guid.Parse("3ee05129-86e3-4fe3-ac97-23510c79d1f8"),
            PostId = Guid.Parse("e97de533-9e22-4944-92bc-bdd799b6c787"),
            UserId = Guid.Parse("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd"),
            Content = "when an unknown again"
        });
        return comments;
    }

    public static List<Category> LoadCategories()
    {
        List<Category> categories = new List<Category>();
        categories.Add(new Category()
        {
            Id = Guid.Parse("b7d0bbf0-a1e9-4dbd-845b-f8e751160000"),
            Name = Category.CategoryName.Literature
        });
        categories.Add(new Category()
        {
            Id = Guid.Parse("b7d0bbf0-a1e9-4dbd-845b-f8e751160001"),
            Name = Category.CategoryName.Shows
        });
        categories.Add(new Category()
        {
            Id = Guid.Parse("b7d0bbf0-a1e9-4dbd-845b-f8e751160002"),
            Name = Category.CategoryName.Sports
        });
        return categories;
    }

    public static List<Label> LoadLabels()
    {
        List<Label> labels = new List<Label>();
        labels.Add(new Label()
        {
            Id = Guid.Parse("f4670c53-544a-40b7-8fc3-e772edd31725"),
            Name = Label.LabelName.Happy
        });
        labels.Add(new Label()
        {
            Id = Guid.Parse("f4670c53-544a-40b7-8fc3-e772edd31726"),
            Name = Label.LabelName.Surprise
        });
        labels.Add(new Label()
        {
            Id = Guid.Parse("f4670c53-544a-40b7-8fc3-e772edd31727"),
            Name = Label.LabelName.Mood
        });
        return labels;
    }

    public static List<PostLabelPivot> LoadPostLabelPivot()
    {
        List<PostLabelPivot> postLabelPivots = new List<PostLabelPivot>();
        postLabelPivots.Add(new PostLabelPivot()
        {
            Id = Guid.Parse("f71fca0f-ea8d-428a-a85a-dec6240bbba3"),
            PostId = Guid.Parse("e97de533-9e22-4944-92bc-bdd799b6c785"),
            LabelId = Guid.Parse("f4670c53-544a-40b7-8fc3-e772edd31725")
        });
        postLabelPivots.Add(new PostLabelPivot()
        {
            Id = Guid.Parse("f71fca0f-ea8d-428a-a85a-dec6240bbba4"),
            PostId = Guid.Parse("e97de533-9e22-4944-92bc-bdd799b6c786"),
            LabelId = Guid.Parse("f4670c53-544a-40b7-8fc3-e772edd31726")
        });
        postLabelPivots.Add(new PostLabelPivot()
        {
            Id = Guid.Parse("f71fca0f-ea8d-428a-a85a-dec6240bbba5"),
            PostId = Guid.Parse("e97de533-9e22-4944-92bc-bdd799b6c787"),
            LabelId = Guid.Parse("f4670c53-544a-40b7-8fc3-e772edd31727")
        });
        
        return postLabelPivots;
    }
}