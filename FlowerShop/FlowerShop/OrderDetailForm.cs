using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FlowerShop.LoginForm;

namespace FlowerShop
{
    public partial class OrderDetailForm : Form
    {
        public int orderId;// Свойство для передачи текущего КодЗаказа
        public OrderDetailForm(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            LoadFlowers();
            LoadOrderDetails();
        }

        private void LoadFlowers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT КодЦветка, НазваниеЦветка FROM ДеталиЗаказа", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    cmbFlowerId.DataSource = table;
                    cmbFlowerId.DisplayMember = "Название";
                    cmbFlowerId.ValueMember = "КодЦветка";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки цветов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(
                        "SELECT ДеталиЗаказа.НазваниеЦветка, ДеталиЗаказа.Количество " +
                        "FROM ДеталиЗаказа " +
                        "JOIN ДеталиЗаказа ON ДеталиЗаказа.КодЦветка = Цветы.КодЦветка " +
                        "WHERE ДеталиЗаказа.КодЗаказа = @OrderId", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@OrderId", orderId);

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvOrderDetails.DataSource = table; // Привязка данных к DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки деталей заказа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            // Установить orderId или использовать его для загрузки данных
            txtOrderId.Text = orderId.ToString();
            txtOrderId.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO ДеталиЗаказа (КодЗаказа, КодЦветка, Количество) VALUES (@OrderId, @FlowerId, @Quantity)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.Parameters.AddWithValue("@FlowerId", cmbFlowerId.SelectedValue);
                    cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Деталь успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadOrderDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении детали: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Сохранение завершено!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
