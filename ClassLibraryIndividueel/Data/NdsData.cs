using ClassLibraryIndividueel.Business;
using ClassLibraryIndividueel.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryIndividueel.Data
{
    public class NdsData : SqlServer
    {
        public NdsData()
        {
            Init(new NdsGame());
        }
        NdsGame toeTeVoegenNdsGames = new NdsGame();

        public NdsData(NdsGame nds)
        {
            Init(nds);
        }
        private void Init(NdsGame nds)
        {
            TableName = "NDSGAMES";
            toeTeVoegenNdsGames = nds;
        }
        public string TableName { get; set; }
        public SelectResult Select()
        {
            var result = new SelectResult();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"select * from {TableName}");
                SqlCommand scd = new SqlCommand(sb.ToString());
                result = base.Select(scd);
                if (result.Succeeded)
                {
                    if (result.DataTable.Rows.Count == 0)
                    {
                        result.Succeeded = false;
                        result.AddError("Geen record gevonden");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public InsertResult Add(NdsGame nds)
        {
            var result = new InsertResult();
            try
            {
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {TableName} ");
                insertQuery.Append($"(DSNaam, DSBeschrijving, DSPrijs, DSAantal) VALUES ");
                insertQuery.Append($"(@DSNaam, @DSBeschrijving, @DSPrijs, @DSAantal); ");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.AddWithValue("@DSNaam", System.Data.SqlDbType.VarChar).Value = nds.DSNaam;
                    insertCommand.Parameters.AddWithValue("@DSBeschrijving", System.Data.SqlDbType.VarChar).Value = nds.DSBeschrijving;
                    insertCommand.Parameters.AddWithValue("@DSPrijs", System.Data.SqlDbType.VarChar).Value = nds.DSPrijs;
                    insertCommand.Parameters.AddWithValue("@DSAantal", System.Data.SqlDbType.VarChar).Value = nds.DSAantal;

                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}
