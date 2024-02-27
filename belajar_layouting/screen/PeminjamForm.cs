using belajar_layouting.Controllers;
using belajar_layouting.Model;
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

namespace belajar_layouting.screen
{
    public partial class PeminjamForm : Form
    {
        private DataClassesDataContext db;
        private Utilities utils;
        private PeminjamController PeminjamController;
        public PeminjamForm()
        {
            InitializeComponent();
            this.db = new DataClassesDataContext();
            this.utils = new Utilities();
            this.PeminjamController = new PeminjamController();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.utils.clearText(namaPeminjam,emailPeminjam,nomorTelp);
            peminjamBaru.Clear();
            alamatPeminjam.Clear();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.PeminjamController.store(
                namaPeminjam.Text,
                emailPeminjam.Text,
                nomorTelp.Text,
                alamatPeminjam.Text
             );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.utils.clearText(namaPeminjam, emailPeminjam, nomorTelp);
            peminjamBaru.Clear();
            alamatPeminjam.Clear();
        }
    }
}
