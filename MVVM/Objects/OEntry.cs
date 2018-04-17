using MVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Objects {
    public class OEntry : BaseObjectClass {

        #region attr, props
        private int _id;

        public int p_id {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        private string _name;

        public string p_name {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        private string _message;
        public string p_message {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }
        private DateTime _date;
        public DateTime p_date {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }
        #endregion

        #region db

        private const string DB_TABLE = "t_messageEntry";

        public List<object[]> f_getDBTableRow() {
            List<object[]> row = new List<object[]>();
            row.Add(new object[] { "pk", p_id });
            row.Add(new object[] { "a_name", p_name });
            row.Add(new object[] { "a_message", p_message });
            row.Add(new object[] { "a_date", p_date });
            return row;
        }

        public static ObservableCollection<OEntry> f_selectAndConvertData(SQLExecuter sqlex, bool keepConnectionOpen, string where) {
            Obscol = new ObservableCollection<OEntry>();
            foreach (object[] row in sqlex.select(DB_TABLE, "", where, keepConnectionOpen)) {
                int id = Convert.ToInt32(row[0]);
                string name = Convert.ToString(row[1]);
                string message = Convert.ToString(row[2]);
                DateTime date = Convert.ToDateTime(row[3]);

                Obscol.Add(new OEntry { p_id=id, p_name = name, p_message = message, p_date=date });
            }
            return Obscol;
        }

        #endregion

        #region uc

        public static ObservableCollection<OEntry> Obscol { get; set; }

        internal static OEntry f_addEdit(SQLExecuter sqlex, bool keepConnectionOpen, bool toActualObscol, OEntry obj, string name, string message, DateTime date) {
            try {
                //add
                if (obj == null) {

                    //insert object into collection
                    Obscol.Add(new OEntry {
                        p_name = name,
                        p_message = message,
                        p_date =date
                    });

                    //insert entity and identify pk
                    int id = sqlex.insert(DB_TABLE, Obscol[Obscol.Count - 1].f_getDBTableRow(), keepConnectionOpen);

                    //overwrite determined primary key for entity
                    obj = Obscol[Obscol.Count - 1];
                    obj.p_id = id;
                    
                }

                //edit
                else {

                    //overwrite properties
                    obj.p_name = name;
                    obj.p_message = message;
                    obj.p_date = date;

                    //call update
                    sqlex.update(DB_TABLE, obj.f_getDBTableRow(), keepConnectionOpen);
                }

                if (!toActualObscol) {
                    Obscol.Remove(obj);
                }

                return obj;

            } catch (Exception exc) {
                throw exc;
            }
        }
        internal static void f_remove(SQLExecuter sqlex, bool keepConnectionOpen, OEntry obj) {
            try {

                #region handle children
               // bool leave;

                //set null
                //while (true) {
                //    leave = true;
                //    foreach (OEmployee x in OEmployee.Obscol) {
                //        if (x.p_department.p_id == obj.p_id) {
                //            OEmployee.f_addEdit(sqlex, true, true, x, null, x.p_employee_boss,
                //                x.p_name, x.p_birthday);
                //            leave = false;
                //            break;
                //        }
                //    }
                //    if (leave) break;
                //}
                #endregion

                //exec sql statement
                sqlex.delete(DB_TABLE, "where pk=" + obj.p_id, keepConnectionOpen);

                //remove this from obscol
                Obscol.Remove(obj);
            } catch (Exception exc) {
                throw exc;
            }
        }


        #endregion

       
        #region helper

        //public ObservableCollection<OEmployee> p_help_EmployeeObscol { get {
        //    OnPropertyChanged();
        //    return OEmployee.Obscol; }
            
        //}


        #endregion

    }
}