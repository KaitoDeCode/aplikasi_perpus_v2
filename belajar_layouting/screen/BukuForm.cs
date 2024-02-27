using belajar_layouting.Controllers;
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
    public partial class BukuForm : Form
    {
        private KategoriController kategoriController;
        private PenulisController penulisController;
        private Utilities utils;
        public BukuForm()
        {
            InitializeComponent();
            this.kategoriController = new KategoriController();
            this.penulisController = new PenulisController();
            this.utils = new Utilities();
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
            this.kategoriController.store(kategori.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.utils.clearText(kategori);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.penulisController.store(namaPenulis.Text,email_penulis.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
