namespace MyApp_aspnetcorenine.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<string>? Items { get; set; }
    }
}
