using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;

namespace NuGet.Indexing
{
    public class CatalogNuspecReader : NuspecReader
    {
        private readonly JObject _catalogItem;

        public CatalogNuspecReader(JObject catalogItem) : base(CreateXDocument(catalogItem))
        {
            _catalogItem = catalogItem;
        }

        private static XDocument CreateXDocument(JObject catalogItem)
        {
            var document = new XDocument();
            var package = new XElement("metadata");
            var metadata = new XElement("metadata");

            // ID
            var id = new XElement("id", (string)catalogItem["id"]);

            // dependencies
            var dependencies = new XElement("dependencies");
            foreach (var group in catalogItem.GetJArray("dependencyGroups"))
            {
                var groupElement = new XElement("group");
                groupElement.SetAttributeValue("targetFramework", (string)group["targetFramework"]);
                foreach (var dependency in group.GetJArray("dependencies"))
                {
                    var dependencyElement = new XElement("dependency");
                    dependencyElement.SetAttributeValue("id", (string)dependency["id"]);
                    dependencyElement.SetAttributeValue("version", (string)dependency["range"]);
                    groupElement.Add(dependencyElement);
                }

                dependencies.Add(groupElement);
            }

            // framework assemblies
            var frameworkAssemblies = new XElement("frameworkAssemblies");
            foreach (var group in catalogItem.GetJArray("frameworkAssemblyGroup"))
            {
                var element = new XElement("frameworkAssembly");
                element.SetAttributeValue("targetFramework", (string)group["targetFramework"]);
                frameworkAssemblies.Add(element);
            }

            metadata.Add(id);
            metadata.Add(dependencies);
            metadata.Add(frameworkAssemblies);
            package.Add(metadata);
            document.Add(package);

            return document;
        }
    }
}