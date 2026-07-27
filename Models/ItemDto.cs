public class CreateItemDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float Price { get; set; }
}

public class UpdateItemDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float Price { get; set; }
}