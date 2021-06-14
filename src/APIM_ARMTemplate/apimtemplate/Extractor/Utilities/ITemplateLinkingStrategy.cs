using Microsoft.Azure.Management.ApiManagement.ArmTemplates.Common;

namespace Microsoft.Azure.Management.ApiManagement.ArmTemplates.Extract
{
    /// <summary>
    /// Interface to seperate Template linking strategies (either StorageSAS or TemplateSpec)
    /// </summary>
    public interface ITemplateLinkingStrategy
    {
        string GenerateLinkedTemplateUri(Extractor extractor, string fileName);
        MasterTemplateLink BuildMasterTemplateLink(string uriLink);

        string GeneratePolicyUri(Extractor extractor, string fileName);
    }
}
