namespace XsenseOfficial.ViewModels;

public class NewsVM
{
    public int ID { get; set; }

    public string Image { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DataTime { get; set; }

    public string DetailUrl => $"/NewsPage/{ID}";
}
