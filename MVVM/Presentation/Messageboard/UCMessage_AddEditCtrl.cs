using MVVM.Objects;
using MVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.Presentation.Department {
    public class UCMessage_AddEditCtrl : Services.BaseCtrl {
        private WMain _wmain;
        
        
        public UCMessage_AddEditCtrl(SQLExecuter sqlex, WMain wmain, OEntry o) {
            _wmain = wmain;
            _sqlExecuter = sqlex;
            _selectedDepartment = o;
            f_initializeData();

            //cmd
            p_cmd_apply = new RelayCommand(f_cmd_apply);
            p_cmd_cancel = new RelayCommand(f_cmd_cancel);

            //pres
            UCDepartment_AddEdit uc = new UCDepartment_AddEdit(this);
            wmain.c_stack_form.Children.Add(uc);
            if (o != null) {
                uc.c_tb_name.SelectedText = o.p_name;
                uc.c_tb_message.Text = o.p_message;
            }
        }
        #region data

        private OEntry _selectedDepartment;

        public OEntry p_selectedDepartment {
            get { return _selectedDepartment; }
            set { _selectedDepartment = value; OnPropertyChanged(); }
        }
        
        

        private void f_initializeData() {
            //empty
        }
        #endregion

        #region cmd
        public RelayCommand p_cmd_apply { get; set; }
        public void f_cmd_apply(object param) {

            UCDepartment_AddEdit uc = (UCDepartment_AddEdit)param;

         
            string name = uc.c_tb_name.Text;
            string message = uc.c_tb_message.Text;
            DateTime date = DateTime.Now;


            OEntry.f_addEdit(_sqlExecuter, false, true, _selectedDepartment, name,message,date);

            f_closeDialogSequence();
        }

        public RelayCommand p_cmd_cancel { get; set; }
        public void f_cmd_cancel(object param) {
            f_closeDialogSequence();
        }
        #endregion


        #region helper
        public void f_closeDialogSequence() {
            _wmain.c_stack_main.Visibility = Visibility.Visible;
            _wmain.c_stack_form.Visibility = Visibility.Collapsed;
            _wmain.c_stack_form.Children.Clear();
        }
        #endregion

        

    }
}
