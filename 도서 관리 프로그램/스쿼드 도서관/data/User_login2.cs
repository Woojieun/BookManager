﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 스쿼드_도서관
{
    public partial class User_login2 : Form
    {
        public User_login2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=qkrwltn5130!";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("select * from squad_library.mydata where 아이디 = '" + textBox1.Text + "' and 비밀번호='" + textBox2.Text + "'", myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    Userunregister ug = new Userunregister();
                    ug.textBox1.Text = this.textBox2.Text;
                    MessageBox.Show("로그인 성공");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("다시 로그인하세요.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            User_Homepage2 uh2 = new User_Homepage2();
            uh2.Show();

        }
        private string GetString(int v)
        {
            throw new NotImplementedException();
        }

        private void User_login2_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_login1 ul1 = new User_login1();
            ul1.Show();
        }
    }
}
