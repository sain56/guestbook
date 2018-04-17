using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Services {

    public static class ExtendMethods {

        public static double Years(this TimeSpan ts) {
            return (double)((DateTime.Now.Year - DateTime.Now.AddDays(-ts.Days).Year) * 12 
                + DateTime.Now.Month - DateTime.Now.AddDays(-ts.Days).Month) / 12;
        }
    }
}
