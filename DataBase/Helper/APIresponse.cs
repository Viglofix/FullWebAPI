using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Helper
{
    public class APIresponse
    {
        public int ResponseCode { get; set; }
        public int Result { get; set; }
        public string StringResult { get; set; }
        public string ErrorMessage { get; set; }
    }
}
