using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FlowerShop.LoginForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace FlowerShop
{
    public partial class CartForm : Form
    {
        private readonly List<CartItem> cartItems; // Список товаров в корзине
        private CartForm cartForm;
        private CatalogForm catalogForm;

        public CartForm(CatalogForm catalogForm, int currentUserId)
        {
            InitializeComponent();
            this.catalogForm = catalogForm;
            Session.CurrentUserId = currentUserId;
            cartItems = new List<CartItem>();
            cartForm = this;
            // Привязываем обработчики событий
            btnAddFlowers.Click += btnAddFlowers_Click;
            btnBack.Click += btnBack_Click;
            btnCheckout.Click += btnCheckout_Click;
            SetupDataGridView();

            UpdateCart();
        }

        /// <summary>
        /// Метод для добавления товара в корзину.
        /// </summary>
        /// <param name="productId">Код товара</param>
        /// <param name="productName">Наименование товара</param>
        /// <param name="productPrice">Цена товара</param>
        public void AddToCart(int productId, string productName, decimal productPrice)
        {
            var existingItem = cartItems.Find(item => item.ProductId == productId);
            if (existingItem != null)
            {
                // Если товар уже есть в корзине, увеличиваем его количество
                existingItem.Quantity++;
            }
            else
            {
                // Если товара нет в корзине, добавляем его с количеством 1
                cartItems.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = productPrice,
                    Quantity = 1
                });
            }

            UpdateCart();
        }

        private void UpdateCart()
        {
            dgvCart.Rows.Clear();
            foreach (var item in cartItems)
            {
                dgvCart.Rows.Add(item.ProductId, item.ProductName, item.Price, item.Price * item.Quantity); // Отображаем товар без столбца Количество
            }
        }

        

        private void CartGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void SetupDataGridView()
        {
            // Очистка старых столбцов (если есть)
            dgvCart.Columns.Clear();

            // Добавление столбцов
            dgvCart.Columns.Add("ProductId", "КодЦветка");
            dgvCart.Columns.Add("ProductName", "НазваниеЦветка");
            dgvCart.Columns.Add("Price", "Цена");
            dgvCart.Columns.Add("TotalPrice", "Общая Цена");
        }
        private void CartForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
        }

        private void btnAddFlowers_Click(object sender, EventArgs e)
        {
            //this.Hide();  // Скрываем корзину
            catalogForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();  // Скрываем корзину
            catalogForm.Show();
        }

        public static class Session
        {
            public static int CurrentUserId { get; set; }
        }

        public void SetCurrentUserId(int userId)
        {
            Session.CurrentUserId = userId;
        }

        // Метод для получения текущего пользователя:
        private int GetCurrentUserId()
                {
                    if (Session.CurrentUserId == 0)
                        throw new Exception("Не удалось определить текущего пользователя.");
                    return Session.CurrentUserId;
                }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Корзина пуста. Добавьте товары перед оформлением заказа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Передаем текущую корзину и ID пользователя в OrderForm
            var orderForm = new OrderForm(Session.CurrentUserId, cartItems);
            this.Hide();
            orderForm.ShowDialog();
            this.Show();
        }

        private decimal CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in cartItems)
            {
                total += item.Price * item.Quantity;
            }

            return total;
        }

        public class CartItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для удаления из корзины.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvCart.CurrentRow.Cells[0].Value);
            var itemToRemove = cartItems.Find(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }

            UpdateCart();
        }
    }
}
