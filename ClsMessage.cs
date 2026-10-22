using System.Windows.Forms;

namespace MascotPrintingUtility
{

    class ClsMessage
    {

        public static DialogResult ShowInfo(string Msg)
        {
            return MessageBox.Show(Msg, " Information.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowWarning(string Msg)
        {
            return MessageBox.Show(Msg, "Warning.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowError(string Msg)
        {
            return MessageBox.Show(Msg, " Error.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowConfimation(string Msg)
        {
            return MessageBox.Show(Msg, " Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
    }
}
