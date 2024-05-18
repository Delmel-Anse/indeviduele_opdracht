using Microsoft.AspNetCore.Mvc;
using System.Data;
using ClassLibraryIndividueel.Business;
using ClassLibraryIndividueel.Data;
using ClassLibraryIndividueel.Data.Framework;



namespace WebApiNintendoGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NDSController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetNDS()
        {
            var ndsResult = NdsGames.GetNDSGame();
            List<NdsGame> nds = new List<NdsGame>();
            foreach (DataRow dr in ndsResult.DataTable.AsEnumerable())
            {
                NdsGame game = new NdsGame
                {
                    // Assuming the column names in the DataTable match the properties of the NdsGame class
                    DSId = Convert.ToInt32(dr["DSId"]),
                    DSNaam = dr["DSNaam"].ToString(),
                    DSBeschrijving = dr["DSBeschrijving"].ToString(),
                    DSPrijs = Convert.ToSingle(dr["DSPrijs"]),
                    DSAantal = Convert.ToInt32(dr["DSAantal"])
                    // Populate other properties similarly
                };

                // Add the NdsGame object to the list
                nds.Add(game);
            }
            return Ok(nds);
        }

        [HttpPost]
        public void VoegNDSToe(NdsGame nds)
        {
            NdsGames.VoegNdsGamesToe(nds.DSNaam, nds.DSBeschrijving, (int)nds.DSPrijs, nds.DSAantal);
        }
    }
}