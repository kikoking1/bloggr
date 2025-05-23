namespace Bloggr.Database.Models;

public class Post
{
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}