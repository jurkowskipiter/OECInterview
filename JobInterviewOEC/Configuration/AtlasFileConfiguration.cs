using System.Collections.Generic;

namespace JobInterviewOEC.Configuration
{
    internal class AtlasFileConfiguration : IAtlasFileConfiguration
    {
        private readonly IReadOnlyDictionary<string, int> _parametersLength = new Dictionary<string, int>
        {
            { "CenterIdDealerNo", 5 },
            { "GrpNameDealerName", 35 },
            { "DealerNo", 10 },
            { "BillToPartly", 7 },
            { "Customer", 10 },
            { "LineMake", 2 },
            { "EndDate", 8 },
            { "ShipToParty", 5 },
            { "LocationId", 2 },
            { "AddrPriId", 10 },
            { "AddrLineOne", 50 },
            { "AddrLineTwo", 50 }
        };
        public IReadOnlyDictionary<string, int> ParametersLength => _parametersLength;

        private readonly string _filePath = @"..\file.00472";
        public string FilePath => _filePath;
    }
}
