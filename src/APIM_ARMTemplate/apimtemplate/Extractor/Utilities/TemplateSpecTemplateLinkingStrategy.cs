using Microsoft.Azure.Management.ApiManagement.ArmTemplates.Common;

namespace Microsoft.Azure.Management.ApiManagement.ArmTemplates.Extract
{
    /// <summary>
    /// Interface to seperate Template linking strategies (either StorageSAS or TemplateSpec)
    /// </summary>
    public class TemplateSpecTemplateLinkingStrategy : ITemplateLinkingStrategy
    {
        public MasterTemplateLink BuildMasterTemplateLink(string uriLink)
        {
            return new MasterTemplateLink()
            {
                relativePath = uriLink
            };
        }

        public string GenerateLinkedTemplateUri(Extractor extractor, string fileName)
        {
            return $".{fileName}";
        }

        public string GeneratePolicyUri(Extractor extractor, string fileName)
        {
            return $"./policies{fileName}";
        }
    }
}
