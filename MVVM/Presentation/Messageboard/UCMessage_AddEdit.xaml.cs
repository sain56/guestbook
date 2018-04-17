using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM.Presentation.Department {
    /// <summary>
    /// Interaktionslogik für UCDepartment_AddEdit.xaml
    /// </summary>
    public partial class UCDepartment_AddEdit : UserControl {
        

        public UCDepartment_AddEdit(UCMessage_AddEditCtrl uCDepartment_AddEditCtrl) {

            InitializeComponent();
            this.DataContext = uCDepartment_AddEditCtrl;
        }
    }
}
