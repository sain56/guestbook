using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVM.Services {
    public static class CommandParamConverter {

        public static int f_getActiveTabItemID(TabControl tabcontrol) {

            //cast to tabcon
            TabControl tabcon = (TabControl)tabcontrol;

            //iterate trough all tabitems
            for (int i = 0; i < tabcon.Items.Count; i++) {

                //cast temporary
                TabItem tmp = (TabItem)tabcon.Items[i];

                //if it is selected -> return id
                if (tmp.IsSelected) {
                    return i;
                }
			}

            return -1;
        }
    }
}