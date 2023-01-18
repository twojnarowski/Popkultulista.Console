using Popkultulista.Core.Common;

namespace Popkultulista.Core;

public class ListItem : BaseEntity
{
    public string Name { get; set; }

    public decimal FomoScore { get; set; }

    public decimal ListScore { get; set; }

    public decimal TotalScore { get; set; }

    public ListItem(string name, decimal fomoScore, decimal listScore, decimal totalScore, int createdById, int modifiedById) : base(createdById, modifiedById)
    {
        this.Name = name;
        this.FomoScore = fomoScore;
        this.ListScore = listScore;
        this.TotalScore = totalScore;
    }
}