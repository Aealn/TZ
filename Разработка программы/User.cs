using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Text.RegularExpressions;

namespace Picture
{
    public partial class User : Form
    {
        Basa db;
        Point location = new Point(15, 60);
        //Size size = new Size(650, 550);
        Color c = Color.FromArgb(216, 191, 216);
        public User()
        {
            InitializeComponent();

            db = new Basa();

            this.Size = new Size(1000, 550);

            panel1.Parent = this;
            panel2.Parent = this;
            panel3.Parent = this;
            panel4.Parent = this;
            panel5.Parent = this;
            panel6.Parent = this;
            panel7.Parent = this;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

            panel1.Location = location;
            panel2.Location = location;
            panel3.Location = location;
            panel4.Location = location;
            panel5.Location = location;
            panel6.Location = location;
            panel7.Location = location;

            //panel1.Size = size;
            //panel2.Size = size;
            //panel3.Size = size;
            //panel4.Size = size;
            //panel5.Size = size;
            //panel6.Size = size;

            panel1.BackColor = c;
            panel2.BackColor = c;
            panel3.BackColor = c;
            panel4.BackColor = c;
            panel5.BackColor = c;
            panel6.BackColor = c;
            panel7.BackColor = c;

            label_fio_author3.Visible = false;
            textBox_fio_author3.Visible = false;

            label_name_picture4.Visible = false;
            textBox_name_picture4.Visible = false;

            label_fio_user2.Visible = false;
            textBox_fio_user2.Visible = false;

            label_date_ot.Visible = false;
            textBox_date_ot.Visible = false;

            label_date_do.Visible = false;
            textBox_date_do.Visible = false;
        }

        private void User_Load(object sender, EventArgs e)
        {
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);

