using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FlowerShop.LoginForm;

namespace FlowerShop
{
    public partial class CatalogForm : Form
    {

        private CartForm cartForm; // Ссылка на форму корзины
        private DataTable productsTable;
        private int currentUserId;
        public CatalogForm(CartForm cartForm = null, int currentUserId = 0)
        {
            InitializeComponent();
            this.cartForm = cartForm ?? new CartForm(this, currentUserId); // Сохранение переданного объекта cartForm
            this.currentUserId = currentUserId;
            btnCart.Click += btnCart_Click;
            LoadCatalog();
        }

        private void LoadCatalog()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Товары", connection);
                    productsTable = new DataTable();
                    adapter.Fill(productsTable);
                    dgvCatalog.DataSource = productsTable; // Привязка данных к DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки каталога: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCatalogData(DataGridView grid)
        {

        }


        private void CatalogForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvCatalog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для добавления в корзину.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем данные выбранного товара
            DataRow selectedRow = ((DataRowView)dgvCatalog.CurrentRow.DataBoundItem).Row;
            int productId = Convert.ToInt32(selectedRow["КодЦветка"]);
            string productName = selectedRow["НазваниеЦветка"].ToString();
            decimal productPrice = Convert.ToDecimal(selectedRow["Цена"]);

            cartForm.AddToCart(productId, productName, productPrice); // Добавляем товар в корзину
            MessageBox.Show("Товар успешно добавлен в корзину.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            if (cartForm == null || cartForm.IsDisposed)
            {
                cartForm = new CartForm(this, currentUserId); // Создаем новый экземпляр CartForm, если его нет
            }

            cartForm.Show();  // Показываем корзину
            //this.Hide();
        }
    }
}

