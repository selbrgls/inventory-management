using System;

namespace InventoryApp.Services
{
    public class InventoryService
    {
        private string[,] products;
        private string[,] initialStock;

        public InventoryService()
        {
            products = new string[2, 3];

            products[0, 0] = "Apples";
            products[0, 1] = "Milk";
            products[0, 2] = "Bread";

            products[1, 0] = "10";
            products[1, 1] = "5";
            products[1, 2] = "20";

            initialStock = new string[2, 3];
            Array.Copy(products, initialStock, products.Length);
        }

        public string GetProductName(int index) => products[0, index];
        public string GetStockQuantity(int index) => products[1, index];
        public int GetProductCount() => products.GetLength(1);

        public void UpdateStock(int index, string newQuantity)
        {
            products[1, index] = newQuantity;
        }

        public void ResetInventory()
        {
            Array.Copy(initialStock, products, products.Length);
        }
    }
}
