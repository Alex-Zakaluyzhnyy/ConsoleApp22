using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class ProductInBasket
    {

        /// <summary>
        /// Лист, описывающий товары в продуктовой корзине
        /// </summary>
        List<Product> products = new List<Product>();

        /// <summary>
        /// Количество продуктов в корзине
        /// </summary>
        public int Сount { get { return products.Count; } }

        /// <summary>
        /// Пустой конструктор класса
        /// </summary>
        public ProductInBasket() { }

        /// <summary>
        /// Метод добавления элементов в список
        /// </summary>
        /// <param name="product">Продукт питания</param>
        public void ProductAdd(Product product)
        {
            Console.Write("Введите стоимость продукта: ");
            product.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"{"\n"}\"{product}\" был добавлен в корзину\n");
            products.Add(product);
        }

        /// <summary>
        /// Вывод списка в консоль
        /// </summary>
        public void PrintList()
        {
            if (Сount > 0)
            {
                double summ = 0;
                foreach (var fruit in products)
                {
                    Console.WriteLine(fruit);
                }

                for(int i = 0; i < Сount; i++)
                {
                    summ += products[i].Price;
                }
                Console.WriteLine($"Количество наименований в корзине {Сount}, общей стоимостью {summ}");
            }

            else
            {
                Console.WriteLine("Список пуст!");
            }

        }

    }
}
    