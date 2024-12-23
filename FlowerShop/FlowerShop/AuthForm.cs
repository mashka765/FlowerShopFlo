using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FlowerShop.LoginForm;

namespace FlowerShop
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click;
        }

        

        private void AuthForm_Load(object sender, EventArgs e)
        {
          
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text; // Поле для ввода логина
            string password = txtPassword.Text; // Поле для ввода пароля

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // SQL-запрос для проверки логина, пароля и получения роли и ID пользователя
                    string query = @"
            SELECT u.КодПользователя, r.НазваниеРоли 
            FROM Пользователи u
            JOIN Роли r ON u.КодРоли = r.КодРоли
            WHERE u.Логин = @Login AND u.Пароль = @Password";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int currentUserId = reader.GetInt32(0); // Получаем КодПользователя
                            string role = reader.GetString(1);     // Получаем НазваниеРоли

                            Form nextForm = null;

                            // Открываем соответствующую форму в зависимости от роли
                            if (role == "Клиент")
                            {
                                this.Hide();
                                var catalogForm = new CatalogForm();
                                var cartForm = new CartForm(catalogForm, currentUserId); // Передаем currentUserId
                                catalogForm.FormClosed += (s, args) => this.Show();
                                catalogForm.ShowDialog();
                                nextForm = catalogForm;
                            }
                            else if (role == "Сотрудник")
                            {
                                this.Hide();
                                var orderListForm = new OrderListForm();
                                orderListForm.FormClosed += (s, args) => this.Show();
                                orderListForm.ShowDialog();
                                nextForm = new OrderListForm();
                            }
                            else if (role == "Администратор")
                            {
                                this.Hide();
                                new UserListForm().ShowDialog();
                                this.Show();
                            }
                            else
                            {
                                MessageBox.Show("Роль пользователя не распознана.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверные данные авторизации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при авторизации: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
    }

    }

