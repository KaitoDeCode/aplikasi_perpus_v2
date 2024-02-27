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
        public PeminjamForm()
        {
            InitializeComponent();
            this.db = new DataClassesDataContext();
            this.utils = new Utilities();
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
            try
            {
                peminjam newPeminjam = new peminjam
                {
                    nama = namaPeminjam.Text,
                    email = emailPeminjam.Text,
                    noTelp = nomorTelp.Text,
                    alamat = alamatPeminjam.Text,
                };
                this.db.peminjams.InsertOnSubmit(newPeminjam);
                this.db.SubmitChanges();
                this.utils.message("success", "Data peminjam berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                this.utils.message("error",ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.utils.clearText(namaPeminjam, emailPeminjam, nomorTelp);
            peminjamBaru.Clear();
            alamatPeminjam.Clear();
        }
    }
}
