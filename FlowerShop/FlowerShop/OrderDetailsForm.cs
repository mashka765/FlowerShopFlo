using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FlowerShop.LoginForm;

namespace FlowerShop
{
    public partial class OrderDetailsForm : Form
    {
        //public readonly int? OrderId;
        //private readonly int? orderId;
        private int? orderId;
        private readonly bool isNewOrder; // Флаг режима добавления

        public OrderDetailsForm(int? orderId = null) // Конструктор для добавления нового заказа
        {
            InitializeComponent();
            this.orderId = null;
            isNewOrder = true;
            this.Text = "Добавление нового заказа";
        }

        public OrderDetailsForm(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            isNewOrder = false;
            this.Text = "Редактирование заказа";
            //btnAddDetails.Click += btnAddDetails_Click;
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {

            // Заполняем ComboBox значениями статусов
            cmbOrderStatus.Items.Clear(); // Очищаем список перед добавлением
            cmbOrderStatus.Items.AddRange(new string[] { "Ожидание", "В доставке", "Выполнен" });

            if (isNewOrder)
            {
                ClearForm(); // Очищаем поля для добавления
            }
            else
            {
                LoadOrderDetails(); // Загружаем данные заказа для редактирования
            }

        }

        private void ClearForm()
        {
            txtOrderId.Text = "Автогенерация"; // Например, для автогенерируемого кода заказа
            txtOrderId.Enabled = false;
            txtOrderDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Дата текущая
            txtTotalAmount.Text = string.Empty;
            txtUserId.Text = string.Empty;
            txtDeliveryAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtSellerId.Text = string.Empty;
            cmbOrderStatus.SelectedIndex = -1;
            txtCompletionDate.Text = string.Empty;
        }

        private void LoadOrderDetails()
        {
            if (orderId == null) return;

            using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Заказы WHERE КодЗаказа = @OrderId";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtOrderId.Text = reader["КодЗаказа"].ToString();
                    txtOrderDate.Text = Convert.ToDateTime(reader["ДатаОформления"]).ToString("yyyy-MM-dd");
                    txtTotalAmount.Text = reader["СуммаЗаказа"].ToString();
                    txtUserId.Text = reader["КодПользователя"].ToString();
                    txtDeliveryAddress.Text = reader["АдресДоставки"].ToString();
                    txtPhone.Text = reader["Телефон"].ToString();
                    txtSellerId.Text = reader["КодПродавца"].ToString();
                    cmbOrderStatus.Text = reader["СтатусЗаказа"].ToString();
                    txtCompletionDate.Text = reader["ДатаВыполнения"] != DBNull.Value
                        ? Convert.ToDateTime(reader["ДатаВыполнения"]).ToString("yyyy-MM-dd")
                        : string.Empty;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
            {
                connection.Open();

                if (orderId == null) // Если `orderId` равен `null`, значит, это добавление
                {
                    string insertQuery = @"
                INSERT INTO Заказы (ДатаОформления, СуммаЗаказа, КодПользователя, АдресДоставки, Телефон, КодПродавца, СтатусЗаказа, ДатаВыполнения)
                VALUES (@OrderDate, @TotalAmount, @UserId, @DeliveryAddress, @Phone, @SellerId, @OrderStatus, @CompletionDate)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@OrderDate", txtOrderDate.Text);
                    insertCmd.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);
                    insertCmd.Parameters.AddWithValue("@UserId", txtUserId.Text);
                    insertCmd.Parameters.AddWithValue("@DeliveryAddress", txtDeliveryAddress.Text);
                    insertCmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    insertCmd.Parameters.AddWithValue("@SellerId", txtSellerId.Text);
                    insertCmd.Parameters.AddWithValue("@OrderStatus", cmbOrderStatus.SelectedItem?.ToString());

                    // Обработка ДатаВыполнения
                    if (string.IsNullOrWhiteSpace(txtCompletionDate.Text))
                    {
                        insertCmd.Parameters.AddWithValue("@CompletionDate", DBNull.Value);
                    }
                    else
                    {
                        insertCmd.Parameters.AddWithValue("@CompletionDate", DateTime.Parse(txtCompletionDate.Text));
                    }

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Заказ успешно добавлен!");
                }
                else // Редактирование существующей записи
                {
                    string updateQuery = @"
                UPDATE Заказы
                SET АдресДоставки = @DeliveryAddress, Телефон = @Phone, СтатусЗаказа = @OrderStatus, ДатаВыполнения = @CompletionDate
                WHERE КодЗаказа = @OrderId";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@OrderId", orderId);
                    updateCmd.Parameters.AddWithValue("@DeliveryAddress", txtDeliveryAddress.Text);
                    updateCmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    updateCmd.Parameters.AddWithValue("@OrderStatus", cmbOrderStatus.SelectedItem?.ToString());

                    // Обработка ДатаВыполнения
                    if (string.IsNullOrWhiteSpace(txtCompletionDate.Text))
                    {
                        updateCmd.Parameters.AddWithValue("@CompletionDate", DBNull.Value);
                    }
                    else
                    {
                        updateCmd.Parameters.AddWithValue("@CompletionDate", DateTime.Parse(txtCompletionDate.Text));
                    }

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Данные заказа успешно обновлены!");
                }
            }

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddDetails_Click(object sender, EventArgs e)
        {
            if (orderId == null)
            {
                MessageBox.Show("Не выбран заказ для добавления деталей.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var orderDetailForm = new OrderDetailForm(orderId.Value); // Используем orderId.Value, так как мы уже проверили, что оно не null
            orderDetailForm.ShowDialog();
        }
    }
}
