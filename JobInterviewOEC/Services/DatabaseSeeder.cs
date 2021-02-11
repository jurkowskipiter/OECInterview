using JobInterviewOEC.Services;
using System.Threading.Tasks;

namespace JobInterviewOEC
{
    class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IDataParser _dataParser;
        private readonly IFileReader _fileReader;
        private readonly IAtlasDataRepository _atlasDataRepository;

        public DatabaseSeeder(IDataParser dataParser, IAtlasDataRepository atlasDataRepository, IFileReader fileReader)
        {
            _dataParser = dataParser;
            _atlasDataRepository = atlasDataRepository;
            _fileReader = fileReader;
        }

        public async Task Seed()
        {
            var lines = _fileReader.ReadLinesFromFile();
            for (int i = 0; i < lines.Length; i++)
            {
                await _atlasDataRepository
                    .Add(BuildAtlasData(lines[i]));
                if(i % 100 == 0)
                {
                    await _atlasDataRepository.SaveChanges();
                }
            }
            await _atlasDataRepository.SaveChanges();

        }

        private AtlasData BuildAtlasData(string lineToRead)
        {
            var atlasData = new AtlasData()
            {
                CenterIdDealerNo = _dataParser.GetParsedParameter(nameof(AtlasData.CenterIdDealerNo), lineToRead),
                GrpNameDealerName = _dataParser.GetParsedParameter(nameof(AtlasData.GrpNameDealerName), lineToRead),
                DealerNo = _dataParser.GetParsedParameter(nameof(AtlasData.DealerNo), lineToRead),
                BillToPartly = _dataParser.GetParsedParameter(nameof(AtlasData.BillToPartly), lineToRead),
                Customer = _dataParser.GetParsedParameter(nameof(AtlasData.Customer), lineToRead),
                LineMake = _dataParser.GetParsedParameter(nameof(AtlasData.LineMake), lineToRead),
                EndDate = _dataParser.GetParsedParameter(nameof(AtlasData.EndDate), lineToRead),
                ShipToParty = _dataParser.GetParsedParameter(nameof(AtlasData.ShipToParty), lineToRead),
                LocationId = _dataParser.GetParsedParameter(nameof(AtlasData.LocationId), lineToRead),
                AddrPriId = _dataParser.GetParsedParameter(nameof(AtlasData.AddrPriId), lineToRead),
                AddrLineOne = _dataParser.GetParsedParameter(nameof(AtlasData.AddrLineOne), lineToRead),
                AddrLineTwo = _dataParser.GetParsedParameter(nameof(AtlasData.AddrLineTwo), lineToRead),
            };
            return atlasData;
        }
    }
}
