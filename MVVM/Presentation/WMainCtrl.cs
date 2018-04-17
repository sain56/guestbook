using MVVM.Objects;
using MVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVM.Presentation {
    public class WMainCtrl : BaseCtrl {
        private WMain _wMain;
        public WMainCtrl() {
            try {

                //data
                f_initializeData();

                //cmd
                p_cmd_add = new RelayCommand(f_cmd_add);
                p_cmd_edit = new RelayCommand(f_cmd_edit);
                p_cmd_remove = new RelayCommand(f_cmd_remove);
                p_cmd_dc = new RelayCommand(f_cmd_dc);
                
                //presentation
                _wMain = new WMain( this, "Project management and organisation",false);
                _wMain.Show();

            } catch (Exception exc) {
                printError(exc.Message);
            }
        }

        #region data


        /// <summary>
        /// set sqlex and fill obscols
        /// </summary>
        private void f_initializeData() {
            try {

                //init sqlex to load out and manage the db content
                _sqlExecuter = new SQLExecuter(Path.Combine(Environment.CurrentDirectory, "data.accdb"));

                //fill item sources
                p_departments = OEntry.f_selectAndConvertData(_sqlExecuter, false, "");               

            } catch (Exception exc) {
                throw exc;
            }
        }

        #region item sources

        private ObservableCollection<OEntry> _departments;
        public ObservableCollection<OEntry> p_departments {
            get { return _departments; }
            set { _departments = value; OnPropertyChanged(); }
        }      
        #endregion

        #region selections       
        #endregion

        #endregion

        #region cmd

        public RelayCommand p_cmd_add { get; set; }
        public void f_cmd_add(object param) {
            WMain w = (WMain)param;
            f_openDialogSequence(w);
            new Department.UCMessage_AddEditCtrl(_sqlExecuter, w, null);
           
        }

        public RelayCommand p_cmd_dc { get; set; }
        public void f_cmd_dc(object param) {
            WMain w = (WMain)param;
            f_openDialogSequence(w);
            new Department.UCMessage_AddEditCtrl(_sqlExecuter, w, p_selectedMessage);
        }

        public RelayCommand p_cmd_edit { get; set; }
        public void f_cmd_edit(object param) {
            WMain w = (WMain)param;
            f_openDialogSequence(w);
            new Department.UCMessage_AddEditCtrl(_sqlExecuter, w, p_selectedMessage);
            
        }

        public RelayCommand p_cmd_remove { get; set; }
        public void f_cmd_remove(object param) {
            WMain w = (WMain)param;
            f_openDialogSequence(w);
            OEntry.f_remove(_sqlExecuter, false, p_selectedMessage);
            f_closeDialogSequence(w);
           
        }

        #endregion

        #region helper
        public void f_openDialogSequence(WMain w) {
            w.c_stack_main.Visibility = Visibility.Collapsed;
            w.c_stack_form.Visibility = Visibility.Visible;
            w.c_stack_form.Children.Clear();
        }
        public void f_closeDialogSequence(WMain w) {
            w.c_stack_main.Visibility = Visibility.Visible;
            w.c_stack_form.Visibility = Visibility.Collapsed;
            w.c_stack_form.Children.Clear();
        }
        #endregion

        public OEntry p_selectedMessage { get; set; }
    }
}
