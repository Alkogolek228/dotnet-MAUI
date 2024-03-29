namespace Lab5.Domain.Entities;

public class Singer : Entity
{
    public string Name { get; set; }

    public int Age { get; set; }

    public ICollection<Song> Songs { get; set; }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}
