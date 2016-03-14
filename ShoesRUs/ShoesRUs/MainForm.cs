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


        // public function for adding shoes into listview
        public void ListInsert(int ID, string name)
        {
            listView.Items.Add(name, ID);
        }

        // public function for clearing list
        public void ListClear()
        {
            listView.Items.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            if(login.loggingIn(textBox1.Text, textBox2.Text) != -999)
            {
                MessageBox.Show("Logged in successfully!");
            } else
            {
                MessageBox.Show("Login credentials not found!");
            }
        }

<<<<<<< HEAD
        OleDbConnection myConn = new OleDbConnection();



        private void clearFields()
        {

            textName.Clear();
            textName.Clear();
            textEmail.Clear();
            textCustNo.Clear();
            textOrdNo.Clear();
            textSubj.Clear();
            textDescrip.Clear();

        }



        private void button2_Click_1(object sender, EventArgs e)//
        {
            clearFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)// OK button in view profile details section
        {

        }

        private void button5_Click(object sender, EventArgs e)//update address button
        {

        }

        private void button10_Click(object sender, EventArgs e)// OK button for update address section
        {

        }

        private void button11_Click(object sender, EventArgs e)//update button for update address
        {

        }

        private void button6_Click(object sender, EventArgs e)//update card details button
        {

        }

        private void button12_Click(object sender, EventArgs e)//OK button for update card details
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

=======
        private void button2_Click(object sender, EventArgs e)
        {
            ListInsert(1, "shoe1");
            // testing button
        }

        // click item in listview -> open items page
        private void listView_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
                MessageBox.Show("You clicked " + listView.SelectedItems[0].Text);
>>>>>>> origin/listview
        }
    }
