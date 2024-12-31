using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab4Docker;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ініціалізація меню та менеджера замовлень
            var menu = new Menu(); // Створюємо меню
            var orderManager = new OrderManager(); // Створюємо менеджер замовлень

            // Додати кілька страв у меню для демонстрації
            menu.AddDish(new Dish("Pizza", 8.99m)); // Додаємо піцу
            menu.AddDish(new Dish("Pasta", 7.99m)); // Додаємо пасту
            menu.AddDish(new Dish("Salad", 4.99m)); // Додаємо салат

            // Основний цикл програми
            while (true)
            {
                // Виведення меню програми
                Console.WriteLine("\n=== Restaurant App ===");
                Console.WriteLine("1. Show Menu");
                Console.WriteLine("2. Create Order");
                Console.WriteLine("3. Add Dish to Order");
                Console.WriteLine("4. Remove Dish from Order");
                Console.WriteLine("5. View Order Status");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine(); // Читання вибору користувача
                switch (input)
                {
                    case "1":
                        ShowMenu(menu); // Виведення меню страв
                        break;
                    case "2":
                        CreateOrder(orderManager); // Створення нового замовлення
                        break;
                    case "3":
                        AddDishToOrder(orderManager, menu); // Додавання страви до замовлення
                        break;
                    case "4":
                        RemoveDishFromOrder(orderManager); // Видалення страви із замовлення
                        break;
                    case "5":
                        ViewOrderStatus(orderManager); // Перегляд статусу замовлення
                        break;
                    case "6":
                        return; // Вихід із програми
                    default:
                        Console.WriteLine("Invalid option. Try again."); // Обробка невірного вводу
                        break;
                }
            }
        }

        // Метод для виведення меню страв
        static void ShowMenu(Menu menu)
        {
            Console.WriteLine("\n=== Menu ===");
            foreach (var dish in menu.GetDishes()) // Ітеруємо через всі страви
            {
                Console.WriteLine($"- {dish.Name}: ${dish.Price}"); // Виводимо назву та ціну страви
            }
        }

        // Метод для створення нового замовлення
        static void CreateOrder(OrderManager orderManager)
        {
            var orderId = orderManager.CreateOrder(); // Створюємо нове замовлення
            Console.WriteLine($"Order {orderId} created."); // Повідомлення про успіх
        }

        // Метод для додавання страви до замовлення
        static void AddDishToOrder(OrderManager orderManager, Menu menu)
        {
            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out var orderId)) // Перевіряємо, чи коректно введено номер замовлення
            {
                Console.WriteLine("Invalid Order ID."); // Помилка при некоректному вводу
                return;
            }

            Console.Write("Enter Dish Name: ");
            var dishName = Console.ReadLine(); // Читання назви страви

            var dish = menu.GetDishes().Find(d => d.Name == dishName); // Пошук страви у меню
            if (dish == null) // Якщо страва не знайдена
            {
                Console.WriteLine("Dish not found in menu.");
                return;
            }

            orderManager.AddDishToOrder(orderId, dish); // Додаємо страву до замовлення
            Console.WriteLine($"Dish '{dish.Name}' added to Order {orderId}."); // Повідомлення про успіх
        }

        // Метод для видалення страви із замовлення
        static void RemoveDishFromOrder(OrderManager orderManager)
        {
            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out var orderId)) // Перевіряємо, чи коректно введено номер замовлення
            {
                Console.WriteLine("Invalid Order ID."); // Помилка при некоректному вводу
                return;
            }

            Console.Write("Enter Dish Name: ");
            var dishName = Console.ReadLine(); // Читання назви страви

            try
            {
                orderManager.RemoveDishFromOrder(orderId, dishName); // Видаляємо страву із замовлення
                Console.WriteLine($"Dish '{dishName}' removed from Order {orderId}."); // Повідомлення про успіх
            }
            catch (Exception ex) // Обробка виключень
            {
                Console.WriteLine($"Error: {ex.Message}"); // Виведення повідомлення про помилку
            }
        }

        // Метод для перегляду статусу замовлення
        static void ViewOrderStatus(OrderManager orderManager)
        {
            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out var orderId)) // Перевіряємо, чи коректно введено номер замовлення
            {
                Console.WriteLine("Invalid Order ID."); // Помилка при некоректному вводу
                return;
            }

            try
            {
                var status = orderManager.GetOrderStatus(orderId); // Отримуємо статус замовлення
                Console.WriteLine($"Order {orderId} Status: {status}"); // Виведення статусу
            }
            catch (Exception ex) // Обробка виключень
            {
                Console.WriteLine($"Error: {ex.Message}"); // Виведення повідомлення про помилку
            }
        }
    }
}