            this.dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);
            this.dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);

            this.dataGridView3.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);
            this.dataGridView3.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);

            this.dataGridView4.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);
            this.dataGridView4.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);

            this.dataGridView5.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);
            this.dataGridView5.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);

            this.dataGridView6.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);
            this.dataGridView6.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);

            this.dataGridView7.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);
            this.dataGridView7.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 10);

            comboBox_report.Items.Add("Отчет о проданных картинах");
            comboBox_report.Items.Add("Отчет о проданных картинах по автору");
            comboBox_report.Items.Add("Отчет о проданных картинах по названию");
            comboBox_report.Items.Add("Отчет о проданных картинах по сотруднику");
            comboBox_report.Items.Add("Отчет о проведенных выставках за период");

            comboBox_report.DropDownStyle = ComboBoxStyle.DropDownList;

            ShowPicture();
            ShowAuthor();
            ShowExhibitions();
            ShowJanre();
            ShowBoughtMainer();
            ShowRashod();

            ShowAuthorTextBox();//textbox_fio_author на panel1 и textbox_fio_author3 на panel7
            ShowJanreTextBox();//textBox_name_janre на panel1
            ShowExhibitionsTextBox();//для textBox_name_exhibitions на panel1
            ShowMuseumTextBox();//textbox_name_museum2 на panel3
            ShowUserTextBox();//textBox_fio_user на panel6
            ShowBoughtMainerTextBox();//textBox__fio_bought_mainer2 на panel6
            ShowPictureTextBox();//textBox_name_picture2 на panel6 и textBox_name_picture4 на panel7
        }
        private void ShowPicture()
        {
            dataGridView1.Rows.Clear();
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT id_picture, name_picture, year_create_picture, (SELECT fio_author FROM author WHERE author.id_author = picture.id_author),(SELECT name_janre FROM janre WHERE janre.id_janre = picture.id_janre),(SELECT name_exhibitions FROM exhibitions WHERE exhibitions.id_exhibitions = picture.id_exhibitions )  FROM pic.picture;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[6]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();

            }

            reader.Close();

            db.CloseConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        private void ShowAuthor()
        {
            dataGridView2.Rows.Clear();
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT * FROM author;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }

            reader.Close();

            db.CloseConnection();

            foreach (string[] s in data)
                dataGridView2.Rows.Add(s);
        }
        private void ShowMuseumTextBox()
        {
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT name_museum FROM museum;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            AutoCompleteStringCollection s = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                s.Add(reader[0].ToString());
            }

            reader.Close();

            db.CloseConnection();
            textBox_name_museum2.AutoCompleteCustomSource = s;
            textBox_name_museum2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_name_museum2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void ShowExhibitions()
        {
            dataGridView3.Rows.Clear();
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT id_exhibitions, name_exhibitions, date_start, date_end, sold_places, price_exhibitions, (SELECT name_museum FROM museum WHERE museum.id_museum = exhibitions.id_museum) FROM exhibitions;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();

            }

            reader.Close();

            db.CloseConnection();

            foreach (string[] s in data)
                dataGridView3.Rows.Add(s);
        }
        private void ShowJanre()
        {
            dataGridView4.Rows.Clear();
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT * FROM janre;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }

            reader.Close();

            db.CloseConnection();

            foreach (string[] s in data)
                dataGridView4.Rows.Add(s);
        }
        private void ShowAuthorTextBox()
        {
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT fio_author FROM author;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            AutoCompleteStringCollection s = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                s.Add(reader[0].ToString());
            }

            reader.Close();

            db.CloseConnection();
            textBox_fio_author.AutoCompleteCustomSource = s;
            textBox_fio_author.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_fio_author.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textBox_fio_author3.AutoCompleteCustomSource = s;
            textBox_fio_author3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_fio_author3.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void ShowJanreTextBox()
        {
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT name_janre FROM janre;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            AutoCompleteStringCollection s = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                s.Add(reader[0].ToString());
            }

            reader.Close();

            db.CloseConnection();
            textBox_name_janre.AutoCompleteCustomSource = s;
            textBox_name_janre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_name_janre.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void ShowExhibitionsTextBox()
        {
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT name_exhibitions FROM exhibitions;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            AutoCompleteStringCollection s = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                s.Add(reader[0].ToString());
            }

            reader.Close();

            db.CloseConnection();
            textBox_name_exhibitions.AutoCompleteCustomSource = s;
            textBox_name_exhibitions.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_name_exhibitions.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void ShowBoughtMainer()
        {
            dataGridView5.Rows.Clear();
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT id_bought_mainer, fio_bought_mainer, contact_bought_mainer  FROM pic.bought_mainer;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();

            }

            reader.Close();

            db.CloseConnection();

            foreach (string[] s in data)
                dataGridView5.Rows.Add(s);
        }
        private void ShowRashod()
        {
            dataGridView6.Rows.Clear();
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT id_rashod, (SELECT fio_user FROM user WHERE user.id_user = rashod.id_user), (SELECT fio_bought_mainer FROM bought_mainer WHERE bought_mainer.id_bought_mainer = rashod.id_bought_mainer), (SELECT name_picture FROM picture WHERE picture.id_picture = rashod.id_picture), cost_rashod FROM pic.rashod;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();

            }

            reader.Close();

            db.CloseConnection();

            foreach (string[] s in data)
                dataGridView6.Rows.Add(s);
        }
        private void ShowUserTextBox()
        {
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT fio_user FROM user;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            AutoCompleteStringCollection s = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                s.Add(reader[0].ToString());
            }

            reader.Close();

            db.CloseConnection();
            textBox_fio_user.AutoCompleteCustomSource = s;
            textBox_fio_user.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_fio_user.AutoCompleteSource = AutoCompleteSource.CustomSource;


            textBox_fio_user2.AutoCompleteCustomSource = s;
            textBox_fio_user2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_fio_user2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void ShowBoughtMainerTextBox()
        {
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT fio_bought_mainer FROM bought_mainer;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            AutoCompleteStringCollection s = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                s.Add(reader[0].ToString());
            }

            reader.Close();

            db.CloseConnection();
            textBox__fio_bought_mainer2.AutoCompleteCustomSource = s;
            textBox__fio_bought_mainer2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox__fio_bought_mainer2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void ShowPictureTextBox()
        {
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT name_picture FROM picture;";

            DataTable dt = new DataTable();

            db.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            msda.SelectCommand = command;
            msda.Fill(dt);

            MySqlDataReader reader = command.ExecuteReader();
            AutoCompleteStringCollection s = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                s.Add(reader[0].ToString());
            }

            reader.Close();

            db.CloseConnection();
            textBox_name_picture2.AutoCompleteCustomSource = s;
            textBox_name_picture2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_name_picture2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textBox_name_picture4.AutoCompleteCustomSource = s;
            textBox_name_picture4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_name_picture4.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.Show();
        }

        private void button_picture_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

        }

        private void button_add_picture_Click(object sender, EventArgs e)
        {
            if (textBox_name_picture.Text != "" && textBox_year_create_picture.Text != "" && textBox_fio_author.Text != "" && textBox_name_janre.Text != "" && textBox_name_exhibitions.Text != "")
            {
                db.OpenConnection();

                string procedure_name = "insert_picture";
                MySqlCommand comm_Add = new MySqlCommand(procedure_name, db.GetConnection());
                comm_Add.CommandType = CommandType.StoredProcedure;

                MySqlParameter n_p = new MySqlParameter
                {
                    ParameterName = "n_p",
                    Value = textBox_name_picture.Text
                };
                MySqlParameter y_c_p = new MySqlParameter
                {
                    ParameterName = "y_c_p",
                    Value = textBox_year_create_picture.Text
                };
                MySqlParameter f_a = new MySqlParameter
                {
                    ParameterName = "f_a",
                    Value = textBox_fio_author.Text
                };
                MySqlParameter n_j = new MySqlParameter
                {
                    ParameterName = "n_j",
                    Value = textBox_name_janre.Text
                };
                MySqlParameter n_e = new MySqlParameter
                {
                    ParameterName = "n_e",
                    Value = textBox_name_exhibitions.Text
                };

                comm_Add.Parameters.Add(n_p);
                comm_Add.Parameters.Add(y_c_p);
                comm_Add.Parameters.Add(f_a);
                comm_Add.Parameters.Add(n_j);
                comm_Add.Parameters.Add(n_e);

                comm_Add.ExecuteNonQuery();

                db.CloseConnection();

                ShowPicture();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_delete_picture_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы точно хотите удалить данные?", "Удаление данных", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (textBox_name_picture.Text != "" && textBox_year_create_picture.Text != "" && textBox_fio_author.Text != "" && textBox_name_janre.Text != "" && textBox_name_exhibitions.Text != "")
                {
                    db.OpenConnection();

                    string procedure_name = "delete_picture";
                    MySqlCommand comm_Del = new MySqlCommand(procedure_name, db.GetConnection());
                    comm_Del.CommandType = CommandType.StoredProcedure;

                    MySqlParameter n_p = new MySqlParameter
                    {
                        ParameterName = "n_p",
                        Value = textBox_name_picture.Text
                    };
                    MySqlParameter y_c_p = new MySqlParameter
                    {
                        ParameterName = "y_c_p",
                        Value = textBox_year_create_picture.Text
                    };
                    MySqlParameter a_i = new MySqlParameter
                    {
                        ParameterName = "a_i",
                        Value = textBox_fio_author.Text
                    };
                    MySqlParameter j_i = new MySqlParameter
                    {
                        ParameterName = "j_i",
                        Value = textBox_name_janre.Text
                    };
                    MySqlParameter e_i = new MySqlParameter
                    {
                        ParameterName = "e_i",
                        Value = textBox_name_exhibitions.Text
                    };

                    comm_Del.Parameters.Add(n_p);
                    comm_Del.Parameters.Add(y_c_p);
                    comm_Del.Parameters.Add(a_i);
                    comm_Del.Parameters.Add(j_i);
                    comm_Del.Parameters.Add(e_i);

                    comm_Del.ExecuteNonQuery();

                    db.CloseConnection();

                    ShowPicture();
                }
                else
                {
                    MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                    return;
                }
            }
            else if (dr == DialogResult.No)
            {
                return;
            }
        }
        private void button_update_picture_Click(object sender, EventArgs e)
        {
            if (textBox_name_picture.Text != "" && textBox_year_create_picture.Text != "" && textBox_fio_author.Text != "" && textBox_name_janre.Text != "" && textBox_name_exhibitions.Text != "")
            {
                db.OpenConnection();

                string procedure_name = "update_picture";
                MySqlCommand comm_Upd = new MySqlCommand(procedure_name, db.GetConnection());
                comm_Upd.CommandType = CommandType.StoredProcedure;

                string value = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                MySqlParameter id_param = new MySqlParameter
                {
                    ParameterName = "id",
                    Value = value
                };
                MySqlParameter new_n_p = new MySqlParameter
                {
                    ParameterName = "new_n_p",
                    Value = textBox_name_picture.Text
                };
                MySqlParameter new_y_c_p = new MySqlParameter
                {
                    ParameterName = "new_y_c_p",
                    Value = textBox_year_create_picture.Text//цена
                };
                MySqlParameter new_a_i = new MySqlParameter
                {
                    ParameterName = "new_a_i",
                    Value = textBox_fio_author.Text
                };
                MySqlParameter new_j_i = new MySqlParameter
                {
                    ParameterName = "new_j_i",
                    Value = textBox_name_janre.Text//цена
                };
                MySqlParameter new_e_i = new MySqlParameter
                {
                    ParameterName = "new_e_i",
                    Value = textBox_name_exhibitions.Text
                };

                comm_Upd.Parameters.Add(id_param);
                comm_Upd.Parameters.Add(new_n_p);
                comm_Upd.Parameters.Add(new_y_c_p);
                comm_Upd.Parameters.Add(new_a_i);
                comm_Upd.Parameters.Add(new_j_i);
                comm_Upd.Parameters.Add(new_e_i);

                comm_Upd.ExecuteNonQuery();

                db.CloseConnection();

                ShowPicture();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_name_picture.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox_year_create_picture.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox_fio_author.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox_name_janre.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox_name_exhibitions.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void textBox_name_picture_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name_picture.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название картины должно составлять максимально 45 символам!");
                textBox_name_picture.Clear();
                textBox_name_picture.Focus();
            }
        }

        private void textBox_year_create_picture_TextChanged(object sender, EventArgs e)
        {
            if (textBox_year_create_picture.Text.Length > 4)
            {
                MessageBox.Show("Много символов! Дата написания картины должна составлять максимально 4 символам!");
                textBox_year_create_picture.Clear();
                textBox_year_create_picture.Focus();
            }
        }

        private void textBox_year_create_picture_Enter(object sender, EventArgs e)
        {
            if (textBox_year_create_picture.Text == "гггг")
            {
                textBox_year_create_picture.Text = "";
                textBox_year_create_picture.ForeColor = Color.Black;
            }
        }

        private void textBox_year_create_picture_Leave(object sender, EventArgs e)
        {
            if (textBox_year_create_picture.Text == "")
            {
                textBox_year_create_picture.Text = "гггг";
                textBox_year_create_picture.ForeColor = Color.Gray;
            }
        }

        private void textBox_fio_author_Enter(object sender, EventArgs e)
        {
            if (textBox_fio_author.Text == "Иванов Иван Иванович")
            {
                textBox_fio_author.Text = "";
                textBox_fio_author.ForeColor = Color.Black;
            }
        }

        private void textBox_fio_author_Leave(object sender, EventArgs e)
        {
            if (textBox_fio_author.Text == "")
            {
                textBox_fio_author.Text = "Иванов Иван Иванович";
                textBox_fio_author.ForeColor = Color.Gray;
            }
        }

        private void textBox_year_create_picture_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number) || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только цифры от 0 до 9!");
                textBox_year_create_picture.Focus();
            }
        }

        private void textBox_fio_author_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_fio_author.Focus();
            }
        }

        private void textBox_fio_author_TextChanged(object sender, EventArgs e)
        {
            if (textBox_fio_author.Text.Length > 45)
            {
                MessageBox.Show("Много символов! ФИО автора должно составлять максимально 45 символам!");
                textBox_fio_author.Clear();
                textBox_fio_author.Focus();
            }
        }

        private void textBox_name_janre_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name_janre.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название жанра должно составлять максимально 45 символам!");
                textBox_name_janre.Clear();
                textBox_name_janre.Focus();
            }
        }

        private void textBox_name_exhibitions_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name_exhibitions.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название выставки должно составлять максимально 45 символам!");
                textBox_name_exhibitions.Clear();
                textBox_name_exhibitions.Focus();
            }
        }

        private void textBox_name_janre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_name_janre.Focus();
            }
        }

        private void textBox_name_exhibitions_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_name_exhibitions.Focus();
            }
        }

        private void button_author_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

        }

        private void textBox_fio_author2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_fio_author2.Text.Length > 45)
            {
                MessageBox.Show("Много символов! ФИО автора должно составлять максимально 45 символам!");
                textBox_fio_author2.Clear();
                textBox_fio_author2.Focus();
            }
        }

        private void textBox_fio_author2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_fio_author2.Focus();
            }
        }

        private void textBox_fio_author2_Enter(object sender, EventArgs e)
        {
            if (textBox_fio_author2.Text == "Иванов Иван Иванович")
            {
                textBox_fio_author2.Text = "";
                textBox_fio_author2.ForeColor = Color.Black;
            }
        }

        private void textBox_fio_author2_Leave(object sender, EventArgs e)
        {
            if (textBox_fio_author2.Text == "")
            {
                textBox_fio_author2.Text = "Иванов Иван Иванович";
                textBox_fio_author2.ForeColor = Color.Gray;
            }
        }

        private void button_add_author_Click(object sender, EventArgs e)
        {
            if (textBox_fio_author2.Text != "")
            {
                MySqlDataAdapter msda = new MySqlDataAdapter();
                string sql = "INSERT INTO author (fio_author) VALUES ('" + textBox_fio_author2.Text + "');";

                DataTable dt = new DataTable();

                db.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
                msda.SelectCommand = command;
                msda.Fill(dt);

                db.CloseConnection();

                ShowAuthor();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_delete_author_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы точно хотите удалить данные?", "Удаление данных", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string value = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter msda = new MySqlDataAdapter();
                string sql = "DELETE FROM author WHERE id_author = " + value;

                DataTable dt = new DataTable();

                db.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
                msda.SelectCommand = command;
                msda.Fill(dt);

                db.CloseConnection();

                ShowAuthor();
            }
            else if (dr == DialogResult.No)
            {
                return;
            }
        }

        private void button_update_author_Click(object sender, EventArgs e)
        {
            if (textBox_fio_author2.Text != "")
            {
                string value = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter msda = new MySqlDataAdapter();
                string sql = "UPDATE author SET fio_author = '" + textBox_fio_author2.Text + "' WHERE id_author = " + value;

                DataTable dt = new DataTable();

                db.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
                msda.SelectCommand = command;
                msda.Fill(dt);

                db.CloseConnection();

                ShowAuthor();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_fio_author2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button_exhibitions_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

        }

        private void button_add_exhibitions_Click(object sender, EventArgs e)
        {
            if (textBox_name_exhibitions2.Text != "" && textBox_date_start.Text != "" && textBox_date_end.Text != "" && textBox_sold_places.Text != "" && textBox_price_exhibitions.Text != "" && textBox_name_museum2.Text != "")
            {
                db.OpenConnection();

                string procedure_name = "insert_exhibitions";
                MySqlCommand comm_Add = new MySqlCommand(procedure_name, db.GetConnection());
                comm_Add.CommandType = CommandType.StoredProcedure;

                MySqlParameter n_e = new MySqlParameter
                {
                    ParameterName = "n_e",
                    Value = textBox_name_exhibitions2.Text
                };
                MySqlParameter d_s = new MySqlParameter
                {
                    ParameterName = "d_s",
                    Value = textBox_date_start.Text
                };
                MySqlParameter d_e = new MySqlParameter
                {
                    ParameterName = "d_e",
                    Value = textBox_date_end.Text
                };
                MySqlParameter s_p = new MySqlParameter
                {
                    ParameterName = "s_p",
                    Value = textBox_sold_places.Text
                };
                MySqlParameter p_e = new MySqlParameter
                {
                    ParameterName = "p_e",
                    Value = Convert.ToInt32(textBox_price_exhibitions.Text)//цена билета
                };
                MySqlParameter n_m = new MySqlParameter
                {
                    ParameterName = "n_m",
                    Value = textBox_name_museum2.Text
                };

                comm_Add.Parameters.Add(n_e);
                comm_Add.Parameters.Add(d_s);
                comm_Add.Parameters.Add(d_e);
                comm_Add.Parameters.Add(s_p);
                comm_Add.Parameters.Add(p_e);
                comm_Add.Parameters.Add(n_m);

                comm_Add.ExecuteNonQuery();

                db.CloseConnection();

                ShowExhibitions();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_delete_exhibitions_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы точно хотите удалить данные?", "Удаление данных", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (textBox_name_exhibitions2.Text != "" && textBox_date_start.Text != "" && textBox_date_end.Text != "" && textBox_sold_places.Text != "" && textBox_price_exhibitions.Text != "" && textBox_name_museum2.Text != "")
                {
                    db.OpenConnection();

                    string procedure_name = "delete_exhibitions";
                    MySqlCommand comm_Del = new MySqlCommand(procedure_name, db.GetConnection());
                    comm_Del.CommandType = CommandType.StoredProcedure;

                    MySqlParameter n_e = new MySqlParameter
                    {
                        ParameterName = "n_e",
                        Value = textBox_name_exhibitions2.Text
                    };
                    MySqlParameter d_s = new MySqlParameter
                    {
                        ParameterName = "d_s",
                        Value = textBox_date_start.Text
                    };
                    MySqlParameter d_e = new MySqlParameter
                    {
                        ParameterName = "d_e",
                        Value = textBox_date_end.Text
                    };
                    MySqlParameter s_p = new MySqlParameter
                    {
                        ParameterName = "s_p",
                        Value = textBox_sold_places.Text
                    };
                    MySqlParameter p_e = new MySqlParameter
                    {
                        ParameterName = "p_e",
                        Value = Convert.ToInt32(textBox_price_exhibitions.Text)//цена билета
                    };
                    MySqlParameter id_mu = new MySqlParameter
                    {
                        ParameterName = "id_mu",
                        Value = textBox_name_museum2.Text
                    };

                    comm_Del.Parameters.Add(n_e);
                    comm_Del.Parameters.Add(d_s);
                    comm_Del.Parameters.Add(d_e);
                    comm_Del.Parameters.Add(s_p);
                    comm_Del.Parameters.Add(p_e);
                    comm_Del.Parameters.Add(id_mu);

                    comm_Del.ExecuteNonQuery();

                    db.CloseConnection();

                    ShowExhibitions();
                }
                else
                {
                    MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                    return;
                }
            }
            else if (dr == DialogResult.No)
            {
                return;
            }
        }

        private void button_update_exhibitions_Click(object sender, EventArgs e)
        {
            if (textBox_name_exhibitions2.Text != "" && textBox_date_start.Text != "" && textBox_date_end.Text != "" && textBox_sold_places.Text != "" && textBox_price_exhibitions.Text != "" && textBox_name_museum2.Text != "")
            {
                db.OpenConnection();

                string procedure_name = "update_exhibitions";
                MySqlCommand comm_Upd = new MySqlCommand(procedure_name, db.GetConnection());
                comm_Upd.CommandType = CommandType.StoredProcedure;

                string value = dataGridView3.CurrentRow.Cells[0].Value.ToString();

                MySqlParameter id_param = new MySqlParameter
                {
                    ParameterName = "id",
                    Value = value
                };
                MySqlParameter new_n_e = new MySqlParameter
                {
                    ParameterName = "new_n_e",
                    Value = textBox_name_exhibitions2.Text
                };
                MySqlParameter new_d_s = new MySqlParameter
                {
                    ParameterName = "new_d_s",
                    Value = textBox_date_start.Text
                };
                MySqlParameter new_d_e = new MySqlParameter
                {
                    ParameterName = "new_d_e",
                    Value = textBox_date_end.Text
                };
                MySqlParameter new_s_p = new MySqlParameter
                {
                    ParameterName = "new_s_p",
                    Value = textBox_sold_places.Text
                };
                MySqlParameter new_p_e = new MySqlParameter
                {
                    ParameterName = "new_p_e",
                    Value = textBox_price_exhibitions.Text
                };
                MySqlParameter new_m_i = new MySqlParameter
                {
                    ParameterName = "new_m_i",
                    Value = textBox_name_museum2.Text
                };

                comm_Upd.Parameters.Add(id_param);
                comm_Upd.Parameters.Add(new_n_e);
                comm_Upd.Parameters.Add(new_d_s);
                comm_Upd.Parameters.Add(new_d_e);
                comm_Upd.Parameters.Add(new_s_p);
                comm_Upd.Parameters.Add(new_p_e);
                comm_Upd.Parameters.Add(new_m_i);

                comm_Upd.ExecuteNonQuery();

                db.CloseConnection();

                ShowExhibitions();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void textBox_name_exhibitions2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name_exhibitions2.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название выставки должно составлять максимально 45 символам!");
                textBox_name_exhibitions2.Clear();
                textBox_name_exhibitions2.Focus();
            }
        }

        private void textBox_date_start_TextChanged(object sender, EventArgs e)
        {
            if (textBox_date_start.Text.Length > 19)
            {
                MessageBox.Show("Много символов! Дата должна составлять максимально 10 символам!");
                textBox_date_start.Clear();
                textBox_date_start.Focus();
            }
        }

        private void textBox_date_start_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number) || number == 45 || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Дата заполняется гггг-мм-дд!");
                textBox_date_start.Focus();
            }
        }

        private void textBox_date_start_Enter(object sender, EventArgs e)
        {
            if (textBox_date_start.Text == "гггг-мм-дд")
            {
                textBox_date_start.Text = "";
                textBox_date_start.ForeColor = Color.Black;
            }
        }

        private void textBox_date_start_Leave(object sender, EventArgs e)
        {
            if (textBox_date_start.Text == "")
            {
                textBox_date_start.Text = "гггг-мм-дд";
                textBox_date_start.ForeColor = Color.Gray;
            }
        }

        private void textBox_date_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number) || number == 45 || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Дата заполняется гггг-мм-дд!");
                textBox_date_end.Focus();
            }
        }

        private void textBox_date_end_TextChanged(object sender, EventArgs e)
        {
            if (textBox_date_end.Text.Length > 19)
            {
                MessageBox.Show("Много символов! Дата должна составлять максимально 10 символам!");
                textBox_date_end.Clear();
                textBox_date_end.Focus();
            }
        }

        private void textBox_date_end_Enter(object sender, EventArgs e)
        {
            if (textBox_date_end.Text == "гггг-мм-дд")
            {
                textBox_date_end.Text = "";
                textBox_date_end.ForeColor = Color.Black;
            }
        }

        private void textBox_date_end_Leave(object sender, EventArgs e)
        {
            if (textBox_date_end.Text == "")
            {
                textBox_date_end.Text = "гггг-мм-дд";
                textBox_date_end.ForeColor = Color.Gray;
            }
        }

        private void textBox_sold_places_TextChanged(object sender, EventArgs e)
        {
            if (textBox_sold_places.Text.Length > 5)
            {
                MessageBox.Show("Много символов! Колчество проданных билетов должна составлять максимально 5 символам!");
                textBox_sold_places.Clear();
                textBox_sold_places.Focus();
            }
        }

        private void textBox_sold_places_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number) || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только цифры от 0 до 9!");
                textBox_sold_places.Focus();
            }
        }

        private void textBox_price_exhibitions_TextChanged(object sender, EventArgs e)
        {
            if (textBox_price_exhibitions.Text.Length > 4)
            {
                MessageBox.Show("Много символов! Цена билетов должна составлять максимально 4 символам!");
                textBox_price_exhibitions.Clear();
                textBox_price_exhibitions.Focus();
            }
        }

        private void textBox_price_exhibitions_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number) || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только цифры от 0 до 9!");
                textBox_price_exhibitions.Focus();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_name_exhibitions2.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox_date_start.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox_date_end.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox_sold_places.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox_price_exhibitions.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox_name_museum2.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button_janre_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_name_janre2.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void textBox_name_janre2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name_janre2.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название жанра должно составлять максимально 45 символам!");
                textBox_name_janre2.Clear();
                textBox_name_janre2.Focus();
            }
        }

        private void textBox_name_janre2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_name_janre2.Focus();
            }
        }

        private void button_add_janre_Click(object sender, EventArgs e)
        {
            if (textBox_name_janre2.Text != "")
            {
                MySqlDataAdapter msda = new MySqlDataAdapter();
                string sql = "INSERT INTO janre (name_janre) VALUES ('" + textBox_name_janre2.Text + "');";

                DataTable dt = new DataTable();

                db.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
                msda.SelectCommand = command;
                msda.Fill(dt);

                db.CloseConnection();

                ShowJanre();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_delete_janre_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы точно хотите удалить данные?", "Удаление данных", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string value = dataGridView4.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter msda = new MySqlDataAdapter();
                string sql = "DELETE FROM janre WHERE id_janre = " + value;

                DataTable dt = new DataTable();

                db.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
                msda.SelectCommand = command;
                msda.Fill(dt);

                db.CloseConnection();

                ShowJanre();
            }
            else if (dr == DialogResult.No)
            {
                return;
            }
        }

        private void button_update_janre_Click(object sender, EventArgs e)
        {
            if (textBox_name_janre2.Text != "")
            {
                string value = dataGridView4.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter msda = new MySqlDataAdapter();
                string sql = "UPDATE janre SET name_janre = '" + textBox_name_janre2.Text + "' WHERE id_janre = " + value;

                DataTable dt = new DataTable();

                db.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
                msda.SelectCommand = command;
                msda.Fill(dt);

                db.CloseConnection();

                ShowJanre();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_bought_mainer_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
        }

        private void textBox_fio_bought_mainer_TextChanged(object sender, EventArgs e)
        {
            if (textBox_fio_bought_mainer.Text.Length > 45)
            {
                MessageBox.Show("Много символов! ФИО покупателя должно составлять максимально 45 символам!");
                textBox_fio_bought_mainer.Clear();
                textBox_fio_bought_mainer.Focus();
            }
        }

        private void textBox_fio_bought_mainer_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_fio_bought_mainer.Focus();
            }
        }

        private void textBox_fio_bought_mainer_Enter(object sender, EventArgs e)
        {
            if (textBox_fio_bought_mainer.Text == "Иванов Иван Иванович")
            {
                textBox_fio_bought_mainer.Text = "";
                textBox_fio_bought_mainer.ForeColor = Color.Black;
            }
        }

        private void textBox_fio_bought_mainer_Leave(object sender, EventArgs e)
        {
            if (textBox_fio_bought_mainer.Text == "")
            {
                textBox_fio_bought_mainer.Text = "Иванов Иван Иванович";
                textBox_fio_bought_mainer.ForeColor = Color.Gray;
            }
        }

        private void textBox_contact_bought_mainer_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number) || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только цифры от 0 до 9!");
                textBox_contact_bought_mainer.Focus();
            }
        }

        private void textBox_contact_bought_mainer_TextChanged(object sender, EventArgs e)
        {
            if (textBox_contact_bought_mainer.Text.Length > 11)
            {
                MessageBox.Show("Много символов! Контакт должен составлять максимально 11 символам!");
                textBox_contact_bought_mainer.Clear();
                textBox_contact_bought_mainer.Focus();
            }
        }

        private void textBox_contact_bought_mainer_Enter(object sender, EventArgs e)
        {
            if (textBox_contact_bought_mainer.Text == "8**********")
            {
                textBox_contact_bought_mainer.Text = "";
                textBox_contact_bought_mainer.ForeColor = Color.Black;
            }
        }

        private void textBox_contact_bought_mainer_Leave(object sender, EventArgs e)
        {
            if (textBox_contact_bought_mainer.Text == "")
            {
                textBox_contact_bought_mainer.Text = "8**********";
                textBox_contact_bought_mainer.ForeColor = Color.Gray;
            }
        }

        private void button_add_bought_mainer_Click(object sender, EventArgs e)
        {
            if (textBox_fio_bought_mainer.Text != "" && textBox_contact_bought_mainer.Text != "")
            {
                MySqlDataAdapter msda = new MySqlDataAdapter();
                string sql = "INSERT INTO bought_mainer (fio_bought_mainer, contact_bought_mainer) VALUES ('" + textBox_fio_bought_mainer.Text + "', '" + textBox_contact_bought_mainer.Text + "');";

                DataTable dt = new DataTable();

                db.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
                msda.SelectCommand = command;
                msda.Fill(dt);

                db.CloseConnection();

                ShowBoughtMainer();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_delete_bought_mainer_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы точно хотите удалить данные?", "Удаление данных", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string value = dataGridView5.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter msda = new MySqlDataAdapter();
                string sql = "DELETE FROM bought_mainer WHERE id_bought_mainer = " + value;

                DataTable dt = new DataTable();

                db.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
                msda.SelectCommand = command;
                msda.Fill(dt);

                db.CloseConnection();

                ShowBoughtMainer();
            }
            else if (dr == DialogResult.No)
            {
                return;
            }
        }

        private void button_update_bought_mainer_Click(object sender, EventArgs e)
        {
            if (textBox_fio_bought_mainer.Text != "" && textBox_contact_bought_mainer.Text != "")
            {
                string value = dataGridView5.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter msda = new MySqlDataAdapter();
                string sql = "UPDATE bought_mainer SET fio_bought_mainer = '" + textBox_fio_bought_mainer.Text + "', contact_bought_mainer = '" + textBox_contact_bought_mainer.Text + "' WHERE id_bought_mainer = " + value;

                DataTable dt = new DataTable();

                db.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
                msda.SelectCommand = command;
                msda.Fill(dt);

                db.CloseConnection();

                ShowBoughtMainer();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_rashod_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_fio_user.Text = dataGridView6.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox__fio_bought_mainer2.Text = dataGridView6.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox_name_picture2.Text = dataGridView6.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox_cost_rashod.Text = dataGridView6.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void textBox_fio_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_fio_user.Focus();
            }
        }

        private void textBox_fio_user_TextChanged(object sender, EventArgs e)
        {
            if (textBox_fio_user.Text.Length > 45)
            {
                MessageBox.Show("Много символов! ФИО пользователя должно составлять максимально 45 символам!");
                textBox_fio_user.Clear();
                textBox_fio_user.Focus();
            }
        }

        private void textBox_fio_user_Enter(object sender, EventArgs e)
        {
            if (textBox_fio_user.Text == "Иванов Иван Иванович")
            {
                textBox_fio_user.Text = "";
                textBox_fio_user.ForeColor = Color.Black;
            }
        }

        private void textBox_fio_user_Leave(object sender, EventArgs e)
        {
            if (textBox_fio_user.Text == "")
            {
                textBox_fio_user.Text = "Иванов Иван Иванович";
                textBox_fio_user.ForeColor = Color.Gray;
            }
        }

        private void textBox__fio_bought_mainer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox__fio_bought_mainer2.Focus();
            }
        }

        private void textBox__fio_bought_mainer2_TextChanged(object sender, EventArgs e)
        {
            if (textBox__fio_bought_mainer2.Text.Length > 45)
            {
                MessageBox.Show("Много символов! ФИО покупателя должно составлять максимально 45 символам!");
                textBox__fio_bought_mainer2.Clear();
                textBox__fio_bought_mainer2.Focus();
            }
        }

        private void textBox__fio_bought_mainer2_Enter(object sender, EventArgs e)
        {
            if (textBox__fio_bought_mainer2.Text == "Иванов Иван Иванович")
            {
                textBox__fio_bought_mainer2.Text = "";
                textBox__fio_bought_mainer2.ForeColor = Color.Black;
            }
        }

        private void textBox__fio_bought_mainer2_Leave(object sender, EventArgs e)
        {
            if (textBox__fio_bought_mainer2.Text == "")
            {
                textBox__fio_bought_mainer2.Text = "Иванов Иван Иванович";
                textBox__fio_bought_mainer2.ForeColor = Color.Gray;
            }
        }

        private void textBox_name_picture2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_name_picture2.Focus();
            }
        }

        private void textBox_name_picture2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name_picture2.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название картины должно составлять максимально 45 символам!");
                textBox_name_picture2.Clear();
                textBox_name_picture2.Focus();
            }
        }

        private void textBox_cost_rashod_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number) || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только цифры от 0 до 9!");
                textBox_cost_rashod.Focus();
            }
        }

        private void textBox_cost_rashod_TextChanged(object sender, EventArgs e)
        {
            if (textBox_cost_rashod.Text.Length > 15)
            {
                MessageBox.Show("Много символов! Цена сделки должна составлять максимально 15 символам!");
                textBox_cost_rashod.Clear();
                textBox_cost_rashod.Focus();
            }
        }

        private void button_add_rashod_Click(object sender, EventArgs e)
        {
            if (textBox_fio_user.Text != "" && textBox__fio_bought_mainer2.Text != "" && textBox_name_picture2.Text != "" && textBox_cost_rashod.Text != "")
            {
                db.OpenConnection();

                string procedure_name = "insert_rashod";
                MySqlCommand comm_Add = new MySqlCommand(procedure_name, db.GetConnection());
                comm_Add.CommandType = CommandType.StoredProcedure;

                MySqlParameter f_u = new MySqlParameter
                {
                    ParameterName = "f_u",
                    Value = textBox_fio_user.Text
                };
                MySqlParameter f_b_m = new MySqlParameter
                {
                    ParameterName = "f_b_m",
                    Value = textBox__fio_bought_mainer2.Text
                };
                MySqlParameter n_p = new MySqlParameter
                {
                    ParameterName = "n_p",
                    Value = textBox_name_picture2.Text
                };
                MySqlParameter c_r = new MySqlParameter
                {
                    ParameterName = "c_r",
                    Value = Convert.ToInt32(textBox_cost_rashod.Text)//цена продажи картины
                };

                comm_Add.Parameters.Add(f_u);
                comm_Add.Parameters.Add(f_b_m);
                comm_Add.Parameters.Add(n_p);
                comm_Add.Parameters.Add(c_r);

                comm_Add.ExecuteNonQuery();

                db.CloseConnection();

                ShowRashod();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_delete_rashod_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы точно хотите удалить данные?", "Удаление данных", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (textBox_fio_user.Text != "" && textBox__fio_bought_mainer2.Text != "" && textBox_name_picture2.Text != "" && textBox_cost_rashod.Text != "")
                {
                    db.OpenConnection();

                    string procedure_name = "delete_rashod";
                    MySqlCommand comm_Del = new MySqlCommand(procedure_name, db.GetConnection());
                    comm_Del.CommandType = CommandType.StoredProcedure;

                    MySqlParameter f_u = new MySqlParameter
                    {
                        ParameterName = "f_u",
                        Value = textBox_fio_user.Text
                    };
                    MySqlParameter f_b_m = new MySqlParameter
                    {
                        ParameterName = "f_b_m",
                        Value = textBox__fio_bought_mainer2.Text
                    };
                    MySqlParameter n_p = new MySqlParameter
                    {
                        ParameterName = "n_p",
                        Value = textBox_name_picture2.Text
                    };
                    MySqlParameter c_r = new MySqlParameter
                    {
                        ParameterName = "c_r",
                        Value = Convert.ToInt32(textBox_cost_rashod.Text)//цена продажи картины
                    };

                    comm_Del.Parameters.Add(f_u);
                    comm_Del.Parameters.Add(f_b_m);
                    comm_Del.Parameters.Add(n_p);
                    comm_Del.Parameters.Add(c_r);

                    comm_Del.ExecuteNonQuery();

                    db.CloseConnection();

                    ShowRashod();
                }
                else
                {
                    MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                    return;
                }
            }
            else if (dr == DialogResult.No)
            {
                return;
            }
        }

        private void button_update_delete_Click(object sender, EventArgs e)
        {
            if (textBox_fio_user.Text != "" && textBox__fio_bought_mainer2.Text != "" && textBox_name_picture2.Text != "" && textBox_cost_rashod.Text != "")
            {
                db.OpenConnection();

                string procedure_name = "update_rashod";
                MySqlCommand comm_Upd = new MySqlCommand(procedure_name, db.GetConnection());
                comm_Upd.CommandType = CommandType.StoredProcedure;

                string value = dataGridView6.CurrentRow.Cells[0].Value.ToString();

                MySqlParameter id_param = new MySqlParameter
                {
                    ParameterName = "id",
                    Value = value
                };
                MySqlParameter new_f_u = new MySqlParameter
                {
                    ParameterName = "new_f_u",
                    Value = textBox_fio_user.Text
                };
                MySqlParameter new_f_b_m = new MySqlParameter
                {
                    ParameterName = "new_f_b_m",
                    Value = textBox__fio_bought_mainer2.Text
                };
                MySqlParameter new_n_p = new MySqlParameter
                {
                    ParameterName = "new_n_p",
                    Value = textBox_name_picture2.Text
                };
                MySqlParameter new_c_r = new MySqlParameter
                {
                    ParameterName = "new_c_r",
                    Value = Convert.ToInt32(textBox_cost_rashod.Text)//цена продажи картины
                };

                comm_Upd.Parameters.Add(id_param);
                comm_Upd.Parameters.Add(new_f_u);
                comm_Upd.Parameters.Add(new_f_b_m);
                comm_Upd.Parameters.Add(new_n_p);
                comm_Upd.Parameters.Add(new_c_r);

                comm_Upd.ExecuteNonQuery();

                db.CloseConnection();

                ShowRashod();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_report_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
        }

        private void button_show_report_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            if (comboBox_report.Text == "Отчет о проданных картинах")
            {
                dataGridView7.Rows.Clear();
                dataGridView7.ColumnCount = 4;

                dataGridView7.Columns[0].HeaderText = "ФИО пользователя";
                dataGridView7.Columns[1].HeaderText = "ФИО покупателя";
                dataGridView7.Columns[2].HeaderText = "Название картины";
                dataGridView7.Columns[3].HeaderText = "Цена сделки";

                string sql1 = "SELECT (SELECT fio_user FROM user WHERE user.id_user = rashod.id_user), (SELECT fio_bought_mainer FROM bought_mainer WHERE bought_mainer.id_bought_mainer = rashod.id_bought_mainer), (SELECT name_picture FROM picture WHERE picture.id_picture = rashod.id_picture), cost_rashod FROM pic.rashod;";
                MySqlCommand command1 = new MySqlCommand(sql1, db.GetConnection());

                MySqlDataReader reader1 = command1.ExecuteReader();
                List<string[]> data1 = new List<string[]>();

                while (reader1.Read())
                {
                    data1.Add(new string[4]);

                    data1[data1.Count - 1][0] = reader1[0].ToString();
                    data1[data1.Count - 1][1] = reader1[1].ToString();
                    data1[data1.Count - 1][2] = reader1[2].ToString();
                    data1[data1.Count - 1][3] = reader1[3].ToString();
                }
                reader1.Close();

                db.CloseConnection();

                foreach (string[] s in data1)
                    dataGridView7.Rows.Add(s);
            }
            else if (comboBox_report.Text == "Отчет о проданных картинах по автору")
            {
                dataGridView7.Rows.Clear();
                dataGridView7.ColumnCount = 3;

                dataGridView7.Columns[0].HeaderText = "ФИО покупателя";
                dataGridView7.Columns[1].HeaderText = "Название картины";
                dataGridView7.Columns[2].HeaderText = "Цена сделки";

                string sql1 = "SELECT (SELECT fio_bought_mainer FROM bought_mainer WHERE bought_mainer.id_bought_mainer = rashod.id_bought_mainer), (SELECT name_picture FROM picture WHERE picture.id_picture = rashod.id_picture), cost_rashod FROM pic.rashod INNER JOIN picture ON picture.id_picture = rashod.id_picture INNER JOIN author ON author.id_author = picture.id_author WHERE fio_author='" + textBox_fio_author3.Text + "';";
                MySqlCommand command1 = new MySqlCommand(sql1, db.GetConnection());

                MySqlDataReader reader1 = command1.ExecuteReader();
                List<string[]> data1 = new List<string[]>();

                while (reader1.Read())
                {
                    data1.Add(new string[3]);

                    data1[data1.Count - 1][0] = reader1[0].ToString();
                    data1[data1.Count - 1][1] = reader1[1].ToString();
                    data1[data1.Count - 1][2] = reader1[2].ToString();
                }
                reader1.Close();

                db.CloseConnection();

                foreach (string[] s in data1)
                    dataGridView7.Rows.Add(s);
            }
            else if (comboBox_report.Text == "Отчет о проданных картинах по названию")
            {
                dataGridView7.Rows.Clear();
                dataGridView7.ColumnCount = 2;

                dataGridView7.Columns[0].HeaderText = "ФИО покупателя";
                dataGridView7.Columns[1].HeaderText = "Цена сделки";

                string sql1 = "SELECT (SELECT fio_bought_mainer FROM bought_mainer WHERE bought_mainer.id_bought_mainer = rashod.id_bought_mainer), cost_rashod FROM pic.rashod INNER JOIN picture ON picture.id_picture = rashod.id_picture WHERE name_picture = '" + textBox_name_picture4.Text + "';";
                MySqlCommand command1 = new MySqlCommand(sql1, db.GetConnection());

                MySqlDataReader reader1 = command1.ExecuteReader();
                List<string[]> data1 = new List<string[]>();

                while (reader1.Read())
                {
                    data1.Add(new string[2]);

                    data1[data1.Count - 1][0] = reader1[0].ToString();
                    data1[data1.Count - 1][1] = reader1[1].ToString();
                }
                reader1.Close();

                db.CloseConnection();

                foreach (string[] s in data1)
                    dataGridView7.Rows.Add(s);
            }
            else if (comboBox_report.Text == "Отчет о проданных картинах по сотруднику")
            {
                dataGridView7.Rows.Clear();
                dataGridView7.ColumnCount = 2;

                dataGridView7.Columns[0].HeaderText = "Название картины";
                dataGridView7.Columns[1].HeaderText = "Цена сделки";

                string sql1 = "SELECT (SELECT name_picture FROM picture WHERE picture.id_picture = rashod.id_picture), cost_rashod FROM pic.rashod INNER JOIN user ON user.id_user = rashod.id_user WHERE fio_user = '" + textBox_fio_user2.Text + "';";
                MySqlCommand command1 = new MySqlCommand(sql1, db.GetConnection());

                MySqlDataReader reader1 = command1.ExecuteReader();
                List<string[]> data1 = new List<string[]>();

                while (reader1.Read())
                {
                    data1.Add(new string[2]);

                    data1[data1.Count - 1][0] = reader1[0].ToString();
                    data1[data1.Count - 1][1] = reader1[1].ToString();
                }
                reader1.Close();

                db.CloseConnection();

                foreach (string[] s in data1)
                    dataGridView7.Rows.Add(s);
            }
            //(comboBox_report.Text == "Отчет о проведенных выставках за период")
            else
            {
                dataGridView7.Rows.Clear();
                dataGridView7.ColumnCount = 5;

                dataGridView7.Columns[0].HeaderText = "Название выставки";
                dataGridView7.Columns[1].HeaderText = "Кол-во проданных билетов";
                dataGridView7.Columns[2].HeaderText = "Цена билета";
                dataGridView7.Columns[3].HeaderText = "Сумма";
                dataGridView7.Columns[4].HeaderText = "Название музея";

                string sql1 = "SELECT name_exhibitions, sold_places, price_exhibitions, (sold_places*price_exhibitions),(SELECT name_museum FROM museum WHERE museum.id_museum = exhibitions.id_museum) FROM exhibitions WHERE date_start = '" + textBox_date_ot.Text.ToString() + "' AND date_end = '" + textBox_date_do.Text.ToString() + "';";
                MySqlCommand command1 = new MySqlCommand(sql1, db.GetConnection());

                MySqlDataReader reader1 = command1.ExecuteReader();
                List<string[]> data1 = new List<string[]>();

                while (reader1.Read())
                {
                    data1.Add(new string[5]);

                    data1[data1.Count - 1][0] = reader1[0].ToString();
                    data1[data1.Count - 1][1] = reader1[1].ToString();
                    data1[data1.Count - 1][2] = reader1[2].ToString();
                    data1[data1.Count - 1][3] = reader1[3].ToString();
                    data1[data1.Count - 1][4] = reader1[4].ToString();
                }
                reader1.Close();

                db.CloseConnection();

                foreach (string[] s in data1)
                    dataGridView7.Rows.Add(s);
            }
        }

        private void button_export_excel_Click(object sender, EventArgs e)
        {
            if (comboBox_report.Text == "Отчет о проданных картинах")
            {
                SaveToWord("Отчет о проданных картинах");
            }
            if (comboBox_report.Text == "Отчет о проданных картинах по автору")
            {
                SaveToWord("Отчет о проданных картинах по автору " + textBox_fio_author3.Text.ToString());
            }
            if (comboBox_report.Text == "Отчет о проданных картинах по названию")
            {
                SaveToWord("Отчет о проданных картинах по названию " + textBox_name_picture4.Text.ToString());
            }
            if (comboBox_report.Text == "Отчет о проданных картинах по сотруднику")
            {
                SaveToWord("Отчет о проданных картинах по сотруднику " + textBox_fio_user2.Text.ToString());
            }
            if (comboBox_report.Text == "Отчет о проведенных выставках за период")
            {
                SaveToWord("Отчет о проведенных выставках за период " + textBox_date_ot.Text.ToString() + "-" + textBox_date_do.Text.ToString());
            }
        }
        public static string[,] ArrayToDGV(DataGridView dataGridView)
        {
            string[,] matrs;
            matrs = new string[dataGridView.RowCount, dataGridView.ColumnCount];

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    //Преобразуем значения из ячеек в строку, и пишем в массив
                    matrs[i, j] = dataGridView.Rows[i].Cells[j].Value.ToString();
                }
            }
            return matrs;
        }
        //private void SaveToWord2(DataGridView dataGridView7, string file_name)
        //{
        //    saveFileDialog1.InitialDirectory = "C:/Users/Алёна/Desktop/Корпоративные ИС";
        //    //saveFileDialog1.Title = "SAVE AS EXCEL FILE";
        //    //saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
        //    saveFileDialog1.FileName = file_name;

        //    string[,] array = ArrayToDGV(dataGridView7);

        //    Word.Application application = new Word.Application();
        //    Object missing = Type.Missing;
        //    application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
        //    Word.Document document = application.ActiveDocument;
        //    Word.Range range = application.Selection.Range;
        //    Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
        //    Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;
        //    document.Tables.Add(range, dataGridView7.Rows.Count, dataGridView7.Columns.Count, ref behiavor, ref autoFitBehiavor);
        //    for (int i = 0; i < dataGridView7.Rows.Count; i++)
        //        for (int j = 0; j < dataGridView7.Columns.Count; j++)
        //            document.Tables[1].Cell(i + 1, j + 1).Range.Text = array[i, j].ToString();
        //    application.Visible = true;
        //}
        private void SaveToWord(string file_name)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.doc)|*.doc";

            sfd.FileName = file_name;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Word(dataGridView7, sfd.FileName);
            }
        }
        public async void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            string stOutput = "";
            string sHeaders = "";

            for (int j = 0; j < DGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(DGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            for (int i = 0; i < DGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < DGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(DGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                byte[] text = Encoding.Default.GetBytes(stOutput);
                await fs.WriteAsync(text, 0, text.Length);
            }
            //MessageBox.Show("File saved!");
        }

        //private void SaveToExcel(string file_name)
        //{
        //    saveFileDialog1.InitialDirectory = "C:/Users/Алёна/Desktop/Корпоративные ИС";
        //    saveFileDialog1.Title = "SAVE AS EXCEL FILE";
        //    saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
        //    saveFileDialog1.FileName = file_name;
        //    if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        Excel.Application exApp = new Excel.Application();
        //        exApp.Application.Workbooks.Add(Type.Missing);
        //        exApp.Columns.ColumnWidth = 28;
        //        for (int i = 1; i < dataGridView7.Columns.Count + 1; i++)
        //        {
        //            exApp.Cells[1, i] = dataGridView7.Columns[i - 1].HeaderText;
        //        }
        //        for (int i = 0; i < dataGridView7.Rows.Count; i++)
        //        {
        //            for (int j = 0; j < dataGridView7.Columns.Count; j++)
        //            {
        //                exApp.Cells[i + 2, j + 1] = dataGridView7.Rows[i].Cells[j].Value.ToString();
        //            }

        //        }
        //        exApp.ActiveWorkbook.SaveAs(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //        exApp.ActiveWorkbook.Saved = true;
        //        exApp.Quit();
        //    }
        //    Cursor.Current = Cursors.Default;
        //}

        private void textBox_fio_author3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_fio_author3.Focus();
            }
        }

        private void textBox_fio_author3_TextChanged(object sender, EventArgs e)
        {
            if (textBox_fio_author3.Text.Length > 45)
            {
                MessageBox.Show("Много символов! ФИО автора должно составлять максимально 45 символам!");
                textBox_fio_author3.Clear();
                textBox_fio_author3.Focus();
            }
        }

        private void textBox_fio_author3_Enter(object sender, EventArgs e)
        {
            if (textBox_fio_author3.Text == "Иванов Иван Иванович")
            {
                textBox_fio_author3.Text = "";
                textBox_fio_author3.ForeColor = Color.Black;
            }
        }

        private void textBox_fio_author3_Leave(object sender, EventArgs e)
        {
            if (textBox_fio_author3.Text == "")
            {
                textBox_fio_author3.Text = "Иванов Иван Иванович";
                textBox_fio_author3.ForeColor = Color.Gray;
            }
        }

        private void textBox_name_picture4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_name_picture4.Focus();
            }
        }

        private void textBox_name_picture4_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name_picture4.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название картины должно составлять максимально 45 символам!");
                textBox_name_picture4.Clear();
                textBox_name_picture4.Focus();
            }
        }

        private void textBox_fio_user2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || number == 'ё' || number == 'Ё' || (number == (char)Keys.Back) || (number == (char)Keys.Space))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_fio_user2.Focus();
            }
        }

        private void textBox_fio_user2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_fio_user2.Text.Length > 45)
            {
                MessageBox.Show("Много символов! ФИО пользователя должно составлять максимально 45 символам!");
                textBox_fio_user2.Clear();
                textBox_fio_user2.Focus();
            }
        }

        private void textBox_fio_user2_Enter(object sender, EventArgs e)
        {
            if (textBox_fio_user2.Text == "Иванов Иван Иванович")
            {
                textBox_fio_user2.Text = "";
                textBox_fio_user2.ForeColor = Color.Black;
            }
        }

        private void textBox_fio_user2_Leave(object sender, EventArgs e)
        {
            if (textBox_fio_user2.Text == "")
            {
                textBox_fio_user2.Text = "Иванов Иван Иванович";
                textBox_fio_user2.ForeColor = Color.Gray;
            }
        }

        private void textBox_date_ot_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number) || number == 45 || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Дата заполняется гггг-мм-дд!");
                textBox_date_ot.Focus();
            }
        }

        private void textBox_date_ot_TextChanged(object sender, EventArgs e)
        {
            if (textBox_date_ot.Text.Length > 10)
            {
                MessageBox.Show("Много символов! Дата должна составлять максимально 10 символам!");
                textBox_date_ot.Clear();
                textBox_date_ot.Focus();
            }
        }

        private void textBox_date_ot_Enter(object sender, EventArgs e)
        {
            if (textBox_date_ot.Text == "гггг-мм-дд")
            {
                textBox_date_ot.Text = "";
                textBox_date_ot.ForeColor = Color.Black;
            }
        }

        private void textBox_date_ot_Leave(object sender, EventArgs e)
        {
            if (textBox_date_ot.Text == "")
            {
                textBox_date_ot.Text = "гггг-мм-дд";
                textBox_date_ot.ForeColor = Color.Gray;
            }
        }

        private void textBox_date_do_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number) || number == 45 || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Дата заполняется гггг-мм-дд!");
                textBox_date_do.Focus();
            }
        }

        private void textBox_date_do_TextChanged(object sender, EventArgs e)
        {
            if (textBox_date_do.Text.Length > 10)
            {
                MessageBox.Show("Много символов! Дата должна составлять максимально 10 символам!");
                textBox_date_do.Clear();
                textBox_date_do.Focus();
            }
        }

        private void textBox_date_do_Enter(object sender, EventArgs e)
        {
            if (textBox_date_do.Text == "гггг-мм-дд")
            {
                textBox_date_do.Text = "";
                textBox_date_do.ForeColor = Color.Black;
            }
        }

        private void textBox_date_do_Leave(object sender, EventArgs e)
        {
            if (textBox_date_do.Text == "")
            {
                textBox_date_do.Text = "гггг-мм-дд";
                textBox_date_do.ForeColor = Color.Gray;
            }
        }

        private void comboBox_report_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_report.Text == "Отчет о проданных картинах")
            {
                label_fio_author3.Visible = false;
                textBox_fio_author3.Visible = false;

                label_name_picture4.Visible = false;
                textBox_name_picture4.Visible = false;

                label_fio_user2.Visible = false;
                textBox_fio_user2.Visible = false;

                label_date_ot.Visible = false;
                textBox_date_ot.Visible = false;

                label_date_do.Visible = false;
                textBox_date_do.Visible = false;
            }
            else if (comboBox_report.Text == "Отчет о проданных картинах по автору")
            {
                label_fio_author3.Visible = true;
                textBox_fio_author3.Visible = true;

                label_name_picture4.Visible = false;
                textBox_name_picture4.Visible = false;

                label_fio_user2.Visible = false;
                textBox_fio_user2.Visible = false;

                label_date_ot.Visible = false;
                textBox_date_ot.Visible = false;

                label_date_do.Visible = false;
                textBox_date_do.Visible = false;
            }
            else if (comboBox_report.Text == "Отчет о проданных картинах по названию")
            {
                label_fio_author3.Visible = false;
                textBox_fio_author3.Visible = false;

                label_name_picture4.Visible = true;
                textBox_name_picture4.Visible = true;

                label_fio_user2.Visible = false;
                textBox_fio_user2.Visible = false;

                label_date_ot.Visible = false;
                textBox_date_ot.Visible = false;

                label_date_do.Visible = false;
                textBox_date_do.Visible = false;
            }
            else if (comboBox_report.Text == "Отчет о проданных картинах по сотруднику")
            {
                label_fio_author3.Visible = false;
                textBox_fio_author3.Visible = false;

                label_name_picture4.Visible = false;
                textBox_name_picture4.Visible = false;

                label_fio_user2.Visible = true;
                textBox_fio_user2.Visible = true;

                label_date_ot.Visible = false;
                textBox_date_ot.Visible = false;

                label_date_do.Visible = false;
                textBox_date_do.Visible = false;
            }
            else if (comboBox_report.Text == "")
            {
                label_fio_author3.Visible = false;
                textBox_fio_author3.Visible = false;

                label_name_picture4.Visible = false;
                textBox_name_picture4.Visible = false;

                label_fio_user2.Visible = false;
                textBox_fio_user2.Visible = false;

                label_date_ot.Visible = false;
                textBox_date_ot.Visible = false;

                label_date_do.Visible = false;
                textBox_date_do.Visible = false;
            }
            else//comboBox_report.Text == "Отчет о проведенных выставках за период"
            {
                label_fio_author3.Visible = false;
                textBox_fio_author3.Visible = false;

                label_name_picture4.Visible = false;
                textBox_name_picture4.Visible = false;

                label_fio_user2.Visible = false;
                textBox_fio_user2.Visible = false;

                label_date_ot.Visible = true;
                textBox_date_ot.Visible = true;

                label_date_do.Visible = true;
                textBox_date_do.Visible = true;
            }
        }
    }
}
