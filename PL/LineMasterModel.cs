using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascotPrintingUtility.PL
{
    public class LineMasterModel
    {
        public string LineCode { get; set; }
        public string LineName { get; set; }
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }
        public string PrinterIP { get; set; }
        public int PrintPort { get; set; }
        public bool isPrinterAvailable { get; set; }
        public string StoperIP { get; set; }
        public int StoperPort { get; set; }
        public bool isStoperAvailable { get; set; }
    }
}
