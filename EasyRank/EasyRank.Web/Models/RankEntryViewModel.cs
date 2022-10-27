namespace EasyRank.Web.Models
{
    public class RankEntryViewModel
    {
        public int Placement { get; set; }

        public string Title { get; set; } = null!;

        public string? Image { get; set; }

        public string Description { get; set; } = null!;
    }
}
