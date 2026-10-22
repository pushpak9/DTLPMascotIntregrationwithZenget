using MascotPrintingUtility.BusinessLayer;
using MascotPrintingUtility.Forms.Masters;
using MascotPrintingUtility.Forms.Transaction;
using DTPLLogs;
using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MascotPrintingUtility.Forms.SecureView
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
           // modalCaseConfirmation.Hide();
            this.WindowState = FormWindowState.Maximized;
        }

        //Downalod Master Page
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                blCommon.storeLogData(MethodBase.GetCurrentMethod(), "Download Sync Button Called : By User ID : " + PCommon.UserID);
                DownloadMaster downloadmaster = new DownloadMaster();
                downloadmaster.Show();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }

        }
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                blCommon.storeLogData(MethodBase.GetCurrentMethod(), "Application Exit Button Called : By User ID : " + PCommon.UserID);
                Application.Exit();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                 
               PrinterIPMaster configmaster = new PrinterIPMaster();
                configmaster.Show();
                 blCommon.storeLogData(MethodBase.GetCurrentMethod(), "IP Configure Button (PrinterIPMaster) Called : By User ID : " + PCommon.UserID);
                
                
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void BtnCase1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure to run the case 1 : Serialzed barcode Printing and verification", blCommon.sMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    blCommon.storeLogData(MethodBase.GetCurrentMethod(), "Case 1 Button Called : By User ID : " + PCommon.UserID);
                    //SendCommandToCameraForReadingInitalize("1");
                    //this.Hide();
                   // modalCaseConfirmation.Hide();
                    LabelPrinting obj = new LabelPrinting("1");
                    obj.Show();
                    
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

     
    

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                blCommon.storeLogData(MethodBase.GetCurrentMethod(), "Download Sync Button Called : By User ID : " + PCommon.UserID);
                DownloadMaster downloadmaster = new DownloadMaster();
                downloadmaster.Show();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                PrinterIPMaster configmaster = new PrinterIPMaster();
                configmaster.Show();
                blCommon.storeLogData(MethodBase.GetCurrentMethod(), "IP Configure Button (PrinterIPMaster) Called : By User ID : " + PCommon.UserID);


            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                blCommon.storeLogData(MethodBase.GetCurrentMethod(), "Application Exit Button Called : By User ID : " + PCommon.UserID);
                Application.Exit();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure to run the case 1 : Serialzed barcode Printing and verification", blCommon.sMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    blCommon.storeLogData(MethodBase.GetCurrentMethod(), "Case 1 Button Called : By User ID : " + PCommon.UserID);
                    //SendCommandToCameraForReadingInitalize("1");
                    //this.Hide();
                    // modalCaseConfirmation.Hide();
                    LabelPrinting obj = new LabelPrinting("1");
                    obj.Show();

                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            panel1.Hide();
        }
    }
}
