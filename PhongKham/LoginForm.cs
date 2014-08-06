﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhongKham;
using Clinic.Helpers;
using System.Data.SqlClient;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Clinic
{
    public partial class LoginForm : Form
    {
        public  int Authority;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string user = txtBoxInputMedicineNewCostIn.Text;
        //    string pass = textBox2.Text;

        //    string strCommand = "Select Authority From ClinicUser Where Username = " +Helper.ConvertToSqlString(user) + " And Password1 = " + Helper.ConvertToSqlString(Helper.Encrypt(pass));
        //    SqlCommand comm = new SqlCommand(strCommand,Program.conn);
        //    SqlDataReader reader = comm.ExecuteReader();
        //    reader.Read();
        //    if (reader.HasRows)
        //    {
        //        Authority = reader.GetInt16(0);
        //        reader.Close();

        //        this.DialogResult = DialogResult.OK;
        //        this.Close();

        //    }
        //    else
        //    {

        //        MessageBox.Show("Sai tên hoặc password");
        //    }
        //    reader.Close();

        //}

        private void button1_ClickMySql(object sender, EventArgs e)
        {
            string user = txtBoxInputMedicineNewCostIn.Text;
            string pass = textBox2.Text;

            string strCommand = "Select Authority From ClinicUser Where Username = " + Helper.ConvertToSqlString(user) + " And Password1 = " + Helper.ConvertToSqlString(Helper.Encrypt(pass));
            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                Authority = reader.GetInt16(0);
                reader.Close();

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {

                MessageBox.Show("Sai tên hoặc password");
            }
            reader.Close();

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_ClickMySql(sender,e);
            }
        }
    }
}