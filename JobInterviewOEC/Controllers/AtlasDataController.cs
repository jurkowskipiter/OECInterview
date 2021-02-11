using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobInterviewOEC.Services;

namespace JobInterviewOEC.Controllers
{
    public class AtlasDataController : Controller
    {
        private readonly IAtlasDataRepository _atlasDataRepository;

        public AtlasDataController(IAtlasDataRepository atlasDataRepository)
        {
            _atlasDataRepository = atlasDataRepository;
        }

        public async Task<IActionResult> Index([FromQuery] string sortOrder, [FromQuery] int pageNumber)
        {
            if(pageNumber < 1)
            {
                pageNumber = 1;
            }
            
            ViewData["CurrentSort"] = sortOrder;

            if(pageNumber < 2)
            {
                ViewData["PreviousPage"] = 1;
            }

            else
            {
                ViewData["PreviousPage"] = pageNumber - 1;
            }

            if (pageNumber < 1)
            {
                ViewData["NextPage"] = 2;
            }

            else
            {
                ViewData["NextPage"] = pageNumber + 1;
            }

            ViewData["CenterIdDealerNoDesc"] = "CenterIdDealerNoDesc";
            ViewData["CenterIdDealerNoAsc"] = "CenterIdDealerNoAsc";

            ViewData["GrpNameDealerNameDesc"] = "GrpNameDealerNameDesc";
            ViewData["GrpNameDealerNameAsc"] = "GrpNameDealerNameAsc";

            ViewData["DealerNoDesc"] = "DealerNoDesc";
            ViewData["DealerNoAsc"] = "DealerNoAsc";

            ViewData["BillToPartlyDesc"] = "BillToPartlyDesc";
            ViewData["BillToPartlyAsc"] = "BillToPartlyAsc";

            ViewData["CustomerDesc"] = "CustomerDesc";
            ViewData["CustomerAsc"] = "CustomerAsc";
            
            ViewData["LineMakeDesc"] = "LineMakeDesc";
            ViewData["LineMakeAsc"] = "LineMakeAsc";

            ViewData["EndDateDesc"] = "EndDateDesc";
            ViewData["EndDateAsc"] = "EndDateAsc";

            ViewData["ShipToPartyDesc"] = "ShipToPartyDesc";
            ViewData["ShipToPartyAsc"] = "ShipToPartyAsc";

            ViewData["LocationIdDesc"] = "LocationIdDesc";
            ViewData["LocationIdAsc"] = "LocationIdAsc";

            ViewData["AddrPriIdDesc"] = "AddrPriIdDesc";
            ViewData["AddrPriIdAsc"] = "AddrPriIdAsc";

            ViewData["AddrLineOneDesc"] = "AddrLineOneDesc";
            ViewData["AddrLineOneAsc"] = "AddrLineOneAsc";

            ViewData["AddrLineTwoDesc"] = "AddrLineTwoDesc";
            ViewData["AddrLineTwoAsc"] = "AddrLineTwoAsc";

            return View(await _atlasDataRepository.GetAll(sortOrder, pageNumber));
        }
    }
}
