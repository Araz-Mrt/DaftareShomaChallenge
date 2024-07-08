namespace DaftareShomaChallenge.Domain.Entities;

public interface IEntity
{
    int Id { get; set; }
}

public class BaseEntity : IEntity
{
    public int Id { get; set; }
}