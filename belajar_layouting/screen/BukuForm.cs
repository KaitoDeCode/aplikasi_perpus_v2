using belajar_layouting.Controllers;
using belajar_layouting.Model;
using belajar_layouting.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace belajar_layouting.screen
{
    public partial class BukuForm : Form
    {
        private KategoriController kategoriController;
        private PenulisController penulisController;
        private Utilities utils;
        private DataClassesDataContext db;
        private BookController bookController;
        private int idSelected;
        public BukuForm()
        {
            InitializeComponent();
            this.kategoriController = new KategoriController();
            this.penulisController = new PenulisController();
            this.utils = new Utilities();
            this.db = new DataClassesDataContext();
            this.idSelected = 0;
            this.bookController = new BookController();
            getData();
            getDataPenulis();
            getDataBuku();
        }

        private void getData()
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            List<Kategori> list = this.kategoriController.getAll();
            foreach (var item in list)
            {
                dataGridView3.Rows.Add(item.nama, item.id, item.id);
                //comboBox1.Items.Add(item.nama);
            }
            comboBox1.Controls.Clear();
            comboBox1.DataSource = null;
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "nama";
            comboBox1.ValueMember = "id";
        }

        private void getDataPenulis()
        {
            dataGridView4.Rows.Clear();
            dataGridView4.Refresh();
            List<Penuli> list = this.penulisController.getAll();
            foreach (var item in list)
            {
                dataGridView4.Rows.Add(item.nama,item.email, item.id, item.id);
            }
            comboBox2.Controls.Clear();
            comboBox2.DataSource = null;
            comboBox2.DataSource = list;
            comboBox2.DisplayMember = "nama";
            comboBox2.ValueMember = "id";
        }

        private void getDataBuku()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            List<Buku> list = this.bookController.getAll();
            foreach (var item in list)
            {
                dataGridView2.Rows.Add(item.judul, item.kode_buku, item.Penuli.nama, item.Id, item.Id);
                //comboBox1.Items.Add(item.nama);
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //testingEntities db = new testingEntities();
            try
            {
                this.bookController.store(
                    judulBuku.Text,
                    int.Parse(kodeBuku.Text),
                    int.Parse(comboBox1.SelectedValue.ToString()),
                    int.Parse(comboBox2.SelectedValue.ToString())
                  );
                getDataBuku();
            }
            catch (Exception err)
            {MessageBox.Show(err.Message);

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.idSelected > 0)
            {
                this.kategoriController.update(this.idSelected,kategori.Text);
                this.idSelected = 0;
            }
            else
            {
                this.kategoriController.store(kategori.Text);
            }
            getData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.utils.clearText(kategori);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.idSelected > 0)
            {
                this.penulisController.update(this.idSelected, namaPenulis.Text, email_penulis.Text);
                this.idSelected = 0;
                getDataPenulis();
            }
            else
            {
                this.penulisController.store(namaPenulis.Text,email_penulis.Text);
                getDataPenulis();
            }
            this.utils.clearText(email_penulis, namaPenulis);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dataGridView3.Columns[e.ColumnIndex].Name;
            var id = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (name == "EditKategoriBtn")
            {
                kategori.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.idSelected = int.Parse(id.ToString());
            }

            if (name == "HapusKategoriBtn")
            {
                var data = this.db.Kategoris.First(i => i.id == int.Parse(id.ToString()));

                if (data == null)
                {
                    this.utils.message("error", "Kategori tidak ditemukan");
                }

                DialogResult result = MessageBox.Show("Apakah anda yakin ingin menghapus data?", "Sukses", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.db.Kategoris.DeleteOnSubmit(data);
                    this.db.SubmitChanges();
                    this.utils.message("success", "Berhasil menghapus kategori");
                    getData();
                }

            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String name = dataGridView4.Columns[e.ColumnIndex].Name.ToString();
            var id = dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (name == "editBtn")
            {
                var data = this.db.Penulis.FirstOrDefault(item => item.id == int.Parse(id.ToString()));

                namaPenulis.Text = data.nama;
                email_penulis.Text = data.email;
                this.idSelected = data.id;
            }

            if (name == "hapusBtn")
            {
                var delete = this.db.Penulis.FirstOrDefault(i => i.id == int.Parse(id.ToString()));

                if (delete is null)
                {
                    this.utils.message("error","Penulis tidak ditemukan");
                }
                DialogResult result = this.utils.konfirmasi("Apakah kamu yakin ingin menghapus penulis ?");

                if (result == DialogResult.Yes)
                {
                    this.db.Penulis.DeleteOnSubmit(delete);
                    this.db.SubmitChanges();
                    this.utils.message("success", "Berhasil Menghapus data");
                }
            getDataPenulis();

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.utils.message("success",comboBox1.SelectedItem.ToString());
            //this.utils.message("success", comboBox1.SelectedValue.ToString());
            //this.utils.message("success", comboBox1.SelectedText.ToString());

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

            private void button1_Click(object sender, EventArgs e)
            {
                richTextBox2.Text = "\n" +
                    "Buku Baru \n" +
                    "Judul: "+judulBuku.Text+ "\n" +
                    "Kode Buku: "+kodeBuku.Text+ "\n" +
                    "Kategori:" +comboBox1 +"\n" +
                    "Penulis: "+comboBox2.SelectedText.ToString() + "\n" +
                    "Tanggal Rilis: "+dateTimePicker2.Value.ToString(); 
                    
            }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
