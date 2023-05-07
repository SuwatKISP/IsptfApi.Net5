using Newtonsoft.Json;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCVouchIdDataContainer
    {
        [JsonProperty("PEXBC")]
        public pExbc PEXBC;

        [JsonProperty("VouchId")]
        public string VouchId;

        public PEXBCVouchIdDataContainer()
        {
        }

        public PEXBCVouchIdDataContainer(pExbc pEXBC)
        {
            PEXBC = pEXBC;
        }

    }
}