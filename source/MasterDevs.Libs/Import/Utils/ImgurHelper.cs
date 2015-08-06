
namespace MasterDevs.Lib.Common.Utils
{
    public static class ImgurHelper
    {
        public static string GetImgurUrl(string imgurId, bool isThumbnail, bool isHttps = false)
        {
            if (string.IsNullOrEmpty(imgurId))
                return null;

            //-- See https://api.imgur.com/models/image for more thumbnail sizes
            if (isThumbnail)
                return GetUrlSmallSquare(imgurId, isHttps);  //-- (90x90 - Will Crop to make square)

            return GetUrlHugeThumbnail(imgurId, isHttps); //-- (1024x1024 no crop, original aspect ratio)
        }

        public static string GetAlternateImageUrl(string url)
        {
            //-- See https://api.imgur.com/models/image

            //-- If we're the small cropped thumb, go for the bigger one.
            if (url.EndsWith("s.jpg"))
                return url.Replace(@"s.jpg", @"b.jpg");

            //-- If we're the big thumbnail, just download the original image
            if (url.EndsWith("h.jpg"))
                return url.Replace(@"h.jpg", @".jpg");

            return string.Empty;
        }

        public static string GetFullResImageUrl(string imgurId, bool isHttps = false)
        {
            //-- Original (full size) image
            return GetUrl(imgurId, string.Empty, isHttps);
        }

        /// <summary>
        /// Gets the Small Square Thumbnail<para>
        /// 90x90 Square (will crop)</para>
        /// </summary>
        /// <param name="imgurId">Imgur Id of the image you'd like to generate a url for.</param>
        /// <returns>a Url in the format http://i.imgur.com/{imgurId}{suffix}.jpg </returns>
        public static string GetUrlSmallSquare(string imgurId, bool isHttps = false)
        {
            return GetUrl(imgurId, "s", isHttps);
        }

        /// <summary>
        /// Gets the Small Square Thumbnail<para>
        /// 160x160 Square (will crop)</para>
        /// </summary>
        /// <param name="imgurId">Imgur Id of the image you'd like to generate a url for.</param>
        /// <returns>a Url in the format http://i.imgur.com/{imgurId}{suffix}.jpg </returns>
        public static string GetUrlBigSquare(string imgurId, bool isHttps = false)
        {
            return GetUrl(imgurId, "b", isHttps);
        }

        /// <summary>
        /// Gets the Small Square Thumbnail<para>
        /// 160x160 Thumbnail (max side 160 - preserves aspect ratio)</para>
        /// </summary>
        /// <param name="imgurId">Imgur Id of the image you'd like to generate a url for.</param>
        /// <returns>a Url in the format http://i.imgur.com/{imgurId}{suffix}.jpg </returns>
        public static string GetUrlSmallThumbnail(string imgurId, bool isHttps = false)
        {
            return GetUrl(imgurId, "t", isHttps);
        }

        /// <summary>
        /// Gets the Small Square Thumbnail<para>
        /// 320x320 Thumbnail (max side 320 - preserves aspect ratio)</para>
        /// </summary>
        /// <param name="imgurId">Imgur Id of the image you'd like to generate a url for.</param>
        /// <returns>a Url in the format http://i.imgur.com/{imgurId}{suffix}.jpg </returns>
        public static string GetUrlMediumThumbnail(string imgurId, bool isHttps = false)
        {
            return GetUrl(imgurId, "m", isHttps);
        }

        /// <summary>
        /// Gets the Small Square Thumbnail<para>
        /// 640x640 Thumbnail (max side 640 - preserves aspect ratio)</para>
        /// </summary>
        /// <param name="imgurId">Imgur Id of the image you'd like to generate a url for.</param>
        /// <returns>a Url in the format http://i.imgur.com/{imgurId}{suffix}.jpg </returns>
        public static string GetUrlLargeThumbnail(string imgurId, bool isHttps = false)
        {
            return GetUrl(imgurId, "l", isHttps);
        }

        /// <summary>
        /// Gets the Small Square Thumbnail<para>
        /// 1024x1024 Thumbnail (max side 1024 - preserves aspect ratio)</para>
        /// </summary>
        /// <param name="imgurId">Imgur Id of the image you'd like to generate a url for.</param>
        /// <returns>a Url in the format http://i.imgur.com/{imgurId}{suffix}.jpg </returns>
        public static string GetUrlHugeThumbnail(string imgurId, bool isHttps = false)
        {
            return GetUrl(imgurId, "h", isHttps);
        }

        private static string GetUrl(string imgurId, string suffix = "", bool isHttps = false)
        {
            if(isHttps)
                return string.Format(@"https://i.imgur.com/{0}{1}.jpg", imgurId, suffix);
            else
                return string.Format(@"http://i.imgur.com/{0}{1}.jpg", imgurId, suffix);
        }
    }
}