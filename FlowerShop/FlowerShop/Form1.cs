using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShop
{
    public partial class LoginForm : Form
    {
        

        public static class Database
        {
            public static string ConnectionString = "Server=HOME-PC\\SQLEXPRESS;Database=FlowerShopFlo;Trusted_Connection=True;";
        }

        public LoginForm()
        {
            InitializeComponent();
            Login();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void Login()
        {
            this.Text = "Форма входа";
            this.Width = 400;
            this.Height = 300;

            Button loginButton = new Button { Text = "Авторизоваться", Left = 100, Top = 100, Width = 200, Height = 30, BackColor = Color.FromArgb(116, 131, 103 )};
            Button registerButton = new Button { Text = "Зарегистрироваться", Left = 100, Top = 150, Width = 200,Height = 30, BackColor = Color.FromArgb(116, 131, 103) };

            loginButton.Click += (s, e) =>
            {
                this.Hide(); // Скрываем форму входа
                var authForm = new AuthForm();
                authForm.FormClosed += (sender, args) => this.Close(); // Закрываем LoginForm при закрытии AuthForm
                authForm.Show();
            };

            registerButton.Click += (s, e) =>
            {
                this.Hide(); // Скрываем форму входа
                var registerForm = new RegisterForm();
                registerForm.FormClosed += (sender, args) => this.Close(); // Закрываем LoginForm при закрытии RegisterForm
                registerForm.Show();
            };

            this.Controls.Add(loginButton);
            this.Controls.Add(registerButton);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
