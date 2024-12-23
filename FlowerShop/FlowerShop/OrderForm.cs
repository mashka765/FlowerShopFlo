using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FlowerShop.LoginForm;

namespace FlowerShop
{
    public partial class OrderForm : Form
    {
        private int currentUserId;
        private List<CartForm.CartItem> cartItems;
        public OrderForm(int currentUserId, List<CartForm.CartItem> cartItems)
        {
            InitializeComponent();
            this.currentUserId = currentUserId;
            this.cartItems = cartItems;
            //btnOrder.Click += btnOrder_Click;
            btnCancel.Click += btnCancel_Click;

            PopulateOrderDetails();
        }

        private void PopulateOrderDetails()
        {
            foreach (var item in cartItems)
            {
                // Выводим информацию о товарах в корзине (например, в DataGridView или Label)
                Console.WriteLine($"Товар: {item.ProductName}, Цена: {item.Price}, Количество: {item.Quantity}");
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            var catalogForm = new CatalogForm();
            var cartForm = new CartForm(catalogForm, currentUserId); // Передаем текущую форму CatalogForm в CartForm
            // Передаем cartForm в CatalogForm
            catalogForm.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            string deliveryAddress = txtDeliveryAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(deliveryAddress) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();

                    // Создаем заказ
                    string insertOrderQuery = @"
                INSERT INTO Заказы (КодПользователя, ДатаОформления, АдресДоставки, Телефон, СтатусЗаказа)
                OUTPUT INSERTED.КодЗаказа
                VALUES (@UserId, @OrderDate, @DeliveryAddress, @Phone, @Status)";

                    SqlCommand orderCmd = new SqlCommand(insertOrderQuery, connection);
                    orderCmd.Parameters.AddWithValue("@UserId", currentUserId);
                    orderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCmd.Parameters.AddWithValue("@DeliveryAddress", deliveryAddress);
                    orderCmd.Parameters.AddWithValue("@Phone", phone);
                    orderCmd.Parameters.AddWithValue("@Status", "Ожидание");

                    int orderId = (int)orderCmd.ExecuteScalar();

                    // Добавляем детали заказа
                    foreach (var item in cartItems)
                    {
                        string insertDetailsQuery = @"
                    INSERT INTO Детали_заказа (КодЗаказа, КодЦветка, Стоимость, Количество)
                    VALUES (@OrderId, @ProductId, @Price, @Quantity)";
                        SqlCommand detailsCmd = new SqlCommand(insertDetailsQuery, connection);
                        detailsCmd.Parameters.AddWithValue("@OrderId", orderId);
                        detailsCmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        detailsCmd.Parameters.AddWithValue("@Price", item.Price);
                        detailsCmd.Parameters.AddWithValue("@Quantity", item.Quantity);

                        detailsCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Заказ успешно оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при оформлении заказа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
