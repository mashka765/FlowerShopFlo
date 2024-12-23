using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FlowerShop.LoginForm;

namespace FlowerShop
{
    public partial class UserForm : Form
    {
        private readonly int? userId;
        public UserForm()
        {
            InitializeComponent();
            this.userId = null;
            this.Text = "Добавление нового пользователя";
        }

        public UserForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.Text = "Редактирование пользователя";
            LoadUserDetails();
        }

        private void LoadUserDetails()
        {
            if (userId == null) return;

            using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Пользователи WHERE КодПользователя = @UserId";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtUserId.Text = reader["КодПользователя"].ToString();
                    txtLastName.Text = reader["Фамилия"].ToString();
                    txtFirstName.Text = reader["Имя"].ToString();
                    txtMiddleName.Text = reader["Отчество"].ToString();
                    txtLogin.Text = reader["Логин"].ToString();
                    txtPassword.Text = reader["Пароль"].ToString();
                    txtRoleCode.Text = reader["КодРоли"].ToString();
                    txtPhone.Text = reader["Телефон"].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
            {
                connection.Open();

                if (userId == null) // Добавление нового пользователя
                {
                    string insertQuery = @"
                    INSERT INTO Пользователи (Фамилия, Имя, Отчество, Логин, Пароль, КодРоли, Телефон)
                    VALUES (@LastName, @FirstName, @MiddleName, @Login, @Password, @RoleCode, @Phone)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    insertCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    insertCmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    insertCmd.Parameters.AddWithValue("@Login", txtLogin.Text);
                    insertCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    insertCmd.Parameters.AddWithValue("@RoleCode", txtRoleCode.Text);
                    insertCmd.Parameters.AddWithValue("@Phone", txtPhone.Text);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь успешно добавлен!");
                }
                else // Редактирование существующего пользователя
                {
                    string updateQuery = @"
                    UPDATE Пользователи
                    SET Фамилия = @LastName, Имя = @FirstName, Отчество = @MiddleName, Логин = @Login,
                        Пароль = @Password, КодРоли = @RoleCode, Телефон = @Phone
                    WHERE КодПользователя = @UserId";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@UserId", userId);
                    updateCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    updateCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    updateCmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    updateCmd.Parameters.AddWithValue("@Login", txtLogin.Text);
                    updateCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    updateCmd.Parameters.AddWithValue("@RoleCode", txtRoleCode.Text);
                    updateCmd.Parameters.AddWithValue("@Phone", txtPhone.Text);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Данные пользователя успешно обновлены!");
                }
            }

            this.Hide();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbRole_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
