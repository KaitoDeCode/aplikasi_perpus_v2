using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace belajar_layouting.utils
{
    internal class Utilities
    {
        
        public void Link(Form form, Panel panel)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            form.Show();
        }

        public void message(String status,String message)
        {
            if (status == "success")
            {
                MessageBox.Show(message,status,MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, status, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearText(params TextBox[] variabel)
        {
            foreach (TextBox data in variabel)
            {
                data.Text = "";
            }
        }

    }
}
