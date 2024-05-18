using ClassLibraryIndividueel.Data;
using ClassLibraryIndividueel.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryIndividueel.Business
{
    public class NdsGames
    {
        public static SelectResult GetNDSGame()
        {
            NdsData ndsData = new NdsData();
            SelectResult result = ndsData.Select();
            return result;
        }

        public static InsertResult VoegNdsGamesToe(string dsNaam, string beschrijving, int prijs, int aantal)
        {
            NdsGame nds = new NdsGame();
            nds.DSNaam = dsNaam;
            nds.DSBeschrijving = beschrijving;
            nds.DSPrijs = prijs;
            nds.DSAantal = aantal;

            //TODO: Check om te zien of een wachtwoord een hoofdletter en cijfer bevat
            NdsData accountData = new NdsData();
            return accountData.Add(nds);
        }
    }


}
