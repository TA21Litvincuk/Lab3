using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4Docker
{
    public class Dish
    {
        // Назва страви
        public string Name { get; set; }

        // Ціна страви
        public decimal Price { get; set; }

        // Конструктор для створення страви з назвою та ціною
        public Dish(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
