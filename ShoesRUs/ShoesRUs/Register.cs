using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ShoesRUs
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Check if any of the input boxes are empty or not selected
            if(cmbTitle.SelectedItem == null || cmbGender.SelectedItem == null || string.IsNullOrEmpty(txtName.Text) ||
                cmbCaType.SelectedItem == null || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text) || 
                string.IsNullOrEmpty(txtPasswordConfirm.Text) || string.IsNullOrEmpty(txtDOB.Text) || string.IsNullOrEmpty(txtPhoneNo.Text) || 
                string.IsNullOrEmpty(txtAddNo.Text) || string.IsNullOrEmpty(txtAddStreet.Text) || string.IsNullOrEmpty(txtAddCity.Text) || 
                string.IsNullOrEmpty(txtAddCountry.Text) || string.IsNullOrEmpty(txtPostCode.Text) || string.IsNullOrEmpty(txtCaName.Text) ||
                string.IsNullOrEmpty(txtCaNo.Text) || string.IsNullOrEmpty(txtCaCVV.Text) || string.IsNullOrEmpty(txtCaExpiry.Text))
            {
                MessageBox.Show("One or more fields are empty.");
            } else
            {
                //Check if the email entered already exists
                if (checkEmailExists() == true)
                {
                    MessageBox.Show("This email address is already being used by another account.");
                }
                else
                {
                    //Check if the Date of Birth field is entered correctly
                    DateTime resultDOB;
                    if (DateTime.TryParseExact(txtDOB.Text, new string[] { "d-M-yyyy", "d/M/yyyy", "d.M.yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out resultDOB))
                    {
                        //Check if the Card Expiry field is entered correctly
                        DateTime resultExpiry;
                        if (DateTime.TryParseExact(txtCaExpiry.Text, new string[] { "MM-yy", "MM/yy", "MM.yy" }, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out resultExpiry))
                        {
                            //Check if Phone Number, Card Number and Card CVV input are numbers
                            if (Regex.IsMatch(txtCaNo.Text, @"^\d+$") || Regex.IsMatch(txtCaCVV.Text, @"^\d+$"))
                            {
                                if (txtPassword.Text != txtPasswordConfirm.Text)
                                {
                                    MessageBox.Show("Password doesn't match.");
                                }
                                else
                                {
                                    //Encryption for passwords
                                    Encryption ec = new Encryption();
                                    //Insert registration details into the database
                                    OleDbConnection dbCon = new OleDbConnection(DatabaseConnection.dbconnect);

                                    dbCon.ConnectionString = DatabaseConnection.dbconnect;
                                    OleDbCommand dbCmd = dbCon.CreateCommand();

                                    dbCmd.CommandText = "INSERT INTO Customer(CustomerTitle, CustomerName, CustomerDOB, CustomerGender, CustomerEmail, CustomerPhoneNo, CustomerAddressNo, CustomerAddressStreet, CustomerAddressCity, CustomerAddressCountry, CustomerPostCode, CustomerPaymentCardType, CustomerPaymentCardNo, CustomerPaymentCardCVV, CustomerPaymentCardName, CustomerPaymentCardExpDate, CustomerPassword) VALUES (@CustomerTitle, @CustomerName, @CustomerDOB, @CustomerGender, @CustomerEmail, @CustomerPhoneNo, @CustomerAddressNo, @CustomerAddressStreet, @CustomerAddressCity, @CustomerAddressCountry, @CustomerPostCode, @CustomerPaymentCardType, @CustomerPaymentCardNo, @CustomerPaymentCardCVV, @CustomerPaymentCardName, @CustomerPaymentCardExpDate, @CustomerPassword)";

                                    dbCmd.Parameters.AddWithValue("CustomerTitle", cmbTitle.SelectedItem);
                                    dbCmd.Parameters.AddWithValue("CustomerName", txtName.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerDOB", resultDOB.ToShortDateString());
                                    dbCmd.Parameters.AddWithValue("CustomerGender", cmbGender.SelectedItem);
                                    dbCmd.Parameters.AddWithValue("CustomerEmail", txtEmail.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerPhoneNo", txtPhoneNo.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerAddressNo", txtAddNo.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerAddressStreet", txtAddStreet.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerAddressCity", txtAddCity.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerAddressCountry", txtAddCountry.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerPostCode", txtPostCode.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerPaymentCardType", cmbCaType.SelectedItem);
                                    dbCmd.Parameters.AddWithValue("CustomerPaymentCardNo", txtCaNo.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerPaymentCardCVV", txtCaCVV.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerPaymentCardName", txtCaName.Text);
                                    dbCmd.Parameters.AddWithValue("CustomerPaymentCardExpDate", resultExpiry.ToShortDateString());
                                    dbCmd.Parameters.AddWithValue("CustomerPassword", ec.Encrypt(txtPassword.Text));

                                    dbCon.Open();
                                    int rowsChanged = dbCmd.ExecuteNonQuery();
                                    dbCon.Close();

                                    MessageBox.Show("Registration Successful!");
                                    clearFields();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Card Number or Card CVV is not a number.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Card Expiry field entered incorrect. Use the format MM/YY.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Date of Birth field entered incorrect. Use the format DD/MM/YYYY.");
                    }
                }
            }            
        }

        private void clearFields()
        {
            cmbTitle.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;
            cmbCaType.SelectedIndex = -1;

            txtName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPasswordConfirm.Clear();
            txtPhoneNo.Clear();
            txtAddNo.Clear();
            txtAddStreet.Clear();
            txtAddCity.Clear();
            txtAddCountry.Clear();
            txtPostCode.Clear();
            txtCaName.Clear();
            txtCaNo.Clear();
            txtCaCVV.Clear();

            txtDOB.Text = "DD/MM/YYYY";
            txtCaExpiry.Text = "MM/YY";
        }

        private bool checkEmailExists()
        {
            bool emailExists;

            OleDbConnection dbCon = new OleDbConnection(DatabaseConnection.dbconnect);

            dbCon.ConnectionString = DatabaseConnection.dbconnect;
            OleDbCommand dbCmd = dbCon.CreateCommand();

            dbCmd.CommandText = "SELECT COUNT(*) FROM Customer WHERE CustomerEmail = @CustomerEmail";
            dbCmd.Parameters.AddWithValue("CustomerEmail", txtEmail.Text);

            dbCon.Open();
            int emailCount = (int)dbCmd.ExecuteScalar();
            dbCon.Close();

            if(emailCount > 0)
            {
                emailExists = true;
            } else
            {
                emailExists = false;
            }

            return emailExists;
        }
    }
}
