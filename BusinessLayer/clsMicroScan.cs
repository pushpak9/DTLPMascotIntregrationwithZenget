using AppClient;
using DTPLLogs;
using System;
using System.Reflection;

namespace MascotPrintingUtility.BusinessLayer
{
    internal class clsMicroscan
    {
        private string _Ip { get; set; }
        public Int32 _Port { get; set; }
        public string IP
        {
            get { return _Ip; }
            set { _Ip = value; }
        }
        public Int32 PORT
        {
            get { return _Port; }
            set { _Port = value; }
        }

        private string _stx { get; set; }
        private string _etx { get; set; }
        public string STX
        {
            get { return _stx; }
            set { _stx = value; }
        }
        public string ETX
        {
            get { return _etx; }
            set { _etx = value; }
        }


        public void Connect(ServerClient SC)
        {
            try
            {
                SC.ServerIP = _Ip;
                SC.Port = _Port;
                SC.LogFile = AppDomain.CurrentDomain.BaseDirectory + "\\Log" + IP + "@" + DateTime.Now.ToString("dd_MMM_yyyy") + ".txt";
                SC.LogLevel = LoggingLevel.logInfo;
                SC.LogFileFolder = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
                SC.FilePrefix = "FMS";
                SC.SOM = _stx;
                SC.EOM = _etx;
                //TO CHECK TEST MESSAGE
                //SC.TestMessage = "<#.a>";
                SC.TestMessage = "#000??]";
                SC.DefaultThreadPriority = 50;
                //TO CHECK NO ACTIVITY OF MICROSCANNER
                //IN CASE IT GETS OFFLINE (IN SECONDS DEFAULT=3000)
                //SC.DefaultNoActivityTestPeriod = Functions.NoActivityTestPeriod;
                SC.DefaultNoActivityTestPeriod = 10000;
                //TO CHECK WHEN ERROR OCCURS (IN MILLISECONDS:DEFAULT=50)
                SC.DefaultErrorModePriority = 100;
                //SC.DefaultErrorModePriority = Functions.ErrorModePriority;
                SC.Poll = true;
                SC.Open();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
        }
        public void Disconnect(ServerClient SC)
        {
            try
            {
                if (SC == null)
                {

                }
                else
                {
                    if (SC.Connected)
                        SC.Close();
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                // throw ex;
            }
            finally
            {
                SC = null;
            }
        }
    }
}
