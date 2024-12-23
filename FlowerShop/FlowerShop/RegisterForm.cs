using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FlowerShop
{
    public partial class RegisterForm : Form
    {
        private static string connectionString = "Server=ADCLG1;Database=FlowerShopFlo;Trusted_Connection=True;";
        public RegisterForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void InitializeCustomComponents()
        {
            // Создание и настройка элементов
            Label lblFirstName = new Label() { Text = "Имя:", Location = new System.Drawing.Point(20, 20) };
            TextBox txtFirstName = new TextBox() { Name = "txtFirstName", Location = new System.Drawing.Point(150, 20), Width = 200 };

            Label lblLastName = new Label() { Text = "Фамилия:", Location = new System.Drawing.Point(20, 60) };
            TextBox txtLastName = new TextBox() { Name = "txtLastName", Location = new System.Drawing.Point(150, 60), Width = 200 };

            Label lblMiddleName = new Label() { Text = "Отчество:", Location = new System.Drawing.Point(20, 100) };
            TextBox txtMiddleName = new TextBox() { Name = "txtMiddleName", Location = new System.Drawing.Point(150, 100), Width = 200 };

            Label lblPhone = new Label() { Text = "Телефон:", Location = new System.Drawing.Point(20, 140) };
            TextBox txtPhone = new TextBox() { Name = "txtPhone", Location = new System.Drawing.Point(150, 140), Width = 200 };

            Label lblLogin = new Label() { Text = "Логин:", Location = new System.Drawing.Point(20, 180) };
            TextBox txtLogin = new TextBox() { Name = "txtLogin", Location = new System.Drawing.Point(150, 180), Width = 200 };

            Label lblPassword = new Label() { Text = "Пароль:", Location = new System.Drawing.Point(20, 220) };
            TextBox txtPassword = new TextBox() { Name = "txtPassword", Location = new System.Drawing.Point(150, 220), Width = 200, PasswordChar = '*' };

            Button btnRegister = new Button() { Text = "Зарегистрироваться", Location = new System.Drawing.Point(150, 260) };
            btnRegister.Click += btnRegister_Click;

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            // Считываем данные с формы
            string firstName = this.Controls["txtFirstName"].Text.Trim();
            string lastName = this.Controls["txtLastName"].Text.Trim();
            string middleName = this.Controls["txtMiddleName"].Text.Trim();
            string phone = this.Controls["txtPhone"].Text.Trim();
            string login = this.Controls["txtLogin"].Text.Trim();
            string password = this.Controls["txtPassword"].Text.Trim();

            // Установим КодРоли для клиента 
            int clientRoleCode = 1;

            // Проверка на заполненность полей
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                // Сохранение в базу данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Пользователи (Фамилия, Имя, Отчество, Логин, Пароль, КодРоли, Телефон) " +
                                   "VALUES (@LastName, @FirstName, @MiddleName, @Login, @Password, @RoleCode, @Phone)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@MiddleName", middleName);
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@RoleCode", clientRoleCode);
                        command.Parameters.AddWithValue("@Phone", phone);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Регистрация прошла успешно!");
                Application.Restart();
                //this.Close(); // Закрыть форму регистрации
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
