using Microsoft.Azure.Management.ApiManagement.ArmTemplates.Common;

namespace Microsoft.Azure.Management.ApiManagement.ArmTemplates.Extract
{
    /// <summary>
    /// Interface to seperate Template linking strategies (either StorageSAS or TemplateSpec)
    /// </summary>
    public class StorageSASPolicyTemplateLinkingStrategy : ITemplateLinkingStrategy
    {
        public MasterTemplateLink BuildMasterTemplateLink(string uriLink)
        {
            return new MasterTemplateLink()
            {
                uri = uriLink,
                contentVersion = "1.0.0.0"
            };
        }

        public string GenerateLinkedTemplateUri(Extractor extractor, string fileName)
        {
            var linkedTemplatesSasToken = extractor.linkedTemplatesSasToken;
            string linkedTemplateUri = linkedTemplatesSasToken != null ?
                $"parameters('{ParameterNames.LinkedTemplatesBaseUrl}'), '{fileName}', parameters('{ParameterNames.LinkedTemplatesSasToken}')"
                : $"parameters('{ParameterNames.LinkedTemplatesBaseUrl}'), '{fileName}'";
            return extractor.linkedTemplatesUrlQueryString != null ? $"[concat({linkedTemplateUri}, parameters('{ParameterNames.LinkedTemplatesUrlQueryString}'))]" : $"[concat({linkedTemplateUri})]";

        }

        public string GeneratePolicyUri(Extractor extractor, string fileName)
        {
            if (extractor.policyXMLSasToken != null)
            {
               return $"[concat(parameters('{ParameterNames.PolicyXMLBaseUrl}'), '{fileName}', parameters('{ParameterNames.PolicyXMLSasToken}'))]";
            }
            else
            {
                return $"[concat(parameters('{ParameterNames.PolicyXMLBaseUrl}'), '{fileName}')]";
            }
        }
    }
}
