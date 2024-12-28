namespace WebTp7.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Movie> Movies { get; set; } = new List<Movie>();
}