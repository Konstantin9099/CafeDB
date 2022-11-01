using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelObj = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace Cafe
{
    public partial class Cafe : Form
    {
        public int ID = 0;


        public Cafe(int ID_log)
        {
            InitializeComponent();
            Get_Info(ID_log);
            ID = ID_log;
            comboBox1.KeyPress += (sender, e) => e.Handled = true;
            comboBox2.KeyPress += (sender, e) => e.Handled = true;
            comboBox3.KeyPress += (sender, e) => e.Handled = true;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void Cafe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Функция, позволяющая отправить команду на сервер БД для оптимизации кода.
        public void do_Action(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        // Получаем из БД данные для таблиц программы и выводим их в DataGridView.
        public void Get_Info(int ID)
        {
            // Вкладка "Производство" - Таблица "Вид блюда".
            string query = "SELECT id_type AS 'Код вида блюда', name_type AS 'Вид блюда' FROM types;";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].Width = 155;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Производство" - Таблица "Меню".
            string query1 = "SELECT id_menu AS 'Код блюда', name_menu AS 'Наименование блюда', cost_menu AS 'Цена', name_type AS 'Вид блюда' FROM menu, types WHERE menu.type_menu=types.id_type ORDER BY id_menu;";
            MySqlConnection conn1 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda1 = new MySqlDataAdapter(query1, conn1);
            DataTable dt1 = new DataTable();
            try
            {
                conn1.Open();
                dataGridView2.DataSource = dt1;
                dataGridView2.ClearSelection();
                sda1.Fill(dt1);
                dataGridView2.DataSource = dt1;
                this.dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[0].Width = 70;
                this.dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[1].Width = 250;
                this.dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[2].Width = 70;
                dataGridView2.Columns[2].DefaultCellStyle.Format = "#,#.00";
                this.dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[3].Width = 120;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }


            // Вкладка "Персонал" - Таблица "Должности".
            string query2 = "SELECT id_position AS 'Код должности', name_position AS 'Наименование должности' FROM positions;";
            MySqlConnection conn2 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, conn2);
            DataTable dt2 = new DataTable();
            try
            {
                conn2.Open();
                dataGridView3.DataSource = dt2;
                dataGridView3.ClearSelection();
                sda2.Fill(dt2);
                dataGridView3.DataSource = dt2;
                dataGridView3.ClearSelection();
                dataGridView3.Columns[0].Visible = false;
                this.dataGridView3.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[1].Width = 200;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Персонал" - Таблица "Персонал".
            string query3 = "SELECT id_worker AS 'Табельный номер', fio_worker AS 'ФИО сотрудник', name_position AS 'Должность' FROM workers, positions WHERE workers.position_worker=positions.id_position ORDER BY name_position;";
            MySqlConnection conn3 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda3 = new MySqlDataAdapter(query3, conn3);
            DataTable dt3 = new DataTable();
            try
            {
                conn3.Open();
                dataGridView4.DataSource = dt3;
                dataGridView4.ClearSelection();
                sda3.Fill(dt3);
                dataGridView4.DataSource = dt3;
                dataGridView4.ClearSelection();
                dataGridView4.Columns[0].Visible = false;
                this.dataGridView4.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[1].Width = 270;                
                this.dataGridView4.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[2].Width = 210;
                dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Продажи" - Таблица "Номенклатура блюд".
            string query4 = "SELECT id_menu AS 'Код блюда', name_menu AS 'Наименование блюда', name_type AS 'Вид блюда', cost_menu AS 'Цена' FROM menu, types WHERE menu.type_menu=types.id_type;";
            MySqlConnection conn4 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda4 = new MySqlDataAdapter(query4, conn4);
            DataTable dt4 = new DataTable();
            try
            {
                conn4.Open();
                dataGridView7.DataSource = dt4;
                dataGridView7.ClearSelection();
                sda4.Fill(dt4);
                dataGridView7.DataSource = dt4;
                dataGridView7.ClearSelection();
                this.dataGridView7.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[0].Width = 60;
                this.dataGridView7.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[1].Width = 230;
                this.dataGridView7.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[2].Width = 110;
                this.dataGridView7.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[3].Width = 70;
                dataGridView7.Columns[3].DefaultCellStyle.Format = "#,#.00";
                dataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Продажи" - Таблица "Заказ клиента".
            string query5 = "select menu.id_menu AS 'Код блюда', name_menu AS 'Наименование блюда', amount AS 'Кол-во', cost_menu AS 'Цена', sum AS 'Сумма' FROM list_ord, menu WHERE list_ord.id_menu=menu.id_menu;";
            MySqlConnection conn5 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda5 = new MySqlDataAdapter(query5, conn5);
            DataTable dt5 = new DataTable();
            try
            {
                conn5.Open();
                dataGridView8.DataSource = dt5;
                dataGridView8.ClearSelection();
                sda5.Fill(dt5);
                dataGridView8.DataSource = dt5;
                dataGridView8.ClearSelection();
                this.dataGridView8.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView8.Columns[0].Width = 60;
                this.dataGridView8.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView8.Columns[1].Width = 230;
                this.dataGridView8.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView8.Columns[2].Width = 80;
                this.dataGridView8.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView8.Columns[3].Width = 80;
                //dataGridView8.Columns[3].DefaultCellStyle.Format = "#,#.00";
                this.dataGridView8.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView8.Columns[4].Width = 80;
                //dataGridView8.Columns[4].DefaultCellStyle.Format = "#,#.00";
                for (int i = 0; i < dataGridView8.Rows.Count; i++)
                {
                    dataGridView8.Rows[i].Cells[4].Value = Convert.ToInt32(dataGridView8.Rows[i].Cells[2].Value) * Convert.ToInt32(dataGridView8.Rows[i].Cells[3].Value);
                }
                dataGridView8.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn5.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Подсчет суммы заказа по таблице "Заказ клиента".
            int sum = 0;
            for (int i = 0; i < dataGridView8.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView8.Rows[i].Cells[4].Value);
            }

            textBox10.Text = sum.ToString("# ##0", System.Globalization.CultureInfo.InvariantCulture);

            // Вкладка "Продажи" - Таблица "Расчеты клиентов".
            string query6 = "SELECT id_order AS 'Код оплаты', date_order AS 'Дата', total_order AS 'Сумма оплаты', fio_worker AS 'ФИО сотрудника', name_position AS 'Должность' FROM orders, workers, positions WHERE orders.worker_order=workers.id_worker AND workers.position_worker=positions.id_position ORDER BY id_order;";
            MySqlConnection conn6 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda6 = new MySqlDataAdapter(query6, conn6);
            DataTable dt6 = new DataTable();
            try
            {
                conn6.Open();
                dataGridView9.DataSource = dt6;
                dataGridView9.ClearSelection();
                sda6.Fill(dt6);
                dataGridView9.DataSource = dt6;
                dataGridView9.ClearSelection();
                this.dataGridView9.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView9.Columns[0].Width = 60;
                this.dataGridView9.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView9.Columns[1].Width = 90;
                this.dataGridView9.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView9.Columns[2].Width = 70;
                dataGridView9.Columns[2].DefaultCellStyle.Format = "#,#.00";
                this.dataGridView9.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView9.Columns[3].Width = 220;
                this.dataGridView9.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView9.Columns[4].Width = 90;
                dataGridView8.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn5.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        // Вывод выпадающих списков в поля comboBox.
        private void Cafe_Load(object sender, EventArgs e)
        {
            // Список "Вид блюда" - таблица "Меню".
            try
            {
                string query = "SELECT * FROM  types; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("name_type"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Список "Должности" - таблица "Персонал".
            try
            {
                string query = "SELECT * FROM positions; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("name_position"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Список ФИО сотрудников - таблица "Расчеты клиентов".
            try
            {
                string query = "SELECT * FROM workers; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString("fio_worker"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ******************* ВКЛАДКА "ПРОИЗВОДСТВО" *********************
        //                      Таблица "ВИД БЛЮДА"
        // Вывод данных в текстовое поле таблицы "Вид блюда".
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
        }

        // Кнопка "Добавить" - вкладка "Производство" - таблица "Вид блюда".
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода.
            if (textBox1.Text == null || textBox1.Text == "")
                MessageBox.Show(
                    "Укажите вид блюда.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "INSERT INTO types (name_type) VALUES ('" + textBox1.Text + "'); ";
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
                    Get_Info(ID);
                    textBox1.Clear();
                }
            }
        }

        // Кнопка "Изменить" - вкладка "Производство" - таблица "Вид блюда".
        private void button2_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода.
            if (textBox1.Text == null || textBox1.Text == "")
                MessageBox.Show(
                    "Укажите вид блюда.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE types SET name_type='" + textBox1.Text + "' WHERE id_type=" + n + "; ";
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
                    Get_Info(ID);
                    textBox1.Clear();
                    
                    // Обновление выпадающего списка для поля "Вид блюда" в таблице "Меню".
                    comboBox1.Items.Clear();
                    try
                    {
                        string query1 = "SELECT * FROM  types; ";
                        MySqlConnection conn1 = DBUtils.GetDBConnection();
                        MySqlCommand cmDB1 = new MySqlCommand(query1, conn1);
                        conn1.Open();
                        MySqlCommand command1 = new MySqlCommand(query1, conn1);
                        MySqlDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            comboBox1.Items.Add(reader1.GetString("name_type"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        //                  Таблица "МЕНЮ"
        // Вывод данных в текстовые поля таблицы "Меню".
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            this.comboBox1.ForeColor = System.Drawing.Color.Blue;
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            textBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            this.textBox3.ForeColor = System.Drawing.Color.Blue;
            int cena = int.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString());
            textBox3.Text = cena.ToString("#,#.00", System.Globalization.CultureInfo.InvariantCulture);
        }

        // Выпадающий список с видом блюд в comboBox1.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id_type = "SELECT id_type FROM types where name_type='" + comboBox1.Text + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(id_type, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(id_type, conn);
                label_id_type.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Кнопка "Добавить" - вкладка "Производство" - таблица "Меню".
        private void button7_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поля ввода.
            if (comboBox1.Text == null || comboBox1.Text == "")
                MessageBox.Show(
                    "Выберете вид блюда.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox2.Text == null || textBox2.Text == "")
                MessageBox.Show(
                    "Введите название блюда.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox3.Text == null || textBox3.Text == "")
                MessageBox.Show(
                    "Введите стоимость блюда.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "insert into menu (name_menu, cost_menu, type_menu) VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + label_id_type.Text + "'); ";
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
                    Get_Info(ID);
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
        }

        // Кнопка "Изменить" - вкладка "Производство" - таблица "Меню".
        private void button8_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поля ввода.
            if (comboBox1.Text == null || comboBox1.Text == "")
                MessageBox.Show(
                    "Выберете вид блюда.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox2.Text == null || textBox2.Text == "")
                MessageBox.Show(
                    "Введите название блюда.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox3.Text == null || textBox3.Text == "")
                MessageBox.Show(
                    "Введите стоимость блюда.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    string query = "UPDATE menu SET name_menu='" + textBox2.Text + "', cost_menu='" + textBox3.Text + "', type_menu='" + label_id_type.Text + "' WHERE id_menu=" + n + "; ";
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
                    Get_Info(ID);
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
        }

        // Кнопка "Удалить" - вкладка "Производство" - таблица "Меню".
        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow is null)
            {
                MessageBox.Show("Не выбрана строка!");
                return;
            }
            string Blyudo = dataGridView2.CurrentRow.Cells[1].Value.ToString();

            DialogResult res = MessageBox.Show($"Вы уверены, что хотите удалить блюдо: {Blyudo} ?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int n = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                string del = "delete from menu where id_menu = " + n + ";";
                do_Action(del);
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи! Удаление невозможно.");
            }
            Get_Info(ID);
            textBox2.Clear();
            textBox3.Clear();
        }

        // Кнопка "Печать" - вкладка "Производство" - таблица "Меню".
        private void button10_Click(object sender, EventArgs e)
        {
            int kol = dataGridView2.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView2.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView2.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView2.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // Кнопка "Найти" - вкладка "Производство" - таблица "Меню".
        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox4.Text.ToLower()))
                        {
                            dataGridView2.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        // ******************* ВКЛАДКА "ПЕРСОНАЛ" *********************
        //                     Таблица "Должности"
        // Вывод данных в текстовые поля таблицы "Должности".
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            this.textBox5.ForeColor = System.Drawing.Color.Blue;
        }

        // Кнопка "Добавить" - вкладка "Персонал" - таблица "Должности".
        private void button12_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода должности.
            if (textBox5.Text == null || textBox5.Text == "")
                MessageBox.Show(
                    "Введите должность.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "INSERT INTO positions (name_position) VALUES ('" + textBox5.Text + "'); ";
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
                    Get_Info(ID);
                    textBox5.Clear();
                }
            }
        }

        // Кнопка "Изменить" - вкладка "Персонал" - таблица "Должности".
        private void button13_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поля ввода.
            if (textBox5.Text == null || textBox5.Text == "")
                MessageBox.Show(
                    "Выберете должность.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    string query = "UPDATE positions SET name_position='" + textBox5.Text + "' WHERE id_position=" + n + "; ";
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
                    Get_Info(ID);
                    textBox5.Clear();
                }

                // Обновление выпадающего списка для поля "Должность" в таблице "Персонал".
                comboBox2.Items.Clear();
                try
                {
                    string query = "SELECT * FROM  positions; ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader.GetString("name_position"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Кнопка "Найти" - вкладка "Персонал" - таблица "Должности".
        private void button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                dataGridView3.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                        if (dataGridView3.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox6.Text.ToLower()))
                        {
                            dataGridView3.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        // Кнопка "Печать" - вкладка "Персонал" - таблица "Должности".
        private void button15_Click(object sender, EventArgs e)
        {
            int kol = dataGridView3.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView3.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView3.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView3.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        //                     Таблица "Персонал"
        // Вывод данных в текстовые поля таблицы "Персонал"
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            this.textBox7.ForeColor = System.Drawing.Color.Blue;
            comboBox2.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            this.comboBox2.ForeColor = System.Drawing.Color.Blue;
        }

        // Выпадающий список должностей в comboBox2 для таблицы "Персонал".
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id_pos = "SELECT id_position FROM positions where name_position='" + comboBox2.Text + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(id_pos, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(id_pos, conn);
                label_id_pos.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Кнопка "Добавить" - вкладка "Персонал" - таблица "Персонал".
        private void button16_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поле ввода.
            if (textBox7.Text == null || textBox7.Text == "")
                MessageBox.Show(
                    "Введите ФИО сотрудника.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if(comboBox2.Text == null || comboBox2.Text == "")
                MessageBox.Show(
                    "Выберете должность.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "INSERT INTO workers (fio_worker, position_worker) VALUES ('" + textBox7.Text + "', '" + label_id_pos.Text + "'); ";
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
                    Get_Info(ID);
                    textBox7.Clear();
                }
            }
        }

        // Кнопка "Изменить" - вкладка "Персонал" - таблица "Персонал".
        private void button17_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поле ввода.
            if (textBox7.Text == null || textBox7.Text == "")
                MessageBox.Show(
                    "Введите ФИО сотрудника.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (comboBox2.Text == null || comboBox2.Text == "")
                MessageBox.Show(
                    "Выберете должность.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
                    string query = "UPDATE workers SET fio_worker='" + textBox7.Text + "', position_worker='" + label_id_pos.Text + "' WHERE id_worker=" + n + "; ";
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
                    Get_Info(ID);
                    textBox7.Clear();

                    // Обновление выпадающего списка для поля "Кто принял оплату" - таблица "Расчет клиентов".
                    comboBox3.Items.Clear();
                    try
                    {
                        string query1 = "SELECT * FROM workers; ";
                        MySqlConnection conn1 = DBUtils.GetDBConnection();
                        MySqlCommand cmDB1 = new MySqlCommand(query1, conn1);
                        conn1.Open();
                        MySqlCommand command1 = new MySqlCommand(query1, conn1);
                        MySqlDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            comboBox3.Items.Add(reader1.GetString("fio_worker"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        // Кнопка "Найти" - вкладка "Персонал" - таблица "Персонал".
        private void button18_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView4.RowCount; i++)
            {
                dataGridView4.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    if (dataGridView4.Rows[i].Cells[j].Value != null)
                        if (dataGridView4.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox8.Text.ToLower()))
                        {
                            dataGridView4.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        // Кнопка "Печать" - вкладка "Персонал" - таблица "Персонал".
        private void button19_Click(object sender, EventArgs e)
        {
            int kol = dataGridView4.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView4.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView4.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView4.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // ******************* ВКЛАДКА "ПРОДАЖИ" *********************

        string id;
        public Cafe(string mode, string Id)
        {
            InitializeComponent();

            if (mode == "chng")
            {
                id = Id;
            }

            Get_Info(ID);
        }

        // Кнопка "Добаить в заказ" - таблица "Номенклатура блюд".
        private void button21_Click(object sender, EventArgs e)
        {
            if (dataGridView7.CurrentCell != null)
            {
                Zakaz Zak = new Zakaz("chng", dataGridView7[0, dataGridView7.CurrentRow.Index].Value.ToString());
                Zak.label1.Text = dataGridView7.Rows[dataGridView7.CurrentCell.RowIndex].Cells[0].Value.ToString();
                Zak.textBox1.Text = dataGridView7.Rows[dataGridView7.CurrentCell.RowIndex].Cells[1].Value.ToString();
                Zak.textBox2.Text = dataGridView7.Rows[dataGridView7.CurrentCell.RowIndex].Cells[3].Value.ToString();
                Zak.Owner = this;
                Zak.Show();
            }
        }

        // Обновление таблицы "Заказ клиента" (list_ord).
        private void button3_Click(object sender, EventArgs e)
        {
            Get_Info(ID);
        }

        // Вкладка "Продажи" - Кнопка "Найти" в поисковой строке таблицы "Номенклатура блюд".
        private void button20_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView7.RowCount; i++)
            {
                dataGridView7.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView7.ColumnCount; j++)
                    if (dataGridView7.Rows[i].Cells[j].Value != null)
                        if (dataGridView7.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox9.Text.ToLower()))
                        {
                            dataGridView7.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        // Вкладка "Продажи" - Кнопка "Удалить" строку из таблицы "Заказ клиента".
        private void button22_Click(object sender, EventArgs e)
        {
            if (dataGridView8.CurrentRow is null)
            {
                MessageBox.Show("Не выбрана строка!");
                return;
            }
            string zak = dataGridView8.CurrentRow.Cells[1].Value.ToString();

            DialogResult res = MessageBox.Show($"Вы действительно хотите удалить из заказа: \n \n {zak} ?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int n = int.Parse(dataGridView8.CurrentRow.Cells[0].Value.ToString());
                string del = "delete from list_ord where id_menu = " + n + ";";
                do_Action(del);
            }
            else
            {
                MessageBox.Show("Удаление отменено!");
            }
            Get_Info(ID);
        }

        // Кнопка "Печать" - вкладка "Продажи" - таблица "расчеты клиентов".
        private void button24_Click(object sender, EventArgs e)
        {
            int kol = dataGridView9.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView9.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView9.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView9.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView9.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView9.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // Кнопка "Произвести расчет" - вкладка "Родажи" - таблица "Расчеты покупателей".
        private void button23_Click(object sender, EventArgs e)
        {
            double total_order = Convert.ToDouble(textBox10.Text);
            // Проверяем, чтобы было заполнено поле ввода.
            if (total_order == 0)
                MessageBox.Show(
                    "Не выбраны заказы.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Произвести расчет?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string Date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    string query = "insert into orders (total_order, worker_order, date_order) VALUES ('" + total_order + "', '" + label_id_work.Text + "', '" + Date + "'); ";
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
                    textBox10.Clear();
                    string del = "DELETE FROM list_ord;";
                    do_Action(del);
                    Get_Info(ID);
                }
            }
        }

        //                        Таблица "Расчеты покупателей"
        // Вывод данных в выпадающий список "Кто принял оплату".
        private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.Text = dataGridView9.CurrentRow.Cells[3].Value.ToString();
            this.comboBox1.ForeColor = System.Drawing.Color.Blue;
        }

        // Определяем id работника, принявшего оплату.
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_work = comboBox3.Text;
            try
            {
                string ID_work = "SELECT id_worker FROM workers where fio_worker='" + id_work + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(ID_work, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(ID_work, conn);
                label_id_work.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
