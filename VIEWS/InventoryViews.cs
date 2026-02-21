using System;

namespace InventoryApp.Views
{
    public class InventoryView
    {
        private Services.InventoryService _service;
        private bool _isRunning = true;

        public InventoryView()
        {
            _service = new Services.InventoryService();
        }

        public void Run()
        {
            while (_isRunning)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewInventory();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        ResetInventory();
                        break;
                    case "4":
                        _isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void ViewInventory()
        {
            Console.WriteLine("\n--- Inventory ---");
            for (int i = 0; i < _service.GetProductCount(); i++)
            {
                Console.WriteLine($"{i + 1}. {_service.GetProductName(i)}: {_service.GetStockQuantity(i)}");
            }
        }

        private void UpdateStock()
        {
            ViewInventory();
            Console.Write("Enter product number: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= 3)
            {
                Console.Write("Enter new quantity: ");
                string qty = Console.ReadLine();
                _service.UpdateStock(num - 1, qty);
                Console.WriteLine("Updated!");
            }
            else
            {
                Console.WriteLine("Invalid product.");
            }
        }

        private void ResetInventory()
        {
            _service.ResetInventory();
            Console.WriteLine("Inventory reset to original values.");
        }
    }
}
