namespace Popkultulista.Core.Entity;

public class TvShow : ListItem
{
    public TvShow(string name, decimal fomoScore, decimal listScore, decimal totalScore, int createdById, int modifiedById) : base(name, fomoScore, listScore, totalScore, createdById, modifiedById)
    {
    }
}