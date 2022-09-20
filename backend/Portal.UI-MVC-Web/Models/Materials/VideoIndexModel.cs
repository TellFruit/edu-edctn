namespace Portal.UI_MVC_Web.Models.Materials
{
    public class VideoIndexModel
    {
        public ICollection<VideoDTO> Videos { get; set; }

        public VideoIndexModel(ICollection<VideoDTO> videos)
        {
            Videos = videos;
        }
    }
}
