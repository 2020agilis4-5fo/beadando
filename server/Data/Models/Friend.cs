namespace Data.Models
{
    public partial class Friend
    {
        public int LeftId { get; set; }
        public int RightId { get; set; }
        public ImageHubUser Left { get; set; }
        public ImageHubUser Right { get; set; }
    }
}
