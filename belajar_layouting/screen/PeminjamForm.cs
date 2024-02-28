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

        private int idSelected = 0;
        public PeminjamForm()
        {
            InitializeComponent();
            this.db = new DataClassesDataContext();
            this.utils = new Utilities();
            this.PeminjamController = new PeminjamController();
            getData();
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
            string name = dataGridView1.Columns[e.ColumnIndex].Name;
            var id = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (name == "Edit")
            {
                var peminjam = this.db.peminjams.FirstOrDefault(i => i.id == int.Parse(id.ToString()));

                this.ActiveControl = null;

                namaPeminjam.Text = peminjam.nama;
                emailPeminjam.Text = peminjam.email;
                nomorTelp.Text = peminjam.noTelp;
                alamatPeminjam.Text = peminjam.alamat;
                //this.utils.message("success",namaPeminjam.Text.Length.ToString());
                this.idSelected = int.Parse(id.ToString());
                PeminjamForm peminjamForm = new PeminjamForm();
                tabControl1.SelectTab("tabPage1");
            }
            if (name == "erase")
            {
                var delete = this.db.peminjams.FirstOrDefault(i => i.id == int.Parse(id.ToString()));

                if (delete is null)
                {
                    this.utils.message("error","Gagal menghapus peminjam");
                }
                this.db.peminjams.DeleteOnSubmit(delete);
                this.db.SubmitChanges();
                this.utils.message("success","Berhasil menghapus peminjam");
                getData();
            }

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
            if (this.idSelected == 0)
            {
                this.PeminjamController.store(
                    namaPeminjam.Text,
                    emailPeminjam.Text,
                    nomorTelp.Text,
                    alamatPeminjam.Text
                 );
                getData();
                }
            else
            {
                this.PeminjamController.update(
                  this.idSelected,
                  namaPeminjam.Text,
                    emailPeminjam.Text,
                    nomorTelp.Text,
                    alamatPeminjam.Text
                );
                this.idSelected = 0;
                getData();
            }
            //tabControl1.SelectTab("tabPage2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.utils.clearText(namaPeminjam, emailPeminjam, nomorTelp);
            peminjamBaru.Clear();
            alamatPeminjam.Clear();
        }

        private void PeminjamForm_Load(object sender, EventArgs e)
        {
            
        }

        private void getData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            List<peminjam> list = this.db.peminjams.ToList();
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item.nama, item.email, item.noTelp, item.id, item.id);
            }
        }

        private void tabList_Selected(object sender, TabControlEventArgs e)
        {
            getData();
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();
        }
    }
}
