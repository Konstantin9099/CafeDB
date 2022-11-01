using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cafe
{
    public partial class Zakaz : Form
    {
        public Cafe fm { get; set; }

        public Zakaz(Cafe fm)
        {
            InitializeComponent();
            this.fm = fm;
        }

        void do_Action(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!");
            }
        }

        string id;
        public Zakaz(string mode, string Id)
        {
            InitializeComponent();

            if (mode == "chng")
            {
                id = Id;
            }
        }

        // Кнопка "Назад".
        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        // Кнопка "Сохранить".
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было введено количество.
            if (textBox3.Text == $"{""}")
                MessageBox.Show(
                    "Введите количество.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Проверьте количество и подтвердите действие.", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "INSERT INTO list_ord (id_menu, amount) VALUES ('" + label1.Text + "', '" + textBox3.Text + "'); ";
                    // INSERT INTO list_ord (id_menu, amount) VALUES (15, '3');
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                }
            }
        }

        // Запрет на ввод символов.
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }              
        }

    }
}
