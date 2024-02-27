using belajar_layouting.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace belajar_layouting.screen
{
    public partial class PeminjamForm : Form
    {
        private DataClassesDataContext db;
        public PeminjamForm()
        {
            InitializeComponent();
            this.db = new DataClassesDataContext();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            peminjamBaru.Text = "\n" +
                "SELAMAT DATANG PEMINJAM BARU \n \n" +
                "Nama   : "+namaPeminjam.Text+"\n" +
                "Email  : "+emailPeminjam.Text+"\n" +
                "NoTelp : "+nomorTelp.Text+"\n" +
                "Alamat : "+alamatPeminjam.Text;
        }
    }
}
