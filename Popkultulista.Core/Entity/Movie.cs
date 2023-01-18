namespace Popkultulista.Core.Entity;

public class Movie : ListItem
{
    public Movie(string name, decimal fomoScore, decimal listScore, decimal totalScore, int createdById, int modifiedById) : base(name, fomoScore, listScore, totalScore, createdById, modifiedById)
    {
    }
}