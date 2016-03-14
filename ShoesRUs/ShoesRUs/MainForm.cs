﻿using System;
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

        public void ListInsert(int ID, string name)
        {
            listView.Items.Add(name, ID);
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            ListInsert(1, "shoe1");
        }

        private void listView_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
                MessageBox.Show("You clicked " + listView.SelectedItems[0].Text);
        }
    }
}
