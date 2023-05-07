using Newtonsoft.Json;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCVouchIdDataContainer
    {
        [JsonProperty("PEXBC")]
        public pExbc PEXBC;

        [JsonProperty("VOUCH_ID")]
        public string VOUCH_ID;

        public PEXBCVouchIdDataContainer()
        {
        }

        public PEXBCVouchIdDataContainer(pExbc pEXBC)
        {
            PEXBC = pEXBC;
        }

    }
}