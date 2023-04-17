using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Picture
{
    public partial class Form1 : Form
    {
        Basa db;
        DataTable dt;
        MySqlDataAdapter msda;
        MySqlCommand command;
        DataSet ds;

        string login, password, user_role;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Pass
        {
            get { return password; }
            set { password = value; }
        }
        public string UsRole
        {
            get { return user_role; }
            set { user_role = value; }
        }

        public Form1()
        {
            InitializeComponent();
            db = new Basa();
            dt = new DataTable();
            msda = new MySqlDataAdapter();
            ds = new DataSet();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ClickEnter(e);
        }

        private void textBox_login_KeyDown(object sender, KeyEventArgs e)
        {
            ClickEnter(e);
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            db.OpenConnection();

            try
            {
                if (textBox_login.Text != "" && textBox_password.Text != "")
                {
                    string procedure_name = "select login_user, password_user, id_user_role from user WHERE login_user ='" + textBox_login.Text + "' AND password_user ='" + textBox_password.Text + "'";
                    //MySqlConnection Connection = new MySqlConnection(procedure_name);
                    command = new MySqlCommand(procedure_name, db.GetConnection());
                    MySqlDataReader reader;
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            login = reader["login_user"].ToString();
                            password = reader["password_user"].ToString();
                            user_role = reader["id_user_role"].ToString();
                        }
                        
                        UserRole(user_role);

                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль пусты", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка соединения", "Information");
            }
            db.CloseConnection();
        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            ClickEnter(e);
        }

        private void UserRole(string user_role)
        {
            switch (user_role)
            {
                case "1": db.CloseConnection(); this.Visible = false; Admin a = new Admin(); a.Show(); break;
                case "2": db.CloseConnection(); this.Visible = false; User u = new User(); u.Show(); break;
            }
        }

        private void ClickEnter(KeyEventArgs e)
        {
            bool loginText = textBox_login.Text == "";
            bool passwordText = textBox_password.Text == "";
            if (loginText || passwordText)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                button_log.PerformClick();
            }
        }
    }
}