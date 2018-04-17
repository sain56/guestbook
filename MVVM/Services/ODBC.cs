using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Services {
    public class ODBC {

        private OdbcConnection _conn = null;
        private OdbcCommand _cmd = null;
        private OdbcDataReader _reader = null;

        protected ODBC(string path) {
            try {
                _conn = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; DBQ=" + path + ";");
            } catch (Exception exc) {
                throw exc;
            }
        }
        protected ODBC(string path, string user, string password) {
            try {
                _conn = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; DBQ=" + path + ";" + " PWD=" + password + ";");
            } catch (Exception exc) {
                throw exc;
            }
        }

        /// <summary>
        /// helper method, which converts a var to it's suitable sql parameter
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected string toSQLParameter(object o) {
            string s = String.Empty;
            switch (Type.GetTypeCode(o.GetType())) {
                case TypeCode.String: s += "'" + o.ToString().Replace("'", "''") + "'";//escapesequenz fuer apostroph
                    break;
                case TypeCode.Char: s += "'" + o + "'";
                    break;
                case TypeCode.Int32: s += o;
                    break;
                case TypeCode.Int16: s += o;
                    break;
                case TypeCode.Int64: s += o;
                    break;
                case TypeCode.Double: s += o.ToString().Replace(',', '.');
                    break;
                case TypeCode.DateTime: s += "'" + o + "'";
                    break;
                case TypeCode.Boolean: s += o;
                    break;
                case TypeCode.Decimal: s += o;
                    break;
                case TypeCode.Byte: s += o;
                    break;
                case TypeCode.Single: s += o;
                    break;
                case TypeCode.SByte: s += o;
                    break;
                case TypeCode.UInt16: s += o;
                    break;
                case TypeCode.UInt32: s += o;
                    break;
                case TypeCode.UInt64: s += o;
                    break;
            }
            return s;
        }
        /// <summary>
        /// helper method, which converts a ',' to a '.' (for doubles)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected string toSqlDouble(double d) {
            return d.ToString().Replace(',', '.');
        }


        /// <summary>
        /// close a conntection to a possibly conntected database (mdb or accdb)
        /// </summary>
        internal void closeConnection() {
            if (_reader != null) {
                _reader.Close();
                _reader = null;
            }
            if (_cmd != null) {
                _cmd.Dispose();
                _cmd = null;
            }
            if (_conn != null) {
                _conn.Close();
                //_conn = null;
            }
        }

        /// <summary>
        /// executes a sql select statement in the database
        /// </summary>
        /// <param name="sqlStatement">sql select statement</param>
        /// <returns></returns>
        protected List<object[]> executeSelect(string sqlStatement) {
            List<object[]> rows = new List<object[]>();
            try {
                if (_conn.State != ConnectionState.Open) {
                    _conn.Open();
                }
                _cmd = _conn.CreateCommand();
                _cmd.CommandText = sqlStatement;
                _reader = _cmd.ExecuteReader();
                int columns = _reader.FieldCount;
                while (_reader.Read()) {
                    object[] temp = new object[columns];
                    _reader.GetValues(temp);
                    rows.Add(temp);
                }
                return rows;
            } catch (OdbcException exc) {
                throw exc;
            }
        }
        /// <summary>
        /// executes  a sql dml statement in database
        /// </summary>
        /// <param name="sqlStatement">sql dml statement</param>
        /// <returns></returns>
        protected int executeDML(string sqlStatement, bool isSingleInsert) {
            try {
                if (_conn.State != ConnectionState.Open) {
                    _conn.Open();
                }
                _cmd = _conn.CreateCommand();
                _cmd.CommandText = sqlStatement;
                _cmd.ExecuteNonQuery();

                int RETURNVALUE = 0;
                if (isSingleInsert) {
                    _cmd.CommandText = "SELECT @@IDENTITY";
                    RETURNVALUE = (int)_cmd.ExecuteScalar();
                }
                return RETURNVALUE;

            } catch (OdbcException exc) {
                throw exc;
            } 
        }
    }
}
