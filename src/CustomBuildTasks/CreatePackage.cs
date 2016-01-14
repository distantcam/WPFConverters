using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet;
using CustomBuildTasks;

public class CreatePackage : Task
{
    class PropertyProvider : Dictionary<string, dynamic>, IPropertyProvider
    {
        dynamic IPropertyProvider.GetPropertyValue(string propertyName)
        {
            dynamic value;
            if (TryGetValue(propertyName, out value))
                return value;

            return null;
        }
    }

    [Required]
    public ITaskItem DestinationFolder { get; set; }

    [Required]
    public ITaskItem NuSpecFile { get; set; }

    [Required]
    public ITaskItem ReferenceLibrary { get; set; }

    public ITaskItem PackagesConfig { get; set; }

    public override bool Execute()
    {
        try
        {
            InnerExecute();
        }
        catch (Exception ex)
        {
            Log.LogErrorFromException(ex, true, true, null);
        }

        return !Log.HasLoggedErrors;
    }

    private void InnerExecute()
    {
        var path = DestinationFolder.FullPath();
        Directory.CreateDirectory(path);

        var propertyProvider = new PropertyProvider()
        {
            { "version", GitVersionInformation.NuGetVersionV2 }
        };

        var packageBuilder = new PackageBuilder();

        using (var spec = File.OpenRead(NuSpecFile.FullPath()))
        {
            var manifest = Manifest.ReadFrom(spec, propertyProvider, false);
            packageBuilder.Populate(manifest.Metadata);
        }

        packageBuilder.PopulateFiles("", new[] { new ManifestFile { Source = ReferenceLibrary.FullPath(), Target = "lib" } });

        var debug = Path.ChangeExtension(ReferenceLibrary.FullPath(), ".pdb");
        if (File.Exists(debug))
        {
            packageBuilder.PopulateFiles("", new[] { new ManifestFile { Source = debug, Target = "lib" } });
        }

        if (File.Exists(PackagesConfig.FullPath()))
        {
            var dependencies = new List<PackageDependency>();

            var doc = XDocument.Load(PackagesConfig.FullPath());

            var packages = doc.Descendants()
                .Where(x => x.Name == "package" && x.Attribute("developmentDependency")?.Value != "true")
                .Select(p => new { id = p.Attribute("id").Value, version = SemanticVersion.Parse(p.Attribute("version").Value) })
                .Select(p => new PackageDependency(p.id, new VersionSpec() { IsMinInclusive = true, MinVersion = p.version }));

            dependencies.AddRange(packages);

            packageBuilder.DependencySets.Add(new PackageDependencySet(null, dependencies));
        }

        var packagePath = Path.Combine(path, packageBuilder.GetFullName() + ".nupkg");

        using (var file = new FileStream(packagePath, FileMode.Create))
        {
            Log.LogMessage($"Saving file {packagePath}");

            packageBuilder.Save(file);
        }
    }
}