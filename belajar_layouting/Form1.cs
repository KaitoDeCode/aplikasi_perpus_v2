
using belajar_layouting.Model;
using belajar_layouting.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace belajar_layouting
{
    public partial class Form1 : Form
    {
        private DataClassesDataContext db;
        private Utilities utils;
        public Form1()
        {
            this.db = new DataClassesDataContext();
            this.utils = new Utilities();
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    var test = this.db.users.FirstOrDefault(
                        item =>
                        item.username == Username.Text &&
                        item.password == Password.Text
                    );
                   // if (test is null)
                    //{
                        //this.utils.message("error", "Gagal Login");
                      //  return;
                    //}
                    //else {
                     //   this.utils.message("success","Berhasil Login");
                    //}
                    DashboardForm dash = new DashboardForm();
                    dash.Show();
                    this.Hide();
            }
            catch(Exception err)
            {
                this.utils.message("error", err.Message);
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
