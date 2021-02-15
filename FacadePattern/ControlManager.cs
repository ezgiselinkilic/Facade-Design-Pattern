using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public static class ControlManager
    {
        public static bool ReceteDurum()
        {
            if (KayıtlıHastalar.rhastalar.Count!=0)
            
                return true;

            else
                return false;
        }
       
    }
}
