using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FlowerShop.LoginForm;
namespace FlowerShop
{
    public partial class OrderListForm : Form
    {
        private readonly int? orderId;
        public OrderListForm()
        {
            InitializeComponent();
            //btnViewDetails.Click += btnViewDetails_Click;
            //btnAddOrder.Click += btnAddOrder_Click;
            //btnEditOrder.Click += btnEditOrder_Click;
            //btnDeleteOrder.Click += btnDeleteOrder_Click;
            //button5.Click += button5_Click; // Новая кнопка "Товары"
            this.orderId = orderId;
            LoadOrders();

        }



        private void LoadOrders()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Заказы", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvOrders.DataSource = table; // Привязка данных к DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заказов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {

        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Выберите заказ для просмотра деталей.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["КодЗаказа"].Value);
            var orderDetailForm = new OrderDetailForm(orderId);
            orderDetailForm.ShowDialog();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var form = new OrderDetailsForm(null);
            form.ShowDialog();
            LoadOrders();
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {

            if (dgvOrders.CurrentRow == null || dgvOrders.CurrentRow.Cells["КодЗаказа"].Value == null)
            {
                MessageBox.Show("Выберите заказ для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID заказа из выбранной строки
            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["КодЗаказа"].Value);

            // Передаем orderId в OrderDetailsForm для редактирования
            var form = new OrderDetailsForm(orderId);
            form.ShowDialog();
            LoadOrders();// Обновляем список товаров после редактирования
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Выберите заказ для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Показать подтверждение удаления
            var result = MessageBox.Show("Вы уверены, что хотите удалить этот заказ?", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string orderId = dgvOrders.CurrentRow.Cells["КодЗаказа"].Value.ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Заказы WHERE КодЗаказа = @OrderId", connection);
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Заказ удален успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders(); // Перезагружаем список заказов, чтобы обновить DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении заказа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProductListForm productListForm = new ProductListForm();
           productListForm.Show();

        }
    }
}
