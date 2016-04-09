using System.IO;
using System.Linq;
using NUnit.Framework;
using Geo.Gps;

namespace Geo.Tests.Gps.Serialization
{
    [TestFixture]
    public class GpsDeSerializerTests : SerializerTestFixtureBase
    {
        [Test]
        public void ImageFileTest()
        {
            var file = GetReferenceFileDirectory().GetFiles().First(x => x.Name == "image.png");
            using (var stream = new FileStream(file.FullName, FileMode.Open))
            {
                var data = GpsData.Parse(stream);

                Assert.That(data, Is.EqualTo(null));
            }
        }

        [Test]
        public void GpxFilesTest()
        {
            var dir = GetReferenceFileDirectory("gpx").EnumerateFiles();
            foreach (var fileInfo in dir)
            {
                using (var stream = new FileStream(fileInfo.FullName, FileMode.Open))
                {
                    var data = GpsData.Parse(stream);

                    Assert.That(data, Is.Not.Null);
                }
                
            }
        }
    }
}
