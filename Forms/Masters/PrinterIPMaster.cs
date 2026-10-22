using MascotPrintingUtility.BusinessLayer;
using MascotPrintingUtility.DataLayer;
using MascotPrintingUtility.PL;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace MascotPrintingUtility.Forms.Masters
{
    public partial class PrinterIPMaster : Form
    {
        public PrinterIPMaster()
        {
            InitializeComponent();
        }

        private void txtPrinterIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                blCommon.txtForIP(e);
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void txtScannerIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                blCommon.txtForIP(e);
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void txtRejectionIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                blCommon.txtForIP(e);
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void txtPrinterPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                blCommon.OnlyNumeric(e);
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void txtScannerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                blCommon.OnlyNumeric(e);
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void txtRejectionPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                blCommon.OnlyNumeric(e);
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrinterIP.Text.Trim() == "")
                {
                    blCommon.ShowMessage("Please enter Printer IP.", 1);
                    txtPrinterIP.Focus();
                }
                if (blCommon.IsValidIP(txtPrinterIP.Text) == false)
                {
                    blCommon.ShowMessage("Please enter valid Printer IP.", 1);
                    txtPrinterIP.Text = string.Empty;
                    txtPrinterIP.Focus();
                }
                else if (txtPrinterPort.Text.Trim() == "")
                {
                    blCommon.ShowMessage("Please enter printer port.", 1);
                    txtPrinterPort.Focus();
                }

                else
                {
                    DL_IPMaster obj = new DL_IPMaster();
                    PLIPMaster pLIPMaster = new PLIPMaster();
                    pLIPMaster.PrinterIP = txtPrinterIP.Text;
                    pLIPMaster.PrinterPort = Convert.ToInt32(txtPrinterPort.Text);
                    DataTable dt = obj.Save(pLIPMaster);
                    if (dt.Rows.Count > 0)
                    {
                        blCommon.storeLogData(MethodBase.GetCurrentMethod(), "IP Master Save Button Called : By User ID : " + PCommon.UserID + ", For IP : " + txtPrinterIP.Text);
                        blCommon.ShowMessage("IP setting has been saved, Please Login again.", 1);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        private void PrinterIPMaster_Load(object sender, EventArgs e)
        {
            try
            {
                DL_IPMaster obj = new DL_IPMaster();
                DataTable dt = obj.GetData1();
                if (dt.Rows.Count > 0)
                {
                    txtPrinterIP.Text = dt.Rows[0][0].ToString();
                    txtPrinterPort.Text = dt.Rows[0][1].ToString();
 
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

 

 
    }
}
