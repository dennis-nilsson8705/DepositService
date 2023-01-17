namespace Data.Entities;

public class Users
{
    public Guid Id { get; set; }
    public int Key { get; set; }
    public string Name { get; set; }

    public Users(Guid id, int key, string name)
    {
        Id = id;
        Key = key;
        Name = name;
    }
}