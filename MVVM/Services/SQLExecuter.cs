using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Services {
    public class SQLExecuter : ODBC {

        /// <summary>
        /// standard db
        /// </summary>
        public SQLExecuter() : this(Path.Combine(Environment.CurrentDirectory, "database.accdb")) {}
        public SQLExecuter(string path) : base(path) {}
        public SQLExecuter(string path, string user, string password) : base(path, user, password) {}

        internal List<object[]> select(string table, string rows, string where, bool keepConnectionOpen) {
            try {
                if (rows=="") {
                    rows = "*";
                }
                string operation = "select "+rows+" from " + table;
                if (where != "") {
                    operation += " " + where;
                }
                return executeSelect(operation);
            } catch (Exception exc) {
                throw exc;
            } finally {
                if (!keepConnectionOpen) {
                    closeConnection();
                }
            }
        }
        /// <summary>
        /// inserting a row to a table. returns the primary key
        /// </summary>
        /// <param name="table"></param>
        /// <param name="row"></param>
        /// <returns>primary key</returns>
        internal int insert(string table, List<object[]> row, bool keepConnectionOpen) {
            try {
                //remove first position (pk) for inserting
                row.RemoveAt(0);


                string s = "insert into " + table + "(";

                foreach (object[] o in row) {
                    s += o[0].ToString() + ",";
                }
                s = s.Substring(0, s.Length - 1);
                s += ") values(";

                foreach (object[] o in row) {
                    s += toSQLParameter(o[1]);
                    s += ",";
                }

                s = s.Substring(0, s.Length - 1);
                s += "); "; 

                return executeDML(s, true);
            } catch (Exception exc) {
                throw exc;
            } finally {
                if (!keepConnectionOpen) {
                    closeConnection();
                }
            }
        }
        /// <summary>
        /// updating a row in a table by it's primary key
        /// </summary>
        /// <param name="table"></param>
        /// <param name="row"></param>
        internal void update(string table, List<object[]> row, bool keepConnectionOpen) {
            try {
                //remove first position (pk) for updating
                object[] pkColTemp = row[0];
                row.RemoveAt(0);


                string s = "update " + table + " set ";

                foreach (object[] o in row) {
                    s += o[0].ToString() + "=" + toSQLParameter(o[1]) + ",";
                }
                s = s.Substring(0, s.Length - 1);



                s += " where " + pkColTemp[0] + "=" + toSQLParameter(pkColTemp[1]) + "; ";

                executeDML(s, false);
            } catch (Exception exc) {
                throw exc;
            } finally {
                if (!keepConnectionOpen) {
                    closeConnection();
                }
            }
        }
        /// <summary>
        /// updating one col in a table by it's primary key
        /// </summary>
        /// <param name="table"></param>
        /// <param name="cols"></param>
        internal void update(string table, object[] col, string where, bool keepConnectionOpen) {
            try {
                string s = "update " + table + " set ";

                s += col[0].ToString() + "=" + toSQLParameter(col[1]) + ",";
                s = s.Substring(0, s.Length - 1);

                s += " "+where+"; ";

                executeDML(s, false);
            } catch (Exception exc) {
                throw exc;
            } finally {
                if (!keepConnectionOpen) {
                    closeConnection();
                }
            }
        }
        /// <summary>
        /// deleting a row in a table by a where expression
        /// </summary>
        /// <param name="table"></param>
        /// <param name="where"></param>
        internal void delete(string table, string where, bool keepConnectionOpen) {
            try {
                string s = "delete * from " + table;

                if (where == "") s += ";";
                else s += "  " + where + "; ";

                executeDML(s, false);
            } catch (Exception exc) {
                throw exc;
            } finally{
                if (!keepConnectionOpen) {
                    closeConnection();
                }
            }
        }
    }
}