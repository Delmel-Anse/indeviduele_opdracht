using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryIndividueel.Data.Framework
{
    public class SelectResult : BaseResult
    {
        public DataTable DataTable { get; set; }

        public List<string> Errors { get; } = new List<string>();
        public void AppendResult(SelectResult result)
        {
            Succeeded = Succeeded && result.Succeeded;
            Errors.AddRange(result.Errors);
        }
    }
}
