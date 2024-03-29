namespace Lab5.Domain.Entities;

public class Song : Entity
{
    public string Name { get; set; }
    public int Position { get; set; }
    public int DurationInSeconds { get; set; }

    public int SingerId { get; set; }
    public Singer Singer { get; set; }

    public override string ToString()
    {
        return $"{Name} {Position} {DurationInSeconds}";
    }
}
