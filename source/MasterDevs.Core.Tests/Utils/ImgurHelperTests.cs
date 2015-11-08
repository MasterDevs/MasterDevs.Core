using MasterDevs.Core.Utils;
using NUnit.Framework;

namespace MasterDevs.Core.Tests.Utils
{
    [TestFixture]
    public class ImgurHelperTests
    {
        [Test]
        [TestCase("https://imgur.com/xxxs.jpg", ExpectedResult = "https://imgur.com/xxxb.jpg")]
        [TestCase("http://imgur.com/xxxs.jpg", ExpectedResult = "http://imgur.com/xxxb.jpg")]
        [TestCase("https://imgur.com/xxxh.jpg", ExpectedResult = "https://imgur.com/xxx.jpg")]
        [TestCase("http://imgur.com/xxxh.jpg", ExpectedResult = "http://imgur.com/xxx.jpg")]
        [TestCase("http://imgur.com/invalidUrl.jpg", ExpectedResult = "")]
        public string GetAlternateImageUrl(string url)
        {
            return ImgurHelper.GetAlternateImageUrl(url);
        }

        [Test]
        [TestCase("abcd", true, ExpectedResult = "https://i.imgur.com/abcd.jpg")]
        [TestCase("abcd", false, ExpectedResult = "http://i.imgur.com/abcd.jpg")]
        public string GetFullResImageUrl(string imgurId, bool isHttps)
        {
            return ImgurHelper.GetFullResImageUrl(imgurId, isHttps);
        }

        [Test]
        [TestCase("abcd", true, true, ExpectedResult = "https://i.imgur.com/abcds.jpg")]
        [TestCase("abcd", true, false, ExpectedResult = "http://i.imgur.com/abcds.jpg")]
        [TestCase("abcd", false, true, ExpectedResult = "https://i.imgur.com/abcdh.jpg")]
        [TestCase("abcd", false, false, ExpectedResult = "http://i.imgur.com/abcdh.jpg")]
        public string GetImgurUrl(string imgurId, bool isThumbnail, bool isHttps)
        {
            return ImgurHelper.GetImgurUrl(imgurId, isThumbnail, isHttps);
        }

        [Test]
        [TestCase("abcd", true, ExpectedResult = "https://i.imgur.com/abcdb.jpg")]
        [TestCase("abcd", false, ExpectedResult = "http://i.imgur.com/abcdb.jpg")]
        public string GetUrlBigSquare(string imgurId, bool isHttps)
        {
            return ImgurHelper.GetUrlBigSquare(imgurId, isHttps);
        }

        [Test]
        [TestCase("abcd", true, ExpectedResult = "https://i.imgur.com/abcdh.jpg")]
        [TestCase("abcd", false, ExpectedResult = "http://i.imgur.com/abcdh.jpg")]
        public string GetUrlHugeThumbnail(string imgurId, bool isHttps)
        {
            return ImgurHelper.GetUrlHugeThumbnail(imgurId, isHttps);
        }

        [Test]
        [TestCase("abcd", true, ExpectedResult = "https://i.imgur.com/abcdl.jpg")]
        [TestCase("abcd", false, ExpectedResult = "http://i.imgur.com/abcdl.jpg")]
        public string GetUrlLargeThumbnail(string imgurId, bool isHttps)
        {
            return ImgurHelper.GetUrlLargeThumbnail(imgurId, isHttps);
        }

        [Test]
        [TestCase("abcd", true, ExpectedResult = "https://i.imgur.com/abcdm.jpg")]
        [TestCase("abcd", false, ExpectedResult = "http://i.imgur.com/abcdm.jpg")]
        public string GetUrlMediumThumbnail(string imgurId, bool isHttps)
        {
            return ImgurHelper.GetUrlMediumThumbnail(imgurId, isHttps);
        }

        [Test]
        [TestCase("abcd", true, ExpectedResult = "https://i.imgur.com/abcds.jpg")]
        [TestCase("abcd", false, ExpectedResult = "http://i.imgur.com/abcds.jpg")]
        public string GetUrlSmallSquare(string imgurId, bool isHttps)
        {
            return ImgurHelper.GetUrlSmallSquare(imgurId, isHttps);
        }

        [Test]
        [TestCase("abcd", true, ExpectedResult = "https://i.imgur.com/abcdt.jpg")]
        [TestCase("abcd", false, ExpectedResult = "http://i.imgur.com/abcdt.jpg")]
        public string GetUrlSmallThumbnail(string imgurId, bool isHttps)
        {
            return ImgurHelper.GetUrlSmallThumbnail(imgurId, isHttps);
        }
    }
}
