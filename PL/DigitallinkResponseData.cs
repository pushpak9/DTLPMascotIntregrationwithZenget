namespace MascotPrintingUtility.PL
{
    public class DigitallinkResponseData
    {
        public int Reference_ID { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SerialNumber { get; set; }
        public string Gtin13 { get; set; }
        public string Gtin14 { get; set; }
        public int BatchId { get; set; }
        public int Units { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string BatchName { get; set; }
        public string SessionId { get; set; }
        public string UniqueGeneratedUrl { get; set; }
        public string SerializationType { get; set; }
        public string WebUrl { get; set; }
        public string DownloadType { get; set; }
        public string QRCodeImage { get; set; }
    }
}
