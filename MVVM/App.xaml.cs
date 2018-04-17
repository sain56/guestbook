using MVVM.Presentation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM {
    public partial class App : Application {
        /// <summary>
        /// system entry point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void e_Startup(object sender, StartupEventArgs e) {
            new WMainCtrl();
        }
    }
}