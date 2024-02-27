using belajar_layouting.screen;
using belajar_layouting.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace belajar_layouting
{
    public partial class DashboardForm : Form
    {
        private Utilities utils;
        public DashboardForm()
        {
            InitializeComponent();
            this.utils = new Utilities();
            PeminjamForm peminjam = new PeminjamForm();
            this.utils.Link(peminjam, contentPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeminjamForm peminjam = new PeminjamForm();
            this.utils.Link(peminjam, contentPanel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BukuForm buku = new BukuForm();
            this.utils.Link(buku, contentPanel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SewaForm sewa = new SewaForm();
            this.utils.Link(sewa, contentPanel);
        }
    }
}
