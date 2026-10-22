using MascotPrintingUtility;
using MascotPrintingUtility.PL;
using MascotPrintingUtility.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace MascotPrintingUtility.DataLayer
{
    internal class DL_IPMaster
    {
        Common obj = new Common();
        SqlCommand cmd = null;

        public DataTable BindLineCode()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_IPMASTER";
                cmd.Parameters.AddWithValue("@type", "GETLINECODE");
                cmd.Parameters.AddWithValue("CompanyCode", PCommon.CompanyCode);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
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

        public DataTable GetData(string CompanyCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_IPMASTER";
                cmd.Parameters.AddWithValue("@type", "GETIP");
                cmd.Parameters.AddWithValue("@CompanyCode", CompanyCode);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);

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
        public DataTable Save(PLIPMaster request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_IPMASTER";
                cmd.Parameters.AddWithValue("@type", "SAVE");
                cmd.Parameters.AddWithValue("@PrinterIP", request.PrinterIP);
                cmd.Parameters.AddWithValue("@PrinterPort", request.PrinterPort);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
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
        public DataTable Update(PLIPMaster request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_IPMASTER";
                cmd.Parameters.AddWithValue("@type", "UPDATE");
                cmd.Parameters.AddWithValue("@IP", request.IP);
                cmd.Parameters.AddWithValue("@PORTNO", request.PortNo);
                cmd.Parameters.AddWithValue("@LINECODE", request.LineCode);
                cmd.Parameters.AddWithValue("@LINENAME", request.LineName);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("CompanyCode", PCommon.CompanyCode);
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
        public DataTable Delete(PLIPMaster request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_IPMASTER";
                cmd.Parameters.AddWithValue("@type", "DELETE");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@IP", request.IP);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
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

        public DataTable GetData1()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_IPMASTER";
                cmd.Parameters.AddWithValue("@type", "GETIP");
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
        public DataTable Save1(PLIPMaster request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_IPMASTER";
                cmd.Parameters.AddWithValue("@type", "SAVE");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@PrinterIP", request.PrinterIP);
                cmd.Parameters.AddWithValue("@PrinterPort", request.PrinterPort);
                cmd.Parameters.AddWithValue("@ScannerIP", request.ScannerIP);
                cmd.Parameters.AddWithValue("@ScannerPort", request.ScannerPort);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("@RejectionIP", request.RejectionIP);
                cmd.Parameters.AddWithValue("@RejectionPort", request.RejectionPort);
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
        public DataTable Update1(PLIPMaster request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_IPMASTER";
                cmd.Parameters.AddWithValue("@type", "UPDATE");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@PrinterIP", request.PrinterIP);
                cmd.Parameters.AddWithValue("@PrinterPort", request.PrinterPort);
                cmd.Parameters.AddWithValue("@ScannerIP", request.ScannerIP);
                cmd.Parameters.AddWithValue("@ScannerPort", request.ScannerPort);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("@RejectionIP", request.RejectionIP);
                cmd.Parameters.AddWithValue("@RejectionPort", request.RejectionPort);
                cmd.Parameters.AddWithValue("@PID", request.ID);
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
