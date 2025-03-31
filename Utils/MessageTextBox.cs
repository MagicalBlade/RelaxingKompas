using RelaxingKompas.Windows.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Utils
{
    static public class MessageTextBox
    {
        static public void Show(string str)
        {
            WindowMessageTextBox windowMessageTextBox = new WindowMessageTextBox();
            windowMessageTextBox.tb_str.Text = str;
            windowMessageTextBox.ShowDialog();            
        }
    }
}
