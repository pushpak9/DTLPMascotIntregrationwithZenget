using MascotPrintingUtility.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace MascotPrintingUtility.DataLayer
{
    public class DL_DigitallinkDataResponse
    {
        Common obj = new Common();
        SqlCommand cmd = null;

        #region Batch Master Download

        public DataTable BindSyncBatched()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_MASTERSYNC";
                cmd.Parameters.AddWithValue("@type", "GetBatchDetails");
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

        public string SaveDataToDatabase(DataTable dtHeader)
        {
            string sOutMsg = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_BatchDataDownload";
                cmd.Parameters.AddWithValue("@type", "UPLOADDADTA");
                cmd.Parameters.AddWithValue("@details", dtHeader);
                cmd.Parameters.AddWithValue("@uploadedBy", PCommon.UserID);
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
            return sOutMsg;
        }

        public DataTable GetBatchType(string BatchNO)
        {
            string sOutMsg = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_MASTERSYNC";
                cmd.Parameters.AddWithValue("@type", "GetBatchType");
                cmd.Parameters.AddWithValue("@BatchNO", BatchNO);
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
        public string SaveBatchMasterDataToDatabase(DataTable dtHeader)
        {
            string sOutMsg = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_MASTERSYNC";
                cmd.Parameters.AddWithValue("@type", "UPLOADBATCHMASTER");
                cmd.Parameters.AddWithValue("@details", dtHeader);
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
            return sOutMsg;
        }

        #endregion

        #region Printing Window

        public DataTable dtBindBatchForCasePrinting(string sCaseNo)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LabelPrinting";
                if (sCaseNo == "1")
                {
                    cmd.Parameters.AddWithValue("@type", "BINDBATCH");
                }

              

                else if (sCaseNo == "3")
                {
                    cmd.Parameters.AddWithValue("@type", "BINDEANNO");
                }

                if (sCaseNo == "4")
                {
                    cmd.Parameters.AddWithValue("@type", "BINDBATCH");
                }

                else if (sCaseNo == "5")
                {
                    cmd.Parameters.AddWithValue("@type", "BINDBATCHcase5");
                }

                //else
                //{
                //    cmd.Parameters.AddWithValue("@type", "BINDBATCHCASE2");
                //}
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

        public DataTable GetPrintingData(string batchnumber, string sCaseNo)
        {
            string sOutMsg = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LabelPrinting";
                if (sCaseNo == "1")
                {
                    cmd.Parameters.AddWithValue("@type", "GETDATA");
                }

                if (sCaseNo == "4")
                {
                    cmd.Parameters.AddWithValue("@type", "GETDATA");
                }

                if (sCaseNo == "5")
                {
                    cmd.Parameters.AddWithValue("@type", "GETDATA For Case 5");
                }
                //else
                //{
                //    cmd.Parameters.AddWithValue("@type", "GETCASE2BATCHDATA");
                //}
                cmd.Parameters.AddWithValue("@BatchNO", batchnumber);
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
        public DataTable SavePrintingData(string SerialNumber, string sBatchNo, string sQRCode)
        {
            string sOutMsg = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LabelPrinting";
                cmd.Parameters.AddWithValue("@type", "INSERTDATA");
                cmd.Parameters.AddWithValue("@SerialNo", SerialNumber);
                cmd.Parameters.AddWithValue("@BatchNO", sBatchNo);
                cmd.Parameters.AddWithValue("@QRCode", sQRCode);
                cmd.Parameters.AddWithValue("@PrintingBy", PCommon.UserID);
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

        public DataTable SavePrintingDataCase4(string SerialNumber, string sBatchNo, string sQRCode)
        {
            string sOutMsg = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LabelPrinting";
                cmd.Parameters.AddWithValue("@type", "INSERTDATACase4");
                cmd.Parameters.AddWithValue("@SerialNo", SerialNumber);
                cmd.Parameters.AddWithValue("@BatchNO", sBatchNo);
                cmd.Parameters.AddWithValue("@QRCode", sQRCode);
                cmd.Parameters.AddWithValue("@PrintingBy", PCommon.UserID);
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

        

        public DataTable CloseRunningBatch(string sBatchNo)
        {

          
                string sOutMsg = string.Empty;
                DataTable dt = new DataTable();
                try
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = "USP_LabelPrinting";
                    cmd.Parameters.AddWithValue("@type", "CloseBatch");
                    cmd.Parameters.AddWithValue("@SerialNo", sBatchNo);
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

       

       

    

        public DataTable UpdatePrintingData()
        {
            string sOutMsg = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LabelPrinting";
                cmd.Parameters.AddWithValue("@type", "UPDATEPRINTINGDATA");
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
        public DataTable GetPrintCount(string sBatchNo)
        {
            string sOutMsg = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LabelPrinting";
                cmd.Parameters.AddWithValue("@type", "GETPRINTINGCOUNT");
                cmd.Parameters.AddWithValue("@BatchNO", sBatchNo);
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



        #endregion

    }
}
