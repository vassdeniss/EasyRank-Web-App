namespace EasyRank.Services.Models
{
    public class RankEntryServiceModel
    {
        public int Placement { get; set; }

        public string Title { get; set; } = null!;

        public string? Image { get; set; }

        public string ImageAlt { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
