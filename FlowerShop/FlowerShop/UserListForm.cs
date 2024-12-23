using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FlowerShop.LoginForm;

namespace FlowerShop
{
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Пользователи", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvUsers.DataSource = table; // Привязка данных к DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки пользователей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var userForm = new UserForm();
            userForm.ShowDialog();
            LoadUsers();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["КодПользователя"].Value);
            var userForm = new UserForm(userId);
            userForm.ShowDialog();
            LoadUsers();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить этого пользователя?", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["КодПользователя"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Пользователи WHERE КодПользователя = @UserId", connection);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Пользователь успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении пользователя: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }
        }
}
