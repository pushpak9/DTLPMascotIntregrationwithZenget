namespace MascotPrintingUtility.PL
{
    internal class PLIPMaster
    {
        public string PrinterIP { get; set; } = string.Empty;
        public int PrinterPort { get; set; }
        public string ScannerIP { get; set; } = string.Empty;
        public int ScannerPort { get; set; }
        public string RejectionIP { get; set; } = string.Empty;
        public int RejectionPort { get; set; }

        public int ID { get; set; }
        public string IP { get; set; } = string.Empty;
        public int PortNo { get; set; }
        public string LineCode { get; set; } = string.Empty;
        public string LineName { get; set; } = string.Empty;

 

    }
}
