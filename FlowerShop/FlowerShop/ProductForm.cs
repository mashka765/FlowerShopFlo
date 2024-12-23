using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using static FlowerShop.LoginForm;

namespace FlowerShop
{
    public partial class ProductForm : Form
    {
        private readonly int? productId;
        public ProductForm(int productId)
        {
            InitializeComponent();
            this.productId = productId;
            this.Text = "Редактирование товара";
           //btnSave.Click += button2_Click;
            btnCancel.Click += btnCancel_Click;
        }

        public ProductForm()
        {
            InitializeComponent();
            productId = null; // Пустая форма для добавления
            this.Text = "Добавление нового товара";
            btnSave.Click += button2_Click;
            btnCancel.Click += btnCancel_Click;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();

                    // Преобразуем строковые значения в числовые, если это необходимо.
                    decimal price = 0;
                    if (!decimal.TryParse(txtPrice.Text, out price))
                    {
                        MessageBox.Show("Введите корректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Если это новый товар
                    if (productId == null)
                    {
                        // SQL-запрос для добавления нового товара
                        string insertQuery = @"
                    INSERT INTO Товары (НазваниеЦветка, Цена) 
                    VALUES (@ProductName, @Price)";

                        SqlCommand cmd = new SqlCommand(insertQuery, connection);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@Price", price); // Используем числовое значение
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Товар добавлен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // SQL-запрос для обновления существующего товара
                        string updateQuery = @"
                    UPDATE Товары 
                    SET НазваниеЦветка = @ProductName, Цена = @Price
                    WHERE КодЦветка = @ProductId";

                        SqlCommand cmd = new SqlCommand(updateQuery, connection);
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@Price", price); // Используем числовое значение
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Товар обновлен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (productId != null)
            {
                LoadProductDetails(); // Загружаем данные товара, если редактируем
            }
        }

        private void LoadProductDetails()
        {
            if (productId == null) return;

            using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Товары WHERE КодЦветка = @ProductId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtProductId.Text = reader["КодЦветка"].ToString();
                    txtProductName.Text = reader["НазваниеЦветка"].ToString();
                    txtPrice.Text = reader["Цена"].ToString();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
