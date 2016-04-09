using System.IO;
using System.Linq;

namespace Geo.Tests.Gps.Serialization
{
    public abstract class SerializerTestFixtureBase
    {
        protected DirectoryInfo GetReferenceFileDirectory(params string[] subDirectories)
        {
            // this in Debug mode returns "C:\PROGRAM FILES (X86)\MICROSOFT VISUAL STUDIO 14.0\COMMON7\IDE\COMMONEXTENSIONS\MICROSOFT\TESTWINDOW"
            //var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            var dir = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory);
            while (dir != null)
            {
                var refDir = dir.EnumerateDirectories().FirstOrDefault(x => x.Name == "reference");

                if (refDir != null)
                {

                    if (subDirectories == null || subDirectories.Length == 0)
                        dir = refDir;
                    else
                    {
                        foreach (var directory in subDirectories)
                        {
                            if (refDir != null)
                                refDir = refDir.EnumerateDirectories().FirstOrDefault(x => x.Name == directory);
                        }
                        dir = refDir;
                    }
                    break;
                }

                dir = dir.Parent;
            }

            return dir;
        }

    }
}
