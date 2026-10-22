using AppClient;
using ClsSocket;
using DTPLLogs;
using iTextSharp.text.pdf.parser;
using MascotPrintingUtility.BusinessLayer;
using MascotPrintingUtility.DataLayer;
using MascotPrintingUtility.Forms.Transaction;
using MascotPrintingUtility.PL;
using Microsoft.Office.Interop.Excel;
using Modbus.Device;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace MascotPrintingUtility.Forms.SecureView
{

    public partial class LabelPrinting : Form
    {
        #region Variable Declaration
        bool isRunning = false;
        ServerClient[] SC1 = null;
        public string sCaseNo = string.Empty;
        Queue qt = new Queue();
        Thread thFMS = null;
        object DataObj = new object();
        clsMicroscan objMS = new clsMicroscan();
        DL_DigitallinkDataResponse obj = new DL_DigitallinkDataResponse();
        Common common = new Common();
        System.Windows.Forms.Timer PingTimer = new System.Windows.Forms.Timer();
        ClientSocket_MultiSocket objPrinter = new ClientSocket_MultiSocket();
        string sVal = string.Empty;
        public int iPrinterAvailable = 0;
        public static System.Data.DataTable dtScannedBarcodeData = new System.Data.DataTable();
        static string sLastPrintedSerialNo = string.Empty;
        static string sLastQrCode = string.Empty;
        System.Data.DataTable dtPrintedBarcode = new System.Data.DataTable();

        static System.Data.DataTable dtIPDetails = new System.Data.DataTable();
        string printerIP = "192.168.1.250"; // 🔹 apna printer IP daalo
        int printerPort = 6007;


        #endregion

        #region CommonFuncation

















        #region Form Event

        private async Task HandleBatchComboLoadAsync()
        {
            try
            {
                DL_DigitallinkDataResponse objLabel = new DL_DigitallinkDataResponse();
                System.Data.DataTable dt = objLabel.dtBindBatchForCasePrinting(txtCaseNo.Text);

                if (dt.Rows.Count > 0)
                {



                    if (txtCaseNo.Text.Trim() == "1")
                    {
                        // Bind to second ComboBox if case is 2
                        blCommon.FillComboBox(cmbBatchNo, dt, true);
                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public LabelPrinting(string sCaseNo)
        {
            InitializeComponent();
            txtCaseNo.Text = sCaseNo;
            dtIPDetails.Columns.Add("IP");
            dtIPDetails.Columns.Add("Port");
            dtIPDetails.Columns.Add("Type");
            dtIPDetails.Columns.Add("Status");
            dtScannedBarcodeData.Columns.Add("Barcode");
            dtPrintedBarcode.Columns.Add("SerialNo");
            dtPrintedBarcode.Columns.Add("QRCode");
        }


        private void LabelPrinting_Load(object sender, EventArgs e)
        {

            this.MaximizeBox = false;   
 



            try
            {

                //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                //DL_IPMaster obj = new DL_IPMaster();
                //System.Data.DataTable dtPrinterData = obj.GetData1();
                //if (dtPrinterData.Rows.Count > 0)
                //{
                //    DataRow dr = dtIPDetails.NewRow();
                //    dr[0] = dtPrinterData.Rows[0][0].ToString();
                //    dr[1] = dtPrinterData.Rows[0][1].ToString();
                //    dr[2] = "Printer";
                //    dr[3] = "";
                //    dtIPDetails.Rows.Add(dr);

                 
                //}
                //if (dtIPDetails.Rows.Count > 0)
                //{
                //    dgvIPDetails.DataSource = dtIPDetails;
                //    dgvIPDetails.DefaultCellStyle.SelectionBackColor = Color.White;
                //    dgvIPDetails.DefaultCellStyle.SelectionForeColor = Color.Black; //This is the text color 

                //}
                //btnStartStop.Text = "START";
                //lblPrintCount.Text = "0";
                //lblTotalSerialCount.Text = "0";
                //lblExpDateOutput.Text = "";
                //lblMFGDateOutput.Text = "";
                HandleBatchComboLoadAsync();

                if (txtCaseNo.Text == "1")
                {
                    DL_DigitallinkDataResponse dL_DigitallinkDataResponse = new DL_DigitallinkDataResponse();
                    dL_DigitallinkDataResponse.UpdatePrintingData();
                }


              
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        private void LabelPrinting_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                blCommon.storeLogData(MethodBase.GetCurrentMethod(), "Application Closing Button Called : By User ID : " + PCommon.UserID);
                PingTimer.Interval = 2000;
                PingTimer.Enabled = false;
                PingTimer.Stop();
                isRunning = false;
                if (objPrinter != null)
                {
                    objPrinter.Close();
                }
                //if (objCamera != null)
                //{
                //    objCamera.Close();
                //}
                if (btnStartStop.Text == "STOP")
                {
                    PrinterStop();
                }
                foreach (var process in Process.GetProcessesByName("MascotPrintingUtility"))
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            }
        }
        private void cmbBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

     

                txtGtin.Text = "";
                txtMFGDate.Text = "";
                txtExpDate.Text = "";
                txtProductName.Text = "";
                txtDrugCode.Text = "";
                txtMRP.Text = "";
       
                lblExpDateOutput.Text = "";
                lblMFGDateOutput.Text = "";
    
                lblTotalSerialCount.Text = "0";
                lblPrintCount.Text = "0";
                dgvGeneratedSerialNo.DataSource = null;
                btnStartStop.Enabled = true;
                dtScannedBarcodeData.Rows.Clear();
                dtPrintedBarcode.Rows.Clear();
                if (txtCaseNo.Text == "1")
                {
                    DL_DigitallinkDataResponse dL_DigitallinkDataResponse = new DL_DigitallinkDataResponse();
                    dL_DigitallinkDataResponse.UpdatePrintingData();
                }

                if (cmbBatchNo.SelectedIndex > 0)
                {
                    System.Data.DataTable response = obj.GetPrintingData(cmbBatchNo.Text.Trim(), txtCaseNo.Text);
                    if (response != null && response.Rows.Count > 0)
                    {
                        txtProductName.Text = response.Rows[0][0].ToString();
                        txtMFGDate.Text = response.Rows[0][1].ToString();
                        txtExpDate.Text = response.Rows[0][2].ToString();
                        txtGtin.Text = response.Rows[0][3].ToString();
                        txtDrugCode.Text = response.Rows[0][4].ToString();
                        txtMRP.Text = response.Rows[0][5].ToString();
       

                        response.Columns.RemoveAt(0);
                        response.AcceptChanges();
                        response.Columns.RemoveAt(0);
                        response.AcceptChanges();
                        response.Columns.RemoveAt(0);
                        response.AcceptChanges();
                        response.Columns.RemoveAt(0);
                        response.AcceptChanges();
                        response.Columns.RemoveAt(0);
                        response.AcceptChanges();
                        response.Columns.RemoveAt(0);
                        response.AcceptChanges();
                        response.Columns.RemoveAt(0);
                        response.AcceptChanges();
                        dgvGeneratedSerialNo.DataSource = response;
                        if (dgvGeneratedSerialNo.Rows.Count > 0)
                        {
                            dgvGeneratedSerialNo.DefaultCellStyle.SelectionBackColor = Color.White;
                            dgvGeneratedSerialNo.DefaultCellStyle.SelectionForeColor = Color.Black; //This is the text color 
                        }
                        lblTotalSerialCount.Text = dgvGeneratedSerialNo.RowCount.ToString();



                        if (txtCaseNo.Text == "1")
                        {

                            System.Data.DataTable dtPrintCount = obj.GetPrintCount(cmbBatchNo.Text);
                            if (dtPrintCount.Rows.Count > 0)
                            {
                                lblPrintCount.Text = dtPrintCount.Rows.Count.ToString();
                                foreach (DataRow drtableOld1 in dtPrintCount.Rows)
                                {
                                    dtPrintedBarcode.ImportRow(drtableOld1);
                                }
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("Failed to get a  response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvGeneratedSerialNo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvGeneratedSerialNo.Columns[e.ColumnIndex].Name == "PrintedStatus")
                {
                    // Access the value of the column for the current row
                    string status = e.Value.ToString();

                    // Change row color based on the value of the "Status" column
                    if (status == "Yes")
                    {
                        dgvGeneratedSerialNo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                    }
                    else
                    {
                        dgvGeneratedSerialNo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            }
        }

  

 

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            using (TcpClient client = new TcpClient(printerIP, printerPort))
            using (NetworkStream stream = client.GetStream())
            {
                string command = "START";

                byte[] data = Encoding.ASCII.GetBytes(command);

                stream.Write(data, 0, data.Length);
                MessageBox.Show("Started");

                System.Threading.Thread.Sleep(100);
            }
           
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure to close the running batch", blCommon.sMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (btnStartStop.Text == "STOP")
                    {
                        blCommon.ShowMessage("Prining is in process, Please stop the printing to close the batch", 3);
                        return;
                    }
                }
                if (cmbBatchNo.SelectedIndex == 0)
                {
                    blCommon.ShowMessage("Plese select batch first", 3);
                    return;
                }
                blCommon.storeLogData(MethodBase.GetCurrentMethod(), "Batch Close Event Called : By User ID : " + PCommon.UserID + ", For Case No : " + txtCaseNo.Text + ", Batch No :" + cmbBatchNo.Text);
                DL_DigitallinkDataResponse dL_DigitallinkDataResponse = new DL_DigitallinkDataResponse();
                if (txtCaseNo.Text == "1")
                {
                    System.Data.DataTable dt = dL_DigitallinkDataResponse.CloseRunningBatch(cmbBatchNo.Text);
                    if (dt.Rows.Count > 0)
                    {
                        string sMessage = dt.Rows[0][0].ToString();
                        blCommon.ShowMessage(sMessage, 1);
                        blCommon.ShowMessage("Please restart the application for getting newer batched", 1);
                    }
                }

            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }



      
        
        #endregion



        #region Log Connection Pannel


        #endregion

        #region Printing section

        private async void FucntionToPrint()
        {
            string ipAddress = dtIPDetails.Rows[0][0].ToString(); ;
            int port = Convert.ToInt32(dtIPDetails.Rows[0][1].ToString());


            if (txtCaseNo.Text == "1")
                        {
                            Case1LabelPrint(ipAddress, port);
                        }
                   


                         
                    
        }
        public string ClearBufferRecord()
        {
            string count = string.Empty;
            string ipAddress = dtIPDetails.Rows[0][0].ToString(); ;
            int port;
            // Validate port number
            if (!int.TryParse(dtIPDetails.Rows[0][1].ToString(), out port))
            {
                Common.ShowMessage("Invalid printer port number", 3);
                return count; // Early return on error
            }
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                string command = "BUFFERCLEAR \r\n";
                try
                {
                    socket.Connect(ipAddress, port);
                    if (socket.Connected)
                    {
                        byte[] byteData = Encoding.ASCII.GetBytes(command);
                        socket.Send(byteData);

                        byte[] responseBuffer = new byte[1024]; // Adjust size as necessary
                        int bytesRead = socket.Receive(responseBuffer);
                        string response = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);
                    }
                    else
                    {
                        LogAndShowError("Not connected to printer.");
                    }
                }
                catch (SocketException ex)
                {
                    LogAndShowError(ex.Message);
                }
                catch (Exception ex)
                {
                    LogAndShowError(ex.Message);
                }
            }

            return count;
        }
        private async Task Case1LabelPrint(string ipAddress, int port)
        {
            int printInThisBatch = 0;

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(ipAddress, port);

                    using (NetworkStream stream = client.GetStream())
                    {
                        stream.WriteTimeout = 3000;

                   
                        string startClearCmd = "START";
                        byte[] startClearData = Encoding.ASCII.GetBytes(startClearCmd);
                        await stream.WriteAsync(startClearData, 0, startClearData.Length);
                        await Task.Delay(300);

                        foreach (DataGridViewRow row in dgvGeneratedSerialNo.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (row.Cells["PrintedStatus"].Value?.ToString() == "Yes") continue;

                           
                            sLastPrintedSerialNo = row.Cells[1].Value.ToString();
                            sLastQrCode = row.Cells[2].Value.ToString();

                            string BATCH = cmbBatchNo.Text;
                            string GTIN = txtGtin.Text;
                            string SERIAL = sLastPrintedSerialNo;
                            string MFG = lblMFGDateOutput.Text;
                            string EXP = lblExpDateOutput.Text;
                            string MRP = txtMRP.Text;
                            string QRCODE = sLastQrCode;

                           // string command1 = $"MFD|AAAAA:{BATCH}|BBBBB:{MFG}|CCCCC:{EXP}|DDDDD:{MRP}|EEEEE:{SERIAL}|FFFFF:{GTIN}|GGGGG:{QRCODE}\r";
                            string command = $"MFD|AAAAA:{QRCODE}";

                            byte[] byteData = Encoding.ASCII.GetBytes(command);

                         
                            await stream.WriteAsync(byteData, 0, byteData.Length);

                            lblPrintCount.Text = (Convert.ToInt32(lblPrintCount.Text) + 1).ToString();
                            row.Cells["PrintedStatus"].Value = "Yes";
                            row.DefaultCellStyle.BackColor = Color.LightGreen;

                            DataRow drScannigBarcode = dtPrintedBarcode.NewRow();
                            drScannigBarcode[0] = sLastPrintedSerialNo;
                            drScannigBarcode[1] = sLastQrCode;
                            dtPrintedBarcode.Rows.Add(drScannigBarcode);

                     
                            obj.SavePrintingData(SERIAL, cmbBatchNo.Text, sLastQrCode);

                            printInThisBatch++;

                            if (printInThisBatch == 30)
                            {
                                string clearCmd = "CLR";
                                byte[] clearData = Encoding.ASCII.GetBytes(clearCmd);

                                await stream.WriteAsync(clearData, 0, clearData.Length);

                                await Task.Delay(5000);

                               //printInThisBatch = 0; 
                            }

                            await Task.Delay(50);
                        }
                    }
                }

                MessageBox.Show(" Batch Printing Completed Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Printing Error: " + ex.Message);
            }
        }





        public void PrinterStop()
        {
            try
            {
                // Common.mAppLog.WriteLog("printer Stop", DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                string ipAddress = dtIPDetails.Rows[0][0].ToString();
                int port = Convert.ToInt32(dtIPDetails.Rows[0][1].ToString());
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                string Command = "Stop \r\n";
                try
                {
                    socket.Connect(ipAddress, port);
                    if (socket.Connected)
                    {
                        dgvIPDetails.Rows[1].Cells[3].Style.BackColor = Color.Green;
                        byte[] byteData = Encoding.ASCII.GetBytes(Command);
                        socket.Send(byteData);
                        byte[] responseBuffer = new byte[1024]; // Adjust size as necessary
                        int bytesRead = socket.Receive(responseBuffer);
                        string response = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);
                    }
                    else
                    {
                        dgvIPDetails.Rows[1].Cells[3].Style.BackColor = Color.Yellow;
                    }
                }
                catch (SocketException ex)
                {
                    //  Common.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                    Common.ShowMessage(ex.Message, 3);
                }
                catch (Exception ex)
                {
                    //   Common.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                    Common.ShowMessage(ex.Message, 3);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to PLC: {ex.Message}");
            }
        }

        private void LogAndShowError(string message)
        {
            // Common.mAppLog.WriteLog(message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            Common.ShowMessage(message, 3);
        }



        #endregion Printing section 

        private void button2_Click(object sender, EventArgs e)
        {
            using (TcpClient client = new TcpClient(printerIP, printerPort))
            using (NetworkStream stream = client.GetStream())
            {
                string command = "STOP";

                byte[] data = Encoding.ASCII.GetBytes(command);

                stream.Write(data, 0, data.Length);

                System.Threading.Thread.Sleep(100);
            }
        }




        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {


                using (TcpClient client = new TcpClient(printerIP, printerPort))
                using (NetworkStream stream = client.GetStream())
                {
                    stream.ReadTimeout = 5000;
                    stream.WriteTimeout = 5000;

                    int batchCount = 0;

                    // Start Buffer Clear
                    byte[] clr = Encoding.ASCII.GetBytes("CLR");
                    await stream.WriteAsync(clr, 0, clr.Length);
                    await Task.Delay(500);

                    foreach (DataGridViewRow row in dgvGeneratedSerialNo.Rows)
                    {
                        if (row.IsNewRow) continue;
                        if (row.Cells["PrintedStatus"].Value?.ToString() == "Yes") continue;

                        string serial1 = row.Cells[1].Value.ToString();
                        string qrCode = row.Cells[2].Value.ToString();
                        string BATCH = cmbBatchNo.Text;
                        string GTIN = txtGtin.Text;
                        string SERIAL = sLastPrintedSerialNo;
                        string MFG = lblMFGDateOutput.Text;
                        string EXP = lblExpDateOutput.Text;
                        string MRP = txtMRP.Text;



                        //string command = $"MFD|AAAAA:{qrCode}\r";
                        //string command = $"MFD|AAAAA:{BATCH}|BBBBB:{MFG}|CCCCC:{EXP}|DDDDD:{MRP}|EEEEE:{SERIAL}|FFFFF:{GTIN}|GGGGG:{QRCODE}\r";
                        string command = $"MFD|AAAAA:{BATCH}|BBBBB:{MFG}|CCCCC:{EXP}|DDDDD:{MRP}|EEEEE:{serial1}|FFFFF:{GTIN}|GGGGG:{qrCode.Replace(":", "\\\\:")}\r";
                        //string command = $"MFD|AAAAA:{qrCode.Replace(":", "\\\\:")}\r";
                        byte[] data = Encoding.ASCII.GetBytes(command);

                        await stream.WriteAsync(data, 0, data.Length);

                        row.Cells["PrintedStatus"].Value = "Yes";
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        lblPrintCount.Text = Convert.ToString(Convert.ToInt32(lblPrintCount.Text) + 1);
                        obj.SavePrintingData(serial1, cmbBatchNo.Text, qrCode);

                        batchCount++;

                        await Task.Delay(100);

                        //if (batchCount == 10)
                        //{
                        //    // Printer ko print karne ka time
                        //    await Task.Delay(5000);

                        //    // Buffer Clear
                        //    clr = Encoding.ASCII.GetBytes("CLR");
                        //    await stream.WriteAsync(clr, 0, clr.Length);

                        //    await Task.Delay(500);

                        //    batchCount = 0;
                        //}
                    }
                }

                // MessageBox.Show("Printing Completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDateFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblExpDateOutput.Text = "";
                lblMFGDateOutput.Text = "";
                if (cmbDateFormat.SelectedIndex > 0)
                {
                    if (cmbBatchNo.SelectedIndex == 0)
                    {
                        blCommon.ShowMessage("Please select batch", 3);
                        cmbDateFormat.SelectedIndex = 0;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtMFGDate.Text))
                    {
                        blCommon.ShowMessage("MFG Date not found, Please contact admin", 3);
                        cmbDateFormat.SelectedIndex = 0;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtExpDate.Text))
                    {
                        blCommon.ShowMessage("EXP Date not found, Please contact admin", 3);
                        cmbDateFormat.SelectedIndex = 0;
                        return;
                    }
                    if (cmbDateFormat.SelectedIndex == 1)
                    {
                        lblMFGDateOutput.Text = Convert.ToDateTime(txtMFGDate.Text).ToString("MMM/yyyy").ToUpper();
                        lblExpDateOutput.Text = Convert.ToDateTime(txtExpDate.Text).ToString("MMM/ yyyy").ToUpper();
                    }
                    else if (cmbDateFormat.SelectedIndex == 2)
                    {
                        lblMFGDateOutput.Text = Convert.ToDateTime(txtMFGDate.Text).ToString("MM/yyyy").ToUpper();
                        lblExpDateOutput.Text = Convert.ToDateTime(txtExpDate.Text).ToString("MM/yyyy").ToUpper();
                    }
                    else if (cmbDateFormat.SelectedIndex == 3)
                    {
                        lblMFGDateOutput.Text = Convert.ToDateTime(txtMFGDate.Text).ToString("MMM/ yy").ToUpper();
                        lblExpDateOutput.Text = Convert.ToDateTime(txtExpDate.Text).ToString("MMM/ yy").ToUpper();
                    }
                    else if (cmbDateFormat.SelectedIndex == 4)
                    {
                        lblMFGDateOutput.Text = Convert.ToDateTime(txtMFGDate.Text).ToString("MM/ yy").ToUpper();
                        lblExpDateOutput.Text = Convert.ToDateTime(txtExpDate.Text).ToString("MM/ yy").ToUpper();
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            }
        }
    }
}


#endregion