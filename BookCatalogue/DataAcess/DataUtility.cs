using BookCatalogue.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogue.DataAcess
{
    public class DataUtility
    {
             /// <summary>
            /// Private Variable Declaration

            #region Private Variable Declaration
            private SqlConnection SqlCon;
            private SqlCommand sqlcmd = null;
            private SqlParameter SqlParam = null;
            private string _ConnectionString = string.Empty;

            private IConfiguration _configuration;
            #endregion End Of Private Variable Declaration


            #region Public Variable and methods
            public virtual string ConnectionString
            {
                get
                { return this._ConnectionString; }
                set
                { this._ConnectionString = value; }
            }


            /// <summary>
            /// Default Constructor Class
            /// </summary>      
            public DataUtility(IConfiguration iConfiguration)
            {
                _configuration = iConfiguration;
                if (ConnectionString == null)
                {
                    this.ConnectionString = _configuration.GetConnectionString("DefaultConnection"); ;
                }
            }


            /// <summary>
            /// Parameteries Constructor Class
            /// </summary>
            /// <param name="connectionString"></param>
            public DataUtility(string connectionString)
            {
                this.ConnectionString = connectionString;
            }


            /// <summary>
            /// Private Method openConnection use "ConnectionString" key from the web.config file to get the connection string
            /// Purpose:-
            ///		-Read the properties from web.config
            ///		-open connection
            ///		-initialize command object
            /// </summary>
            public virtual void OpenConnection()
            {
                sqlcmd = new SqlCommand();
                SqlParam = new SqlParameter();
                try
                {
                    this.ConnectionString = this._configuration.GetConnectionString("DefaultConnection");
                    if (SqlCon == null)
                    {
                        SqlCon = new SqlConnection(this.ConnectionString);
                    }
                    if (SqlCon.State == ConnectionState.Closed)
                    {
                        SqlCon.ConnectionString = ConnectionString;
                        SqlCon.Open();
                        sqlcmd.Connection = SqlCon;
                    }
                }
                catch (Exception)
                {

                    throw new Exception("Connection string is not correct.");
                }

            }

            /// <summary>
            /// Private Method closeConnection 
            /// Purpose:-
            ///			-Close the connection object
            /// </summary>
            public virtual void CloseConnection()
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Dispose();
            }

            /// <summary>  
            /// This method is used Generic dictonary as a parameter.
            /// purpose:-
            ///			-for INSERT,UPDATE and DELETE operations using stored procedures
            /// </summary>
            /// <param name="sp_name">Stored Procedure name</param>
            /// <param name="Dictionary<string, string>">Dictionary object as parameter Name and its values</param>
            /// Collection 
            /// <returns>number of rows effected</returns>
            public Int32 ExecuteProc(string sp_Name, Dictionary<string, string> objExecuteProc)
            {
                this.OpenConnection();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = sp_Name;
                SqlParam = sqlcmd.Parameters.Add("@return", SqlDbType.Int);
                SqlParam.Direction = ParameterDirection.ReturnValue;
                foreach (KeyValuePair<string, string> kv in objExecuteProc)
                {
                    sqlcmd.Parameters.AddWithValue(kv.Key, kv.Value);
                }

                Int32 irow = this.sqlcmd.ExecuteNonQuery();

                this.CloseConnection();
                return irow;
            }


            public Int32 ExecuteProc(string sp_Name, List<UDParameters> objExecuteProc)
            {
                this.OpenConnection();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = sp_Name;
                foreach (UDParameters kv in objExecuteProc)
                {
                    sqlcmd.Parameters.AddWithValue(kv.key, kv.value);
                }

                Int32 irow = this.sqlcmd.ExecuteNonQuery();
                this.CloseConnection();
                return irow;
            }


            public DataSet GetDataSet(string sp_Name, List<UDParameters> objExecuteProc)
            {
                this.OpenConnection();
                SqlDataAdapter Sqlda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = sp_Name;
                sqlcmd.CommandTimeout = 5200;
                SqlParam.Direction = ParameterDirection.ReturnValue;

                foreach (UDParameters kv in objExecuteProc)
                {
                    sqlcmd.Parameters.AddWithValue(kv.key, kv.value);
                }
                Sqlda.SelectCommand = sqlcmd;

                Sqlda.Fill(ds);
                this.CloseConnection();
                return ds;
            }

            #endregion
           
        }
    
}
