using JobInterviewOEC.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobInterviewOEC.Services
{
    internal class AtlasDataRepository : IAtlasDataRepository
    {
        private readonly AppDbContext _appDbContext;

        public AtlasDataRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(AtlasData atlasData)
        {
            await _appDbContext.AddAsync(atlasData);
        }

        public async Task<bool> Any()
        {
            return await _appDbContext.AtlasData.AnyAsync();
        }

        public async Task<IList<AtlasData>> GetAll(string sortOrder, int pageNumber)
        {
            var query = from atlasData in _appDbContext.AtlasData
                        select atlasData;

            switch (sortOrder)
            {
                case "CenterIdDealerNoDesc":
                    {
                        query = query.OrderByDescending(a => a.CenterIdDealerNo);
                        break;
                    }

                case "CenterIdDealerNoAsc":
                    {
                        query = query.OrderBy(a => a.CenterIdDealerNo);
                        break;
                    }

                case "GrpNameDealerNameDesc":
                    {
                        query = query.OrderByDescending(a => a.GrpNameDealerName);
                        break;
                    }

                case "GrpNameDealerNameAsc":
                    {
                        query = query.OrderBy(a => a.GrpNameDealerName);
                        break;
                    }
                case "DealerNoDesc":
                    {
                        query = query.OrderByDescending(a => a.DealerNo);
                        break;
                    }

                case "DealerNoAsc":
                    {
                        query = query.OrderBy(a => a.DealerNo);
                        break;
                    }
                case "BillToPartlyDesc":
                    {
                        query = query.OrderByDescending(a => a.BillToPartly);
                        break;
                    }

                case "BillToPartlyAsc":
                    {
                        query = query.OrderBy(a => a.BillToPartly);
                        break;
                    }
                case "CustomerDesc":
                    {
                        query = query.OrderByDescending(a => a.Customer);
                        break;
                    }

                case "CustomerAsc":
                    {
                        query = query.OrderBy(a => a.Customer);
                        break;
                    }

                case "LineMakeDesc":
                    {
                        query = query.OrderByDescending(a => a.LineMake);
                        break;
                    }

                case "LineMakeAsc":
                    {
                        query = query.OrderBy(a => a.LineMake);
                        break;
                    }

                case "EndDateDesc":
                    {
                        query = query.OrderByDescending(a => a.EndDate);
                        break;
                    }

                case "EndDateAsc":
                    {
                        query = query.OrderBy(a => a.EndDate);
                        break;
                    }

                case "ShipToPartyDesc":
                    {
                        query = query.OrderByDescending(a => a.ShipToParty);
                        break;
                    }

                case "ShipToPartyAsc":
                    {
                        query = query.OrderBy(a => a.ShipToParty);
                        break;
                    }

                case "LocationIdDesc":
                    {
                        query = query.OrderByDescending(a => a.LocationId);
                        break;
                    }

                case "LocationIdAsc":
                    {
                        query = query.OrderBy(a => a.LocationId);
                        break;
                    }

                case "AddrPriIdDesc":
                    {
                        query = query.OrderByDescending(a => a.AddrPriId);
                        break;
                    }

                case "AddrPriIdAsc":
                    {
                        query = query.OrderBy(a => a.AddrPriId);
                        break;
                    }

                case "AddrLineOneDesc":
                    {
                        query = query.OrderByDescending(a => a.AddrLineOne);
                        break;
                    }

                case "AddrLineOneAsc":
                    {
                        query = query.OrderBy(a => a.AddrLineOne);
                        break;
                    }

                case "AddrLineTwoDesc":
                    {
                        query = query.OrderByDescending(a => a.AddrLineTwo);
                        break;
                    }

                case "AddrLineTwoAsc":
                    {
                        query = query.OrderBy(a => a.AddrLineTwo);
                        break;
                    }
            }

            return await query.Skip((pageNumber - 1) * 30)
                .Take(30)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
