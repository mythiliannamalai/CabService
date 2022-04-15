using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab
{
    public class CabException :Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            Invalid_Distance,
            Invalid_Time,
            Invalid_User_Id
        }
        public CabException(ExceptionType type,string message):base(message)
        {
            this.type = type;
        }
    }
}
