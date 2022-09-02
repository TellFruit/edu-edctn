namespace Portal.Persistence_EF_Core.Repositories.Extension
{
    internal static class MaterialExtension
    {
        public static void MapFromArticleDomain(this Article article, ArticleDomain data)
        {
            article.Title = data.Title;
            article.Url = data.Url;
            article.Published = data.Published;
            article.UpdatedAt = data.UpdatedAt;
        }

        public static void MapFormBookDomain(this Book book, BookDomain data)
        {
            book.Title = data.Title;
            book.Authors = data.Authors;
            book.PageCount = data.PageCount;
            book.Format = data.Format;
            book.Published = data.Published;
            book.UpdatedAt = data.UpdatedAt;
        }

        public static void MapFromVideoDomain(this Video video, VideoDomain data)
        {
            video.Title = data.Title;
            video.Duration = data.Duration;
            video.Quality = data.Quality;
            video.UpdatedAt = data.UpdatedAt;
        }
    }
}
