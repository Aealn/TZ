namespace Picture
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            panel1 = new Panel();
            button_update_picture = new Button();
            button_delete_picture = new Button();
            textBox_name_exhibitions = new TextBox();
            textBox_name_janre = new TextBox();
            label_name_exhibitions = new Label();
            label_name_janre = new Label();
            label_fio_author = new Label();
            textBox_fio_author = new TextBox();
            label_year_create_picture = new Label();
            textBox_year_create_picture = new TextBox();
            label_name_picture = new Label();
            textBox_name_picture = new TextBox();
            button_add_picture = new Button();
            dataGridView1 = new DataGridView();
            id_picture = new DataGridViewTextBoxColumn();
            name_picture = new DataGridViewTextBoxColumn();
            year_create_picture = new DataGridViewTextBoxColumn();
            fio_author = new DataGridViewTextBoxColumn();
            name_janre = new DataGridViewTextBoxColumn();
            name_exhibitions = new DataGridViewTextBoxColumn();
            label1 = new Label();
            button_exit = new Button();
            button_picture = new Button();
            panel2 = new Panel();
            button_update_user = new Button();
            button_delete_user = new Button();
            button_add_user = new Button();
            textBox_name_museum = new TextBox();
            textBox_user_role = new TextBox();
            label_name_museum = new Label();
            label_user_role = new Label();
            label_password_user = new Label();
            textBox_fio_user = new TextBox();
            label_login_user = new Label();
            textBox__login_user = new TextBox();
            label_fio_user = new Label();
            textBox_password_user = new TextBox();
            dataGridView2 = new DataGridView();
            id_user = new DataGridViewTextBoxColumn();
            fio_user = new DataGridViewTextBoxColumn();
            login_user = new DataGridViewTextBoxColumn();
            password_user = new DataGridViewTextBoxColumn();
            id_user_role = new DataGridViewTextBoxColumn();
            id_museum = new DataGridViewTextBoxColumn();
            button_user = new Button();
            button_exhibitions = new Button();
            panel3 = new Panel();
            button_update_exhibitions = new Button();
            button_delete_exhibitions = new Button();
            button_add_exhibitions = new Button();
            label_name_museum2 = new Label();
            textBox_name_museum2 = new TextBox();
            label_price_exhibitions = new Label();
            textBox_price_exhibitions = new TextBox();
            label_sold_places = new Label();
            textBox_sold_places = new TextBox();
            label_date_end = new Label();
            textBox_date_end = new TextBox();
            label_date_start = new Label();
            textBox_date_start = new TextBox();
            label_name_exhibitions2 = new Label();
            textBox_name_exhibitions2 = new TextBox();
            dataGridView3 = new DataGridView();
            id_exhibitions = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            date_start = new DataGridViewTextBoxColumn();
            date_end = new DataGridViewTextBoxColumn();
            sold_places = new DataGridViewTextBoxColumn();
            price_exhibitions = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(button_update_picture);
            panel1.Controls.Add(button_delete_picture);
            panel1.Controls.Add(textBox_name_exhibitions);
            panel1.Controls.Add(textBox_name_janre);
            panel1.Controls.Add(label_name_exhibitions);
            panel1.Controls.Add(label_name_janre);
            panel1.Controls.Add(label_fio_author);
            panel1.Controls.Add(textBox_fio_author);
            panel1.Controls.Add(label_year_create_picture);
            panel1.Controls.Add(textBox_year_create_picture);
            panel1.Controls.Add(label_name_picture);
            panel1.Controls.Add(textBox_name_picture);
            panel1.Controls.Add(button_add_picture);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(12, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(899, 431);
            panel1.TabIndex = 0;
            // 
            // button_update_picture
            // 
            button_update_picture.BackColor = Color.Thistle;
            button_update_picture.FlatStyle = FlatStyle.Popup;
            button_update_picture.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_update_picture.ForeColor = SystemColors.ControlText;
            button_update_picture.Location = new Point(344, 374);
            button_update_picture.Name = "button_update_picture";
            button_update_picture.Size = new Size(106, 35);
            button_update_picture.TabIndex = 34;
            button_update_picture.Text = "Изменить";
            button_update_picture.UseVisualStyleBackColor = false;
            button_update_picture.Click += button_update_picture_Click;
            // 
            // button_delete_picture
            // 
            button_delete_picture.BackColor = Color.Thistle;
            button_delete_picture.FlatStyle = FlatStyle.Popup;
            button_delete_picture.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_delete_picture.ForeColor = SystemColors.ControlText;
            button_delete_picture.Location = new Point(198, 374);
            button_delete_picture.Name = "button_delete_picture";
            button_delete_picture.Size = new Size(106, 35);
            button_delete_picture.TabIndex = 33;
            button_delete_picture.Text = "Удалить";
            button_delete_picture.UseVisualStyleBackColor = false;
            button_delete_picture.Click += button_delete_picture_Click;
            // 
            // textBox_name_exhibitions
            // 
            textBox_name_exhibitions.BackColor = Color.WhiteSmoke;
            textBox_name_exhibitions.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_name_exhibitions.Location = new Point(216, 332);
            textBox_name_exhibitions.Name = "textBox_name_exhibitions";
            textBox_name_exhibitions.Size = new Size(216, 27);
            textBox_name_exhibitions.TabIndex = 21;
            textBox_name_exhibitions.TextChanged += textBox_name_exhibitions_TextChanged;
            textBox_name_exhibitions.KeyPress += textBox_name_exhibitions_KeyPress;
            // 
            // textBox_name_janre
            // 
            textBox_name_janre.BackColor = Color.WhiteSmoke;
            textBox_name_janre.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_name_janre.Location = new Point(216, 293);
            textBox_name_janre.Name = "textBox_name_janre";
            textBox_name_janre.Size = new Size(216, 27);
            textBox_name_janre.TabIndex = 20;
            textBox_name_janre.TextChanged += textBox_name_janre_TextChanged;
            textBox_name_janre.KeyPress += textBox_name_janre_KeyPress;
            // 
            // label_name_exhibitions
            // 
            label_name_exhibitions.AutoSize = true;
            label_name_exhibitions.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_name_exhibitions.Location = new Point(11, 336);
            label_name_exhibitions.Name = "label_name_exhibitions";
            label_name_exhibitions.Size = new Size(182, 23);
            label_name_exhibitions.TabIndex = 19;
            label_name_exhibitions.Text = "Название выставки";
            // 
            // label_name_janre
            // 
            label_name_janre.AutoSize = true;
            label_name_janre.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_name_janre.Location = new Point(35, 297);
            label_name_janre.Name = "label_name_janre";
            label_name_janre.Size = new Size(158, 23);
            label_name_janre.TabIndex = 18;
            label_name_janre.Text = "Название жанра";
            // 
            // label_fio_author
            // 
            label_fio_author.AutoSize = true;
            label_fio_author.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_fio_author.Location = new Point(72, 259);
            label_fio_author.Name = "label_fio_author";
            label_fio_author.Size = new Size(121, 23);
            label_fio_author.TabIndex = 17;
            label_fio_author.Text = "ФИО автора";
            // 
            // textBox_fio_author
            // 
            textBox_fio_author.BackColor = Color.WhiteSmoke;
            textBox_fio_author.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_fio_author.ForeColor = Color.Gray;
            textBox_fio_author.Location = new Point(217, 255);
            textBox_fio_author.Name = "textBox_fio_author";
            textBox_fio_author.Size = new Size(216, 27);
            textBox_fio_author.TabIndex = 16;
            textBox_fio_author.Text = "Иванов Иван Иванович";
            textBox_fio_author.TextChanged += textBox_fio_author_TextChanged;
            textBox_fio_author.Enter += textBox_fio_author_Enter;
            textBox_fio_author.KeyPress += textBox_fio_author_KeyPress;
            textBox_fio_author.Leave += textBox_fio_author_Leave;
            // 
            // label_year_create_picture
            // 
            label_year_create_picture.AutoSize = true;
            label_year_create_picture.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_year_create_picture.Location = new Point(54, 222);
            label_year_create_picture.Name = "label_year_create_picture";
            label_year_create_picture.Size = new Size(139, 23);
            label_year_create_picture.TabIndex = 15;
            label_year_create_picture.Text = "Дата создания";
            // 
            // textBox_year_create_picture
            // 
            textBox_year_create_picture.BackColor = Color.WhiteSmoke;
            textBox_year_create_picture.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_year_create_picture.ForeColor = Color.Gray;
            textBox_year_create_picture.Location = new Point(217, 222);
            textBox_year_create_picture.Name = "textBox_year_create_picture";
            textBox_year_create_picture.Size = new Size(216, 27);
            textBox_year_create_picture.TabIndex = 14;
            textBox_year_create_picture.Text = "гггг";
            textBox_year_create_picture.TextChanged += textBox_year_create_picture_TextChanged;
            textBox_year_create_picture.Enter += textBox_year_create_picture_Enter;
            textBox_year_create_picture.KeyPress += textBox_year_create_picture_KeyPress;
            textBox_year_create_picture.Leave += textBox_year_create_picture_Leave;
            // 
            // label_name_picture
            // 
            label_name_picture.AutoSize = true;
            label_name_picture.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_name_picture.Location = new Point(14, 188);
            label_name_picture.Name = "label_name_picture";
            label_name_picture.Size = new Size(179, 23);
            label_name_picture.TabIndex = 13;
            label_name_picture.Text = "Название картины";
            // 
            // textBox_name_picture
            // 
            textBox_name_picture.BackColor = Color.WhiteSmoke;
            textBox_name_picture.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_name_picture.Location = new Point(217, 189);
            textBox_name_picture.Name = "textBox_name_picture";
            textBox_name_picture.Size = new Size(216, 27);
            textBox_name_picture.TabIndex = 12;
            textBox_name_picture.TextChanged += textBox_name_picture_TextChanged;
            textBox_name_picture.KeyPress += textBox_name_picture_KeyPress;
            // 
            // button_add_picture
            // 
            button_add_picture.BackColor = Color.Thistle;
            button_add_picture.FlatStyle = FlatStyle.Popup;
            button_add_picture.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_add_picture.ForeColor = SystemColors.ControlText;
            button_add_picture.Location = new Point(54, 374);
            button_add_picture.Name = "button_add_picture";
            button_add_picture.Size = new Size(106, 35);
            button_add_picture.TabIndex = 11;
            button_add_picture.Text = "Добавить";
            button_add_picture.UseVisualStyleBackColor = false;
            button_add_picture.Click += button_add_picture_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Thistle;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id_picture, name_picture, year_create_picture, fio_author, name_janre, name_exhibitions });
            dataGridView1.Location = new Point(14, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(866, 173);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // id_picture
            // 
            id_picture.HeaderText = "id_picture";
            id_picture.Name = "id_picture";
            id_picture.Visible = false;
            // 
            // name_picture
            // 
            name_picture.HeaderText = "Название картины";
            name_picture.Name = "name_picture";
            name_picture.Width = 150;
            // 
            // year_create_picture
            // 
            year_create_picture.HeaderText = "Дата создания";
            year_create_picture.Name = "year_create_picture";
            // 
            // fio_author
            // 
            fio_author.HeaderText = "ФИО автора";
            fio_author.Name = "fio_author";
            fio_author.Width = 210;
            // 
            // name_janre
            // 
            name_janre.HeaderText = "Название жанра";
            name_janre.Name = "name_janre";
            name_janre.Width = 150;
            // 
            // name_exhibitions
            // 
            name_exhibitions.HeaderText = "Название выставки";
            name_exhibitions.Name = "name_exhibitions";
            name_exhibitions.Width = 210;
            // 
            // label1
            // 
            label1.Font = new Font("Book Antiqua", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(1, 4);
            label1.Name = "label1";
            label1.Size = new Size(67, 59);
            label1.TabIndex = 1;
            label1.Text = "     ";
            // 
            // button_exit
            // 
            button_exit.BackColor = Color.Thistle;
            button_exit.FlatStyle = FlatStyle.Popup;
            button_exit.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_exit.ForeColor = SystemColors.ControlText;
            button_exit.Location = new Point(905, 12);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(77, 35);
            button_exit.TabIndex = 6;
            button_exit.Text = "Выйти";
            button_exit.UseVisualStyleBackColor = false;
            button_exit.Click += button_exit_Click;
            // 
            // button_picture
            // 
            button_picture.BackColor = Color.Thistle;
            button_picture.FlatStyle = FlatStyle.Popup;
            button_picture.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_picture.ForeColor = SystemColors.ControlText;
            button_picture.Location = new Point(74, 13);
            button_picture.Name = "button_picture";
            button_picture.Size = new Size(106, 35);
            button_picture.TabIndex = 10;
            button_picture.Text = "Картины";
            button_picture.UseVisualStyleBackColor = false;
            button_picture.Click += button_picture_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.PaleTurquoise;
            panel2.Controls.Add(button_update_user);
            panel2.Controls.Add(button_delete_user);
            panel2.Controls.Add(button_add_user);
            panel2.Controls.Add(textBox_name_museum);
            panel2.Controls.Add(textBox_user_role);
            panel2.Controls.Add(label_name_museum);
            panel2.Controls.Add(label_user_role);
            panel2.Controls.Add(label_password_user);
            panel2.Controls.Add(textBox_fio_user);
            panel2.Controls.Add(label_login_user);
            panel2.Controls.Add(textBox__login_user);
            panel2.Controls.Add(label_fio_user);
            panel2.Controls.Add(textBox_password_user);
            panel2.Controls.Add(dataGridView2);
            panel2.Location = new Point(917, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(769, 443);
            panel2.TabIndex = 11;
            // 
            // button_update_user
            // 
            button_update_user.BackColor = Color.Thistle;
            button_update_user.FlatStyle = FlatStyle.Popup;
            button_update_user.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_update_user.ForeColor = SystemColors.ControlText;
            button_update_user.Location = new Point(348, 386);
            button_update_user.Name = "button_update_user";
            button_update_user.Size = new Size(106, 35);
            button_update_user.TabIndex = 37;
            button_update_user.Text = "Изменить";
            button_update_user.UseVisualStyleBackColor = false;
            button_update_user.Click += button_update_user_Click;
            // 
            // button_delete_user
            // 
            button_delete_user.BackColor = Color.Thistle;
            button_delete_user.FlatStyle = FlatStyle.Popup;
            button_delete_user.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_delete_user.ForeColor = SystemColors.ControlText;
            button_delete_user.Location = new Point(202, 386);
            button_delete_user.Name = "button_delete_user";
            button_delete_user.Size = new Size(106, 35);
            button_delete_user.TabIndex = 36;
            button_delete_user.Text = "Удалить";
            button_delete_user.UseVisualStyleBackColor = false;
            button_delete_user.Click += button_delete_user_Click;
            // 
            // button_add_user
            // 
            button_add_user.BackColor = Color.Thistle;
            button_add_user.FlatStyle = FlatStyle.Popup;
            button_add_user.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_add_user.ForeColor = SystemColors.ControlText;
            button_add_user.Location = new Point(58, 386);
            button_add_user.Name = "button_add_user";
            button_add_user.Size = new Size(106, 35);
            button_add_user.TabIndex = 35;
            button_add_user.Text = "Добавить";
            button_add_user.UseVisualStyleBackColor = false;
            button_add_user.Click += button_add_user_Click;
            // 
            // textBox_name_museum
            // 
            textBox_name_museum.BackColor = Color.WhiteSmoke;
            textBox_name_museum.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_name_museum.Location = new Point(238, 338);
            textBox_name_museum.Name = "textBox_name_museum";
            textBox_name_museum.Size = new Size(216, 27);
            textBox_name_museum.TabIndex = 31;
            textBox_name_museum.TextChanged += textBox_name_museum_TextChanged;
            textBox_name_museum.KeyPress += textBox_name_museum_KeyPress;
            // 
            // textBox_user_role
            // 
            textBox_user_role.BackColor = Color.WhiteSmoke;
            textBox_user_role.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_user_role.Location = new Point(238, 299);
            textBox_user_role.Name = "textBox_user_role";
            textBox_user_role.Size = new Size(216, 27);
            textBox_user_role.TabIndex = 30;
            textBox_user_role.TextChanged += textBox_user_role_TextChanged;
            textBox_user_role.KeyPress += textBox_user_role_KeyPress;
            // 
            // label_name_museum
            // 
            label_name_museum.AutoSize = true;
            label_name_museum.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_name_museum.Location = new Point(64, 339);
            label_name_museum.Name = "label_name_museum";
            label_name_museum.Size = new Size(152, 23);
            label_name_museum.TabIndex = 29;
            label_name_museum.Text = "Название музея";
            // 
            // label_user_role
            // 
            label_user_role.AutoSize = true;
            label_user_role.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_user_role.Location = new Point(42, 300);
            label_user_role.Name = "label_user_role";
            label_user_role.Size = new Size(174, 23);
            label_user_role.TabIndex = 28;
            label_user_role.Text = "Роль пользователя";
            // 
            // label_password_user
            // 
            label_password_user.AutoSize = true;
            label_password_user.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_password_user.Location = new Point(132, 265);
            label_password_user.Name = "label_password_user";
            label_password_user.Size = new Size(76, 23);
            label_password_user.TabIndex = 27;
            label_password_user.Text = "Пароль";
            // 
            // textBox_fio_user
            // 
            textBox_fio_user.BackColor = Color.WhiteSmoke;
            textBox_fio_user.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_fio_user.ForeColor = Color.Gray;
            textBox_fio_user.Location = new Point(238, 194);
            textBox_fio_user.Name = "textBox_fio_user";
            textBox_fio_user.Size = new Size(216, 27);
            textBox_fio_user.TabIndex = 26;
            textBox_fio_user.Text = "Иванов Иван Иванович";
            textBox_fio_user.TextChanged += textBox_fio_user_TextChanged;
            textBox_fio_user.Enter += textBox_fio_user_Enter;
            textBox_fio_user.KeyPress += textBox_fio_user_KeyPress;
            textBox_fio_user.Leave += textBox_fio_user_Leave;
            // 
            // label_login_user
            // 
            label_login_user.AutoSize = true;
            label_login_user.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_login_user.Location = new Point(142, 229);
            label_login_user.Name = "label_login_user";
            label_login_user.Size = new Size(66, 23);
            label_login_user.TabIndex = 25;
            label_login_user.Text = "Логин";
            // 
            // textBox__login_user
            // 
            textBox__login_user.BackColor = Color.WhiteSmoke;
            textBox__login_user.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox__login_user.ForeColor = Color.Gray;
            textBox__login_user.Location = new Point(239, 228);
            textBox__login_user.Name = "textBox__login_user";
            textBox__login_user.Size = new Size(216, 27);
            textBox__login_user.TabIndex = 24;
            textBox__login_user.TextChanged += textBox__login_user_TextChanged;
            // 
            // label_fio_user
            // 
            label_fio_user.AutoSize = true;
            label_fio_user.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_fio_user.Location = new Point(36, 194);
            label_fio_user.Name = "label_fio_user";
            label_fio_user.Size = new Size(180, 23);
            label_fio_user.TabIndex = 23;
            label_fio_user.Text = "ФИО пользователя";
            // 
            // textBox_password_user
            // 
            textBox_password_user.BackColor = Color.WhiteSmoke;
            textBox_password_user.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_password_user.Location = new Point(238, 264);
            textBox_password_user.Name = "textBox_password_user";
            textBox_password_user.Size = new Size(216, 27);
            textBox_password_user.TabIndex = 22;
            textBox_password_user.TextChanged += textBox_password_user_TextChanged;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.Thistle;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { id_user, fio_user, login_user, password_user, id_user_role, id_museum });
            dataGridView2.Location = new Point(12, 15);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(744, 173);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // id_user
            // 
            id_user.HeaderText = "id_user";
            id_user.Name = "id_user";
            id_user.Visible = false;
            // 
            // fio_user
            // 
            fio_user.HeaderText = "ФИО пользователя";
            fio_user.Name = "fio_user";
            fio_user.Width = 230;
            // 
            // login_user
            // 
            login_user.HeaderText = "Логин";
            login_user.Name = "login_user";
            // 
            // password_user
            // 
            password_user.HeaderText = "Пароль";
            password_user.Name = "password_user";
            // 
            // id_user_role
            // 
            id_user_role.HeaderText = "Роль пользователя";
            id_user_role.Name = "id_user_role";
            id_user_role.Width = 120;
            // 
            // id_museum
            // 
            id_museum.HeaderText = "Название музея";
            id_museum.Name = "id_museum";
            id_museum.Width = 150;
            // 
            // button_user
            // 
            button_user.BackColor = Color.Thistle;
            button_user.FlatStyle = FlatStyle.Popup;
            button_user.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_user.ForeColor = SystemColors.ControlText;
            button_user.Location = new Point(186, 13);
            button_user.Name = "button_user";
            button_user.Size = new Size(146, 35);
            button_user.TabIndex = 12;
            button_user.Text = "Пользователи";
            button_user.UseVisualStyleBackColor = false;
            button_user.Click += button_user_Click;
            // 
            // button_exhibitions
            // 
            button_exhibitions.BackColor = Color.Thistle;
            button_exhibitions.FlatStyle = FlatStyle.Popup;
            button_exhibitions.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_exhibitions.ForeColor = SystemColors.ControlText;
            button_exhibitions.Location = new Point(339, 13);
            button_exhibitions.Name = "button_exhibitions";
            button_exhibitions.Size = new Size(106, 35);
            button_exhibitions.TabIndex = 13;
            button_exhibitions.Text = "Выставки";
            button_exhibitions.UseVisualStyleBackColor = false;
            button_exhibitions.Click += button_exhibitions_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(button_update_exhibitions);
            panel3.Controls.Add(button_delete_exhibitions);
            panel3.Controls.Add(button_add_exhibitions);
            panel3.Controls.Add(label_name_museum2);
            panel3.Controls.Add(textBox_name_museum2);
            panel3.Controls.Add(label_price_exhibitions);
            panel3.Controls.Add(textBox_price_exhibitions);
            panel3.Controls.Add(label_sold_places);
            panel3.Controls.Add(textBox_sold_places);
            panel3.Controls.Add(label_date_end);
            panel3.Controls.Add(textBox_date_end);
            panel3.Controls.Add(label_date_start);
            panel3.Controls.Add(textBox_date_start);
            panel3.Controls.Add(label_name_exhibitions2);
            panel3.Controls.Add(textBox_name_exhibitions2);
            panel3.Controls.Add(dataGridView3);
            panel3.Location = new Point(35, 53);
            panel3.Name = "panel3";
            panel3.Size = new Size(899, 427);
            panel3.TabIndex = 14;
            // 
            // button_update_exhibitions
            // 
            button_update_exhibitions.BackColor = Color.Thistle;
            button_update_exhibitions.FlatStyle = FlatStyle.Popup;
            button_update_exhibitions.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_update_exhibitions.ForeColor = SystemColors.ControlText;
            button_update_exhibitions.Location = new Point(549, 331);
            button_update_exhibitions.Name = "button_update_exhibitions";
            button_update_exhibitions.Size = new Size(106, 35);
            button_update_exhibitions.TabIndex = 41;
            button_update_exhibitions.Text = "Изменить";
            button_update_exhibitions.UseVisualStyleBackColor = false;
            button_update_exhibitions.Click += button_update_exhibitions_Click;
            // 
            // button_delete_exhibitions
            // 
            button_delete_exhibitions.BackColor = Color.Thistle;
            button_delete_exhibitions.FlatStyle = FlatStyle.Popup;
            button_delete_exhibitions.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_delete_exhibitions.ForeColor = SystemColors.ControlText;
            button_delete_exhibitions.Location = new Point(548, 290);
            button_delete_exhibitions.Name = "button_delete_exhibitions";
            button_delete_exhibitions.Size = new Size(106, 35);
            button_delete_exhibitions.TabIndex = 40;
            button_delete_exhibitions.Text = "Удалить";
            button_delete_exhibitions.UseVisualStyleBackColor = false;
            button_delete_exhibitions.Click += button_delete_exhibitions_Click;
            // 
            // button_add_exhibitions
            // 
            button_add_exhibitions.BackColor = Color.Thistle;
            button_add_exhibitions.FlatStyle = FlatStyle.Popup;
            button_add_exhibitions.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_add_exhibitions.ForeColor = SystemColors.ControlText;
            button_add_exhibitions.Location = new Point(548, 249);
            button_add_exhibitions.Name = "button_add_exhibitions";
            button_add_exhibitions.Size = new Size(106, 35);
            button_add_exhibitions.TabIndex = 39;
            button_add_exhibitions.Text = "Добавить";
            button_add_exhibitions.UseVisualStyleBackColor = false;
            button_add_exhibitions.Click += button_add_exhibitions_Click;
            // 
            // label_name_museum2
            // 
            label_name_museum2.AutoSize = true;
            label_name_museum2.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_name_museum2.Location = new Point(114, 384);
            label_name_museum2.Name = "label_name_museum2";
            label_name_museum2.Size = new Size(152, 23);
            label_name_museum2.TabIndex = 37;
            label_name_museum2.Text = "Название музея";
            // 
            // textBox_name_museum2
            // 
            textBox_name_museum2.BackColor = Color.WhiteSmoke;
            textBox_name_museum2.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_name_museum2.ForeColor = SystemColors.WindowText;
            textBox_name_museum2.Location = new Point(272, 383);
            textBox_name_museum2.Name = "textBox_name_museum2";
            textBox_name_museum2.Size = new Size(216, 27);
            textBox_name_museum2.TabIndex = 36;
            // 
            // label_price_exhibitions
            // 
            label_price_exhibitions.AutoSize = true;
            label_price_exhibitions.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_price_exhibitions.Location = new Point(143, 350);
            label_price_exhibitions.Name = "label_price_exhibitions";
            label_price_exhibitions.Size = new Size(123, 23);
            label_price_exhibitions.TabIndex = 35;
            label_price_exhibitions.Text = "Цена билета";
            // 
            // textBox_price_exhibitions
            // 
            textBox_price_exhibitions.BackColor = Color.WhiteSmoke;
            textBox_price_exhibitions.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_price_exhibitions.ForeColor = SystemColors.WindowText;
            textBox_price_exhibitions.Location = new Point(272, 349);
            textBox_price_exhibitions.Name = "textBox_price_exhibitions";
            textBox_price_exhibitions.Size = new Size(216, 27);
            textBox_price_exhibitions.TabIndex = 34;
            textBox_price_exhibitions.TextChanged += textBox_price_exhibitions_TextChanged;
            textBox_price_exhibitions.KeyPress += textBox_price_exhibitions_KeyPress;
            // 
            // label_sold_places
            // 
            label_sold_places.AutoSize = true;
            label_sold_places.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_sold_places.Location = new Point(17, 317);
            label_sold_places.Name = "label_sold_places";
            label_sold_places.Size = new Size(253, 23);
            label_sold_places.TabIndex = 33;
            label_sold_places.Text = "Кол-во проданных билетов";
            // 
            // textBox_sold_places
            // 
            textBox_sold_places.BackColor = Color.WhiteSmoke;
            textBox_sold_places.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_sold_places.ForeColor = SystemColors.WindowText;
            textBox_sold_places.Location = new Point(272, 314);
            textBox_sold_places.Name = "textBox_sold_places";
            textBox_sold_places.Size = new Size(216, 27);
            textBox_sold_places.TabIndex = 32;
            textBox_sold_places.TextChanged += textBox_sold_places_TextChanged;
            textBox_sold_places.KeyPress += textBox_sold_places_KeyPress;
            // 
            // label_date_end
            // 
            label_date_end.AutoSize = true;
            label_date_end.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_date_end.Location = new Point(111, 281);
            label_date_end.Name = "label_date_end";
            label_date_end.Size = new Size(155, 23);
            label_date_end.TabIndex = 31;
            label_date_end.Text = "Дата окончания";
            // 
            // textBox_date_end
            // 
            textBox_date_end.BackColor = Color.WhiteSmoke;
            textBox_date_end.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_date_end.ForeColor = Color.Gray;
            textBox_date_end.Location = new Point(272, 280);
            textBox_date_end.Name = "textBox_date_end";
            textBox_date_end.Size = new Size(216, 27);
            textBox_date_end.TabIndex = 30;
            textBox_date_end.Text = "гггг-мм-дд";
            textBox_date_end.TextChanged += textBox_date_end_TextChanged;
            textBox_date_end.Enter += textBox_date_end_Enter;
            textBox_date_end.KeyPress += textBox_date_end_KeyPress;
            textBox_date_end.Leave += textBox_date_end_Leave;
            // 
            // label_date_start
            // 
            label_date_start.AutoSize = true;
            label_date_start.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_date_start.Location = new Point(143, 250);
            label_date_start.Name = "label_date_start";
            label_date_start.Size = new Size(122, 23);
            label_date_start.TabIndex = 29;
            label_date_start.Text = "Дата начала";
            // 
            // textBox_date_start
            // 
            textBox_date_start.BackColor = Color.WhiteSmoke;
            textBox_date_start.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_date_start.ForeColor = Color.Gray;
            textBox_date_start.Location = new Point(272, 249);
            textBox_date_start.Name = "textBox_date_start";
            textBox_date_start.Size = new Size(216, 27);
            textBox_date_start.TabIndex = 28;
            textBox_date_start.Text = "гггг-мм-дд";
            textBox_date_start.TextChanged += textBox_date_start_TextChanged;
            textBox_date_start.Enter += textBox_date_start_Enter;
            textBox_date_start.KeyPress += textBox_date_start_KeyPress;
            textBox_date_start.Leave += textBox_date_start_Leave;
            // 
            // label_name_exhibitions2
            // 
            label_name_exhibitions2.AutoSize = true;
            label_name_exhibitions2.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_name_exhibitions2.Location = new Point(84, 216);
            label_name_exhibitions2.Name = "label_name_exhibitions2";
            label_name_exhibitions2.Size = new Size(182, 23);
            label_name_exhibitions2.TabIndex = 27;
            label_name_exhibitions2.Text = "Название выставки";
            // 
            // textBox_name_exhibitions2
            // 
            textBox_name_exhibitions2.BackColor = Color.WhiteSmoke;
            textBox_name_exhibitions2.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_name_exhibitions2.ForeColor = SystemColors.WindowText;
            textBox_name_exhibitions2.Location = new Point(272, 215);
            textBox_name_exhibitions2.Name = "textBox_name_exhibitions2";
            textBox_name_exhibitions2.Size = new Size(216, 27);
            textBox_name_exhibitions2.TabIndex = 26;
            textBox_name_exhibitions2.TextChanged += textBox_name_exhibitions2_TextChanged;
            // 
            // dataGridView3
            // 
            dataGridView3.BackgroundColor = Color.Thistle;
            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { id_exhibitions, dataGridViewTextBoxColumn1, date_start, date_end, sold_places, price_exhibitions, dataGridViewTextBoxColumn2 });
            dataGridView3.Location = new Point(12, 17);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(884, 185);
            dataGridView3.TabIndex = 0;
            dataGridView3.CellClick += dataGridView3_CellClick;
            // 
            // id_exhibitions
            // 
            id_exhibitions.HeaderText = "id_exhibitions";
            id_exhibitions.Name = "id_exhibitions";
            id_exhibitions.Visible = false;
            id_exhibitions.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Название выставки";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 210;
            // 
            // date_start
            // 
            date_start.HeaderText = "Дата начала";
            date_start.Name = "date_start";
            date_start.Width = 120;
            // 
            // date_end
            // 
            date_end.HeaderText = "Дата окончания";
            date_end.Name = "date_end";
            date_end.Width = 120;
            // 
            // sold_places
            // 
            sold_places.HeaderText = "Кол-во проданных билетов";
            sold_places.Name = "sold_places";
            // 
            // price_exhibitions
            // 
            price_exhibitions.HeaderText = "Цена билета";
            price_exhibitions.Name = "price_exhibitions";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Название музея";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 190;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Thistle;
            ClientSize = new Size(984, 538);
            Controls.Add(panel3);
            Controls.Add(button_exhibitions);
            Controls.Add(button_user);
            Controls.Add(panel2);
            Controls.Add(button_picture);
            Controls.Add(button_exit);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Admin";
            Text = "Admin";
            Load += Admin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Label label1;
        private Button button_exit;
        private Button button_picture;
        private Button button_add_picture;
        private Label label_year_create_picture;
        private TextBox textBox_year_create_picture;
        private Label label_name_picture;
        private TextBox textBox_name_picture;
        private TextBox textBox_fio_author;
        private TextBox textBox_name_exhibitions;
        private TextBox textBox_name_janre;
        private Label label_name_exhibitions;
        private Label label_name_janre;
        private Label label_fio_author;
        private Button button_delete_picture;
        private Button button_update_picture;
        private Panel panel2;
        private DataGridView dataGridView2;
        private Button button_user;
        private TextBox textBox_name_museum;
        private TextBox textBox_user_role;
        private Label label_name_museum;
        private Label label_user_role;
        private Label label_password_user;
        private TextBox textBox_fio_user;
        private Label label_login_user;
        private TextBox textBox__login_user;
        private Label label_fio_user;
        private TextBox textBox_password_user;
        private Button button_update_user;
        private Button button_delete_user;
        private Button button_add_user;
        private Button button_exhibitions;
        private Panel panel3;
        private DataGridView dataGridView3;
        private Label label_name_exhibitions2;
        private TextBox textBox_name_exhibitions2;
        private Label label_date_end;
        private TextBox textBox_date_end;
        private Label label_date_start;
        private TextBox textBox_date_start;
        private Label label_name_museum2;
        private TextBox textBox_name_museum2;
        private Label label_price_exhibitions;
        private TextBox textBox_price_exhibitions;
        private Label label_sold_places;
        private TextBox textBox_sold_places;
        private Button button_update_exhibitions;
        private Button button_delete_exhibitions;
        private Button button_add_exhibitions;
        private DataGridViewTextBoxColumn id_user;
        private DataGridViewTextBoxColumn fio_user;
        private DataGridViewTextBoxColumn login_user;
        private DataGridViewTextBoxColumn password_user;
        private DataGridViewTextBoxColumn id_user_role;
        private DataGridViewTextBoxColumn id_museum;
        private DataGridViewTextBoxColumn id_picture;
        private DataGridViewTextBoxColumn name_picture;
        private DataGridViewTextBoxColumn year_create_picture;
        private DataGridViewTextBoxColumn fio_author;
        private DataGridViewTextBoxColumn name_janre;
        private DataGridViewTextBoxColumn name_exhibitions;
        private DataGridViewTextBoxColumn id_exhibitions;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn date_start;
        private DataGridViewTextBoxColumn date_end;
        private DataGridViewTextBoxColumn sold_places;
        private DataGridViewTextBoxColumn price_exhibitions;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}