using Newtonsoft.Json;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCDataContainer
    {
        [JsonProperty("PEXBC")]
        public pExbc PEXBC;

        public PEXBCDataContainer()
        {
        }

        public PEXBCDataContainer(pExbc pEXBC)
        {
            PEXBC = pEXBC;
        }
    }
}