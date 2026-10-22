using DTPLLogs;
using MascotPrintingUtility.BusinessLayer;
using MascotPrintingUtility.DataLayer;
using MascotPrintingUtility.PL;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MascotPrintingUtility.Forms.SecureView
{
    public partial class DownloadMaster : Form
    {
        DL_DigitallinkDataResponse obj = new DL_DigitallinkDataResponse();
        private static readonly HttpClient client = new HttpClient();
        Common common = new Common();
        public DownloadMaster()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        #region Kunal verma : downlaod sync
        /// <summary>
        /// On Load Fucntion : default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadMaster_Load(object sender, EventArgs e)
        {
            try
            {
                lblDownloadingMessage.Visible = false;
                DownloadBatchDataFromAPI();
                HandleBatchComboLoadAsync();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }

        }

        /// <summary>
        /// Main handle function
        /// </summary>
        /// <returns></returns>
        private async Task HandleApiRequestAsync()
        {
            try
            {
                string sUserID = System.Configuration.ConfigurationManager.AppSettings["DataSyncUser"];

                string batchName = itemcomboBox.Text.Trim();

              

                var requestData = new
                {
                    UserID = sUserID,
                    BatchName = batchName
                };

                DataTable response = await MakeApiRequestAsync(requestData);

                // Remove columns that are completely null
                if (response != null && response.Columns.Count > 0)
                {
                    for (int i = response.Columns.Count - 1; i >= 0; i--)
                    {
                        bool allNull = true;
                        foreach (DataRow row in response.Rows)
                        {
                            if (row[i] != DBNull.Value && row[i] != null && !string.IsNullOrWhiteSpace(row[i].ToString()))
                            {
                                allNull = false;
                                break;
                            }
                        }
                        if (allNull)
                        {
                            response.Columns.RemoveAt(i);
                        }
                    }
                }

                if (response != null && response.Rows.Count > 0)
                {
                    if (response.Columns.Count > 14)
                        response.Columns.RemoveAt(14);

                    string Result = obj.SaveDataToDatabase(response);

                    gvSyncData.DataSource = response;

                    blCommon.storeLogData(MethodBase.GetCurrentMethod(),
                        "Sync Batch Data Called By User ID : " + PCommon.UserID + ", And batch No :" + batchName);

                    MessageBox.Show("Data saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset labels
                    lblProductName.Text = "*****";
                    lblBatchType.Text = "*****";
                    lblMFG.Text = "*****";
                    lblExp.Text = "*****";
                    lblGtin.Text = "*****";
                    lblMRP.Text = "*****";
                    lblQty.Text = "*****";
                }
                else
                {
                    MessageBox.Show("Failed to get a valid response from the API.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }



        /// <summary>
        /// Serialized digital link data request
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 

        //public static async Task<DataTable> MakeApiRequestAsync(object data)
        //{
        //    try
        //    {
        //        var jsonContent = JsonConvert.SerializeObject(data);
        //        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        //        var apiUrl = "https://api.dl.asarindia.org/API/MasterApi/GetPublicDigitalLinkSerializations";

        //        var apiResponse = await client.PostAsync(apiUrl, content);

        //        var responseString = await apiResponse.Content.ReadAsStringAsync();

        //        Console.WriteLine("API Response: " + responseString);

        //        if (apiResponse.IsSuccessStatusCode &&
        //            !string.IsNullOrWhiteSpace(responseString) &&
        //            responseString.Contains("/PS"))
        //        {
        //            DataTable dt = JsonConvert.DeserializeObject<DataTable>(responseString);

        //            // CSV Save Path
        //            string folderPath = @"D:\Mascot";

        //            if (!Directory.Exists(folderPath))
        //            {
        //                Directory.CreateDirectory(folderPath);
        //            }

        //           // string filePath = Path.Combine(folderPath, "DigitalLinkData.csv");
        //            string fileName = $"DigitalLinkData_{Guid.NewGuid()}.csv";
        //            string filePath = Path.Combine(folderPath, fileName);


        //            // Create CSV
        //            StringBuilder csv = new StringBuilder();

        //            // Header
        //            for (int i = 0; i < dt.Columns.Count; i++)
        //            {
        //                csv.Append(dt.Columns[i].ColumnName);

        //                if (i < dt.Columns.Count - 1)
        //                    csv.Append(",");
        //            }

        //            csv.AppendLine();


        //            // Rows
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                for (int i = 0; i < dt.Columns.Count; i++)
        //                {
        //                    csv.Append(row[i].ToString().Replace(",", " "));

        //                    if (i < dt.Columns.Count - 1)
        //                        csv.Append(",");
        //                }

        //                csv.AppendLine();
        //            }


        //            // Write File
        //            File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);


        //            return dt;
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
        //        return null;
        //    }
        //}
        // old lower columnonly qr
        //public static async Task<DataTable> MakeApiRequestAsync(object data)
        //{
        //    try
        //    {
        //        var jsonContent = JsonConvert.SerializeObject(data);
        //        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        //        var apiUrl = "https://api.dl.asarindia.org/API/MasterApi/GetPublicDigitalLinkSerializations";

        //        var apiResponse = await client.PostAsync(apiUrl, content);

        //        var responseString = await apiResponse.Content.ReadAsStringAsync();

        //        Console.WriteLine("API Response: " + responseString);

        //        if (apiResponse.IsSuccessStatusCode &&
        //            !string.IsNullOrWhiteSpace(responseString) &&
        //            responseString.Contains("/PS"))
        //        {
        //            // Deserialize complete API response
        //            DataTable dt = JsonConvert.DeserializeObject<DataTable>(responseString);

        //            if (dt == null)
        //                return null;

        //            // ==========================
        //            // CSV Save Path
        //            // ==========================
        //            string folderPath = @"D:\SerialNumber_File";

        //            if (!Directory.Exists(folderPath))
        //            {
        //                Directory.CreateDirectory(folderPath);
        //            }

        //            string fileName = $"DigitalLinkData_{Guid.NewGuid()}.csv";
        //            string filePath = Path.Combine(folderPath, fileName);

        //            StringBuilder csv = new StringBuilder();

        //            // Only uniqueGeneratedUrl column in CSV
        //            if (dt.Columns.Contains("uniqueGeneratedUrl").toupp();)
        //            {
        //                // Header
        //                csv.AppendLine("uniqueGeneratedUrl");

        //                // Data
        //                foreach (DataRow row in dt.Rows)
        //                {
        //                    string url = row["uniqueGeneratedUrl"]?.ToString() ?? "";

        //                    // Escape quotes if any
        //                    url = "\"" + url.Replace("\"", "\"\"") + "\"";

        //                    csv.AppendLine(url);
        //                }

        //                // Write CSV
        //                File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
        //            }
        //            else
        //            {
        //                throw new Exception("Column 'uniqueGeneratedUrl' not found in API response.");
        //            }

        //            // Return complete DataTable with all API columns
        //            return dt;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        PCommon.mAppLog.WriteLog(ex.ToString(), DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
        //        return null;
        //    }
        //}

        // qr uppercase
        public static async Task<DataTable> MakeApiRequestAsync(object data)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiUrl = "https://api.dl.asarindia.org/API/MasterApi/GetPublicDigitalLinkSerializations";

                var apiResponse = await client.PostAsync(apiUrl, content);

                var responseString = await apiResponse.Content.ReadAsStringAsync();

                Console.WriteLine("API Response: " + responseString);

                if (apiResponse.IsSuccessStatusCode &&
                    !string.IsNullOrWhiteSpace(responseString) &&
                    responseString.Contains("/PS"))
                {
                    // Deserialize complete API response
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(responseString);

                    if (dt == null)
                        return null;

                    // ==========================
                    // CSV Save Path
                    // ==========================
                    string folderPath = @"D:\SerialNumber_File";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string fileName = $"DigitalLinkData_{Guid.NewGuid()}.csv";
                    string filePath = Path.Combine(folderPath, fileName);

                    StringBuilder csv = new StringBuilder();

                    // Only uniqueGeneratedUrl column in CSV
                    if (dt.Columns.Contains("uniqueGeneratedUrl"))
                    {
                        // Header
                        csv.AppendLine("uniqueGeneratedUrl");

                        // Data
                        foreach (DataRow row in dt.Rows)
                        {
                            string url = row["uniqueGeneratedUrl"]?.ToString().ToUpper() ?? "";

                            // Escape quotes if any
                            url = "\"" + url.Replace("\"", "\"\"") + "\"";

                            csv.AppendLine(url);
                        }

                        // Write CSV
                        File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
                    }
                    else
                    {
                        throw new Exception("Column 'uniqueGeneratedUrl' not found in API response.");
                    }

                    // Return complete DataTable with all API columns
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.ToString(), DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                return null;
            }
        }



        /// <summary>
        /// Dropdown bind on load //Batch
        /// </summary>
        /// <returns></returns>
        private async Task HandleBatchComboLoadAsync()
        {
            try
            {
                DL_DigitallinkDataResponse objLabel = new DL_DigitallinkDataResponse();
                DataTable dt = await Task.Run(() => objLabel.BindSyncBatched());
                if (dt.Rows.Count > 0)
                {
                    gvSyncData.DataSource = null;
                    this.Invoke(new Action(() =>
                    {
                        blCommon.FillComboBox(itemcomboBox, dt, true);
                    }));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle batch sync request main fucntion
        /// </summary>
        /// <returns></returns>
        private async Task DownloadBatchDataFromAPI()
        {
            try
            {
                string sUserID = System.Configuration.ConfigurationManager.AppSettings["DataSyncUser"];
                var requestData = new
                {
                    UserID = sUserID,
                    batchid = 0
                };
                DataTable response = await MakeBatchmasterApiRequestAsync(requestData);
                if (response != null && response.Rows.Count > 0)
                {
                    string Result = obj.SaveBatchMasterDataToDatabase(response);
                    MessageBox.Show("Batch master Sync Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to get a valid response from the API.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Batch Api Request sub function
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<DataTable> MakeBatchmasterApiRequestAsync(object data)
        {
            try
            {
                string sUserID = System.Configuration.ConfigurationManager.AppSettings["DataSyncUser"];
                int batchid = 0;
                string apiUrl = $"https://api.dl.asarindia.org/API/MasterApi/GetBatchMasterAPI/{batchid}/{sUserID}";
                var apiResponse = await client.GetAsync(apiUrl);
                var responseString = await apiResponse.Content.ReadAsStringAsync();
               // responseString = responseString.ToUpper();
                Console.WriteLine("API Response: " + responseString);
                PCommon.mAppLog.WriteLog(responseString, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                if (apiResponse.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<DataTable>(responseString);
                }
                else
                {
                    Console.WriteLine($"API request failed with status code {apiResponse.StatusCode}. Response: {responseString}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.ToString()}");
                return null;
            }
        }

        /// <summary>
        /// Download Sync Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnUpload_Click(object sender, EventArgs e)
        {
            if (itemcomboBox.Text.Trim() == "")
            {
                blCommon.ShowMessage("Please Select Batch", 2);
                return;
            }
            DialogResult DR = MessageBox.Show("Do you want to Downlaod data?", blCommon.sMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                try
                {
                    lblDownloadingMessage.Visible = true;
                    Cursor = Cursors.WaitCursor;
                    await HandleApiRequestAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    lblDownloadingMessage.Visible = false;
                    Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Refresh Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                gvSyncData.DataSource = null;
                lblProductName.Text = "*****";
                lblBatchType.Text = "*****";
                lblMFG.Text = "*****";
                lblExp.Text = "*****";
                lblGtin.Text = "*****";
                lblMRP.Text = "*****";
                lblQty.Text = "*****";
                HandleBatchComboLoadAsync();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            }
        }
        #endregion Kunal verma : downlaod sync

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSyncBatch_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Do you want to sync the batch details from the server", blCommon.sMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    blCommon.storeLogData(MethodBase.GetCurrentMethod(), "Sync Batch Called By User ID : " + PCommon.UserID);
                    DownloadBatchDataFromAPI();
                    HandleBatchComboLoadAsync();
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void itemcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblProductName.Text = "*****";
                lblBatchType.Text = "*****";
                lblMFG.Text = "*****";
                lblExp.Text = "*****";
                lblGtin.Text = "*****";
                lblMRP.Text = "*****";
                lblQty.Text = "*****";
                if (itemcomboBox.SelectedIndex > 0)
                {
                    DataTable dt = obj.GetBatchType(itemcomboBox.Text);
                    if (dt.Rows.Count > 0)
                    {
                        lblProductName.Text = dt.Rows[0]["productcode"].ToString();
                        lblGtin.Text = dt.Rows[0]["gtin"].ToString();
                        lblMFG.Text = dt.Rows[0]["manufdate"].ToString();
                        lblMRP.Text = dt.Rows[0]["Mrp"].ToString();
                        lblExp.Text = dt.Rows[0]["expdate"].ToString();
                        lblQty.Text = dt.Rows[0]["Quantity"].ToString();

                        if (dt.Rows[0]["isSerialalized"].ToString() == "True")
                        {
                            lblBatchType.Text = "Serialized Batch";
                            btnUpload.Enabled = true;
                        }
                        else
                        {
                            lblBatchType.Text = "NON - Serialized Batch";
                            btnUpload.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
    }
}
