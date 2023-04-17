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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Picture
{
    public partial class Admin : Form
    {
        Basa db;
        Point location = new Point(15, 60);
        Color c = Color.FromArgb(216, 191, 216);
        public Admin()
        {
            InitializeComponent();

            db = new Basa();

            this.Size = new Size(1000, 550);

            panel1.Parent = this;
            panel2.Parent = this;
            panel3.Parent = this;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;

            panel1.Location = location;
            panel2.Location = location;
            panel3.Location = location;

            panel1.BackColor = c;
            panel2.BackColor = c;
            panel3.BackColor = c;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            this.dataGridView1.DefaultCellStyle.Font = new Font("Book Antiqua", 10);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Book Antiqua", 10);

            this.dataGridView2.DefaultCellStyle.Font = new Font("Book Antiqua", 10);
            this.dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Book Antiqua", 10);

            this.dataGridView3.DefaultCellStyle.Font = new Font("Book Antiqua", 10);
            this.dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Book Antiqua", 10);

            //для textbox_user_role на panel2
            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[] { "администратор", "пользователь" });
            textBox_user_role.AutoCompleteCustomSource = source;
            textBox_user_role.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_user_role.AutoCompleteSource = AutoCompleteSource.CustomSource;

            ShowPicture();
            ShowUser();
            ShowExhibitions();

            ShowJanreTextBox();//textBox_name_janre на panel1
            ShowAuthorTextBox();//для textbox_fio_author на panel1
            ShowExhibitionsTextBox();//для textBox_name_exhibitions на panel1
            ShowMuseumTextBox();//для textbox_name_museum на panel2 и textbox_name_museum2 на panel3
        }
        private void ShowUser()
        {
            dataGridView2.Rows.Clear();
            MySqlDataAdapter msda = new MySqlDataAdapter();
            string sql = "SELECT id_user, fio_user, login_user, password_user, (SELECT name_user_role FROM user_role WHERE user_role.id_user_role = user.id_user_role), (SELECT name_museum FROM museum WHERE museum.id_museum = user.id_museum) FROM pic.user;";

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
                dataGridView2.Rows.Add(s);
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
            textBox_name_museum.AutoCompleteCustomSource = s;
            textBox_name_museum.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_name_museum.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textBox_name_museum2.AutoCompleteCustomSource = s;
            textBox_name_museum2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_name_museum2.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                    Value = textBox_year_create_picture.Text
                };
                MySqlParameter new_a_i = new MySqlParameter
                {
                    ParameterName = "new_a_i",
                    Value = textBox_fio_author.Text
                };
                MySqlParameter new_j_i = new MySqlParameter
                {
                    ParameterName = "new_j_i",
                    Value = textBox_name_janre.Text
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



        private void button_user_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;

        }

        private void button_add_user_Click(object sender, EventArgs e)
        {
            if (textBox_fio_user.Text != "" && textBox__login_user.Text != "" && textBox_password_user.Text != "" && textBox_user_role.Text != "" && textBox_name_museum.Text != "")
            {
                db.OpenConnection();

                string procedure_name = "insert_user";
                MySqlCommand comm_Add = new MySqlCommand(procedure_name, db.GetConnection());
                comm_Add.CommandType = CommandType.StoredProcedure;

                MySqlParameter f_u = new MySqlParameter
                {
                    ParameterName = "f_u",
                    Value = textBox_fio_user.Text
                };
                MySqlParameter l_u = new MySqlParameter
                {
                    ParameterName = "l_u",
                    Value = textBox__login_user.Text
                };
                MySqlParameter p_u = new MySqlParameter
                {
                    ParameterName = "p_u",
                    Value = textBox_password_user.Text
                };
                MySqlParameter n_u_r = new MySqlParameter
                {
                    ParameterName = "n_u_r",
                    Value = textBox_user_role.Text
                };
                MySqlParameter n_m = new MySqlParameter
                {
                    ParameterName = "n_m",
                    Value = textBox_name_museum.Text
                };

                comm_Add.Parameters.Add(f_u);
                comm_Add.Parameters.Add(l_u);
                comm_Add.Parameters.Add(p_u);
                comm_Add.Parameters.Add(n_u_r);
                comm_Add.Parameters.Add(n_m);

                comm_Add.ExecuteNonQuery();

                db.CloseConnection();

                ShowUser();
            }
            else
            {
                MessageBox.Show("Некоторые поля для ввода данных пустые! Заполните их!");
                return;
            }
        }

        private void button_delete_user_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы точно хотите удалить данные?", "Удаление данных", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (textBox_fio_user.Text != "" && textBox__login_user.Text != "" && textBox_password_user.Text != "" && textBox_user_role.Text != "" && textBox_name_museum.Text != "")
                {
                    db.OpenConnection();

                    string procedure_name = "delete_user";
                    MySqlCommand comm_Del = new MySqlCommand(procedure_name, db.GetConnection());
                    comm_Del.CommandType = CommandType.StoredProcedure;

                    MySqlParameter f_u = new MySqlParameter
                    {
                        ParameterName = "f_u",
                        Value = textBox_fio_user.Text
                    };
                    MySqlParameter l_u = new MySqlParameter
                    {
                        ParameterName = "l_u",
                        Value = textBox__login_user.Text
                    };
                    MySqlParameter p_u = new MySqlParameter
                    {
                        ParameterName = "p_u",
                        Value = textBox_password_user.Text
                    };
                    MySqlParameter u_r_i = new MySqlParameter
                    {
                        ParameterName = "u_r_i",
                        Value = textBox_user_role.Text
                    };
                    MySqlParameter m_i = new MySqlParameter
                    {
                        ParameterName = "m_i",
                        Value = textBox_name_museum.Text
                    };

                    comm_Del.Parameters.Add(f_u);
                    comm_Del.Parameters.Add(l_u);
                    comm_Del.Parameters.Add(p_u);
                    comm_Del.Parameters.Add(u_r_i);
                    comm_Del.Parameters.Add(m_i);

                    comm_Del.ExecuteNonQuery();

                    db.CloseConnection();

                    ShowUser();
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

        private void button_update_user_Click(object sender, EventArgs e)
        {
            if (textBox_fio_user.Text != "" && textBox__login_user.Text != "" && textBox_password_user.Text != "" && textBox_user_role.Text != "" && textBox_name_museum.Text != "")
            {
                db.OpenConnection();

                string procedure_name = "update_picture";
                MySqlCommand comm_Upd = new MySqlCommand(procedure_name, db.GetConnection());
                comm_Upd.CommandType = CommandType.StoredProcedure;

                string value = dataGridView2.CurrentRow.Cells[0].Value.ToString();

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
                MySqlParameter new_l_u = new MySqlParameter
                {
                    ParameterName = "new_l_u",
                    Value = textBox__login_user.Text
                };
                MySqlParameter new_p_u = new MySqlParameter
                {
                    ParameterName = "new_p_u",
                    Value = textBox_password_user.Text
                };
                MySqlParameter new_u_r_i = new MySqlParameter
                {
                    ParameterName = "new_u_r_i",
                    Value = textBox_user_role.Text
                };
                MySqlParameter new_m_i = new MySqlParameter
                {
                    ParameterName = "new_m_i",
                    Value = textBox_name_museum.Text
                };

                comm_Upd.Parameters.Add(id_param);
                comm_Upd.Parameters.Add(new_f_u);
                comm_Upd.Parameters.Add(new_l_u);
                comm_Upd.Parameters.Add(new_p_u);
                comm_Upd.Parameters.Add(new_u_r_i);
                comm_Upd.Parameters.Add(new_m_i);

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

        private void textBox_fio_user_TextChanged(object sender, EventArgs e)
        {
            if (textBox_fio_user.Text.Length > 45)
            {
                MessageBox.Show("Много символов! ФИО пользователя должно составлять максимально 45 символам!");
                textBox_fio_user.Clear();
                textBox_fio_user.Focus();
            }
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

        private void textBox__login_user_TextChanged(object sender, EventArgs e)
        {
            if (textBox__login_user.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название выставки должно составлять максимально 45 символам!");
                textBox__login_user.Clear();
                textBox__login_user.Focus();
            }
        }

        private void textBox_password_user_TextChanged(object sender, EventArgs e)
        {
            if (textBox_password_user.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название выставки должно составлять максимально 45 символам!");
                textBox_password_user.Clear();
                textBox_password_user.Focus();
            }
        }

        private void textBox_user_role_TextChanged(object sender, EventArgs e)
        {
            if (textBox_user_role.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название выставки должно составлять максимально 45 символам!");
                textBox_user_role.Clear();
                textBox_user_role.Focus();
            }
        }

        private void textBox_name_museum_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name_museum.Text.Length > 45)
            {
                MessageBox.Show("Много символов! Название выставки должно составлять максимально 45 символам!");
                textBox_name_museum.Clear();
                textBox_name_museum.Focus();
            }
        }

        private void textBox_user_role_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number > 'А' && number < 'я') || (number == (char)Keys.Back))
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Нужно вводить только русский алфавит!");
                textBox_user_role.Focus();
            }
        }

        private void textBox_name_museum_KeyPress(object sender, KeyPressEventArgs e)
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
                textBox_name_museum.Focus();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_fio_user.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox__login_user.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox_password_user.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox_user_role.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox_name_museum.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button_exhibitions_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button_add_exhibitions_Click(object sender, EventArgs e)
        {
            if (textBox_name_exhibitions2.Text != "" && textBox_date_start.Text != "" && textBox_date_end.Text != "" && textBox_sold_places.Text != "" && textBox_price_exhibitions.Text != "" && textBox_name_museum.Text != "")
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
                MySqlParameter id_mu = new MySqlParameter
                {
                    ParameterName = "id_mu",
                    Value = textBox_name_museum2.Text
                };

                comm_Add.Parameters.Add(n_e);
                comm_Add.Parameters.Add(d_s);
                comm_Add.Parameters.Add(d_e);
                comm_Add.Parameters.Add(s_p);
                comm_Add.Parameters.Add(p_e);
                comm_Add.Parameters.Add(id_mu);

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
                if (textBox_name_exhibitions2.Text != "" && textBox_date_start.Text != "" && textBox_date_end.Text != "" && textBox_sold_places.Text != "" && textBox_price_exhibitions.Text != "" && textBox_name_museum.Text != "")
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
            if (textBox_name_exhibitions2.Text != "" && textBox_date_start.Text != "" && textBox_date_end.Text != "" && textBox_sold_places.Text != "" && textBox_price_exhibitions.Text != "" && textBox_name_museum.Text != "")
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
            if (textBox_date_start.Text.Length > 10)
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
            }
        }

        private void textBox_date_end_TextChanged(object sender, EventArgs e)
        {
            if (textBox_date_end.Text.Length > 10)
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

        private void textBox_name_picture_KeyPress(object sender, KeyPressEventArgs e)
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
                textBox_name_picture.Focus();
            }
        }
    }
}
