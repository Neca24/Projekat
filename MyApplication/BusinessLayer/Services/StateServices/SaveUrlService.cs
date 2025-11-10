namespace BusinessLayer.Services.StateServices
{
    public class SaveUrlService
    {
        public string? Url { get; set; }
        public int? SelectedId { get; set; } = null;
        public string? RootUrl { get; set; }
        public string? TargetPage { get; set; }
        public string? ThisTrenutniSql { get; set; } = "SELECT * FROM Izdaje";
    }
}
