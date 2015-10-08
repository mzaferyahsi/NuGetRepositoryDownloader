using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;
using CommandLine;
using System.IO;
using System.Net;

namespace NuGetRepositoryDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ProgramOptions();
            var result = CommandLine.Parser.Default.ParseArguments(args, options);

            if (!result)
            {
                Console.WriteLine("Please provide valid values.");
                return;
            }
            if (string.IsNullOrEmpty(options.Repository))
            {
                Console.WriteLine("Invalid repository address.");
                return;
            }
            if (!string.IsNullOrEmpty(options.Path))
            {
                if (!Directory.Exists(options.Path))
                    Directory.CreateDirectory(options.Path);
            }

            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository(options.Repository);
            IEnumerable<IPackage> packages = null;

            if (string.IsNullOrEmpty(options.PackageId) && string.IsNullOrEmpty(options.Version))
                packages = repo.GetPackages();
            else if (!string.IsNullOrEmpty(options.PackageId))
                packages = repo.FindPackagesById(options.PackageId);

            if (!string.IsNullOrEmpty(options.Version))
                packages = packages.Where(p => p.Version == NuGet.SemanticVersion.Parse(options.Version));

            foreach (var pkg in packages)
            {
                DownloadPackage(options, pkg);
            };

            Console.WriteLine("Please press enter to close program.");
            Console.ReadLine();
        }

        private static void DownloadPackage(ProgramOptions options, IPackage pkg)
        {
            try
            {
                var pkgInfo = string.Format("Downloading {0} - {1}", pkg.Id, pkg.Version.ToString());
                Console.WriteLine(pkgInfo);
                var pkgName = pkg.Id + "-" + pkg.Version.ToString() + ".nupkg";
                var pkgUri = ((NuGet.DataServicePackage)pkg).DownloadUrl.AbsoluteUri;
                using (var client = new WebClient())
                {
                    var path = string.IsNullOrEmpty(options.Path.Trim()) ? pkgName : Path.Combine(options.Path, pkgName);
                    client.DownloadFile(pkgUri, path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }

    class ProgramOptions
    {
        [Option('r', Required = true, HelpText = "NuGet repository path.")]
        public string Repository { get; set; }

        [Option('p', Required = false, HelpText = "Path to download packages.")]
        public string Path { get; set; }

        [Option('i', Required = false, HelpText = "Package id.")]
        public string PackageId { get; set; }

        [Option('v', Required = false, HelpText = "Package version.")]
        public string Version { get; set; }
    }
}
