namespace CMScenter.Views.Models
{
    public class NourViewModel
    {
        public List<Video> videos { get; set; }
        public List<Video> latestVideos { get; set; }
        public List<Video> FeaturedVideos { get; set; }
        public Video videItem { get; set; }
        public List<VideoComment> comments { get; set; }
        public VideoComment comment { get; set; }

        public List<VideoCat> videoCtegories { get; set; }


    }
}
