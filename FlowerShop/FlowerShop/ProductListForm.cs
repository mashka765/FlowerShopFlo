using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FlowerShop.LoginForm;

namespace FlowerShop
{
    public partial class ProductListForm : Form
    {
        private readonly int? productId;
        public ProductListForm()
        {
            InitializeComponent();
            //btnAddProduct.Click += btnAddProduct_Click;
            //btnEditProduct.Click += btnEditProduct_Click;
            //btnDeleteProduct.Click += btnDeleteProduct_Click;
            btnBack.Click += btnBack_Click; // Кнопка "Назад"
            this.productId = productId;
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Товары", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvProducts.DataSource = table; // Привязка данных к DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки товаров: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            LoadProducts();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID товара из выбранной строки
            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["КодЦветка"].Value);

            // Передаем productId в конструктор для редактирования товара
            var productForm = new ProductForm(productId);
            productForm.ShowDialog();
            LoadProducts(); // Обновляем список товаров после редактирования
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Показать подтверждение удаления
            var result = MessageBox.Show("Вы уверены, что хотите удалить этот товар?", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["КодЦветка"].Value); // Получаем ID товара

                try
                {
                    using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Товары WHERE КодЦветка = @ProductId", connection);
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Товар успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts(); // Перезагрузить список товаров после удаления
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении товара: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
