namespace Portal.Application.DTO
{
    public class VideoDTO : MaterialDTO
    {
        public TimeSpan Duration { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Title} - {Quality}p, {Duration.ToString(@"hh\:mm\:ss")}";
        }
    }
}
