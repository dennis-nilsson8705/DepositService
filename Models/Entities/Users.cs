namespace Data.Entities;

public class Users
{
    public Guid Id { get; set; }
    public int Key { get; set; }
 

    public Users(Guid id, int key)
    {
        Id = id;
        Key = Key;
    }
}