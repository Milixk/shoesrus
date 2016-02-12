using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ShoesRUs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Startup su = new Startup();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            DatabaseConnection dc = new DatabaseConnection();
            Encryption en = new Encryption();

            string join = textBox3.Text + en.Encrypt(textBox7.Text) + "'";

           // dc.insertData(textBox2.Text, textBox1.Text, join);

            MessageBox.Show("Data inserted");
        }

    }
}
