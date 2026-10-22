using MascotPrintingUtility.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace MascotPrintingUtility.DataLayer
{
    internal class DL_LogData
    {
        Common obj = new Common();
        SqlCommand cmd = null;

        public DataTable GetData(string LogModule, string sLogData)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_StoreLog";
                cmd.Parameters.AddWithValue("@type", "SAVEDATA");
                cmd.Parameters.AddWithValue("@LoginID", PCommon.UserID);
                cmd.Parameters.AddWithValue("@LogIP", PCommon.sSystemName);
                cmd.Parameters.AddWithValue("@LogModule", LogModule);
                cmd.Parameters.AddWithValue("@LogData", sLogData);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
    }
}
