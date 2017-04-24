using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;

namespace FTPClient
{
    public partial class Enter : MetroForm
    {

        Color curentBack;
        Color curentFont;
        public Enter()
        {
            InitializeComponent();
            this.ControlBox = false;
            button3.ForeColor = Color.Red;
            curentBack = textBox2.BackColor;
            curentFont = textBox2.ForeColor;
            textBox6.PasswordChar = '*';
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            textBox5.Text = "Gloomy";
            textBox6.Text = "97072253";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    SqlConnection conect = new SqlConnection(@"Data Source=DESKTOP-ABEM0TK\GLOOMY;Integrated Security=True;");
                    string str = "insert into Users(login,password) values('"
                        + textBox1.Text
                        + "','"
                        + textBox2.Text
                        + "')";
                    conect.Open();
                    SqlCommand sqlcmd = new SqlCommand(str, conect);
                    sqlcmd.ExecuteNonQuery();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Реєстрація проведена успішно");

                }
                else
                {
                    textBox2.ForeColor = Color.Black;
                    textBox3.ForeColor = Color.Black;
                    textBox2.BackColor = Color.Red;
                    textBox3.BackColor = Color.Red;
                }
            }
            else
            {
                textBox2.ForeColor = Color.Black;
                textBox3.ForeColor = Color.Black;
                textBox2.BackColor = Color.Red;
                textBox3.BackColor = Color.Red;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conect = new SqlConnection(@"Data Source=DESKTOP-ABEM0TK\GLOOMY;Integrated Security=True;");
            try
            {

                string str = "select login,password from Users where login='"
                    + textBox5.Text +
                    "' and password='" 
                    + textBox6.Text
                    + "' ";
                SqlCommand cmd = new SqlCommand(str, conect);
                SqlDataAdapter da = new SqlDataAdapter(str, conect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Не коректний логін або пароль", "error");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет подключения к базе даных");

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Недоступный тип");
            }
            finally
            {
                conect.Close();
                //   Application.Exit();
            }
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = curentFont;
            textBox3.ForeColor = curentFont;
            textBox2.BackColor = curentBack;
            textBox3.BackColor = curentBack;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }       
    }
}
