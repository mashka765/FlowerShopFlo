using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Tests
{
    public class CatalogFormTests
    {
        [Fact]
        public void AddToCart_Should_AddItemToCart()
        {
            // Arrange
            var cartFormMock = new Mock<CartForm>(null, 1);
            var catalogForm = new CatalogForm(cartFormMock.Object, 1);

            // Setup test product data
            var productsTable = new DataTable();
            productsTable.Columns.Add("КодЦветка", typeof(int));
            productsTable.Columns.Add("НазваниеЦветка", typeof(string));
            productsTable.Columns.Add("Цена", typeof(decimal));
            productsTable.Rows.Add(1, "Роза", 50);

            catalogForm.GetType().GetField("productsTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(catalogForm, productsTable);

            var dgvCatalog = new DataGridView();
            dgvCatalog.DataSource = productsTable;
            catalogForm.Controls.Add(dgvCatalog);

            // Simulate selection in DataGridView
            dgvCatalog.CurrentCell = dgvCatalog.Rows[0].Cells[0];

            // Act
            catalogForm.GetType().GetMethod("btnAddToCart_Click", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(catalogForm, new object[] { null, null });

            // Assert
            cartFormMock.Verify(c => c.AddToCart(1, "Роза", 50), Times.Once);
        }
    }

    public class CartFormTests
    {
        [Fact]
        public void AddToCart_Should_UpdateCartView()
        {
            // Arrange
            var catalogFormMock = new Mock<CatalogForm>();
            var cartForm = new CartForm(catalogFormMock.Object, 1);

            var dgvCart = new DataGridView();
            cartForm.Controls.Add(dgvCart);
            cartForm.GetType().GetMethod("SetupDataGridView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.Invoke(cartForm, null);

            // Act
            cartForm.AddToCart(1, "Роза", 50);

            // Assert
            Assert.Single(dgvCart.Rows.Cast<DataGridViewRow>());
            Assert.Equal("Роза", dgvCart.Rows[0].Cells["ProductName"].Value);
        }

        [Fact]
        public void DeleteFromCart_Should_RemoveItemFromCart()
        {
            // Arrange
            var catalogFormMock = new Mock<CatalogForm>();
            var cartForm = new CartForm(catalogFormMock.Object, 1);

            cartForm.AddToCart(1, "Роза", 50);

            var dgvCart = cartForm.Controls.OfType<DataGridView>().First();
            dgvCart.CurrentCell = dgvCart.Rows[0].Cells[0];

            // Act
            cartForm.GetType().GetMethod("btnDelete_Click", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(cartForm, new object[] { null, null });

            // Assert
            Assert.Empty(dgvCart.Rows.Cast<DataGridViewRow>());
        }

        [Fact]
        public void CalculateTotalAmount_Should_ReturnCorrectTotal()
        {
            // Arrange
            var catalogFormMock = new Mock<CatalogForm>();
            var cartForm = new CartForm(catalogFormMock.Object, 1);

            cartForm.AddToCart(1, "Роза", 50);
            cartForm.AddToCart(2, "Тюльпан", 30);

            // Act
            var total = cartForm.GetType().GetMethod("CalculateTotalAmount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(cartForm, null);

            // Assert
            Assert.Equal(80m, total);
        }
    }
}
