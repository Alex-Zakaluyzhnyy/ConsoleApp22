using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Product
    {
        #region Свойства

        /// <summary>
        /// Наименование продукта питания
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double Number { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public string Unit { get; set;}

        /// <summary>
        /// Итоговая стоимость
        /// </summary>
        public double Price { get; set; }
        #endregion

        #region Конструкторы
        public Product()
        {
            Console.WriteLine("Введите данные о товаре: ");
            Console.Write("Наименование продукта питания: ");
            this.Name = Console.ReadLine();
            Console.Write("Введите количество: ");
            while(true)
            {
                if (double.TryParse(Console.ReadLine(), out double n))
                {
                    this.Number = n;
                    break;
                }
                else
                {
                    Console.WriteLine("Введено неверное значение, повторите ввод.");
                    continue;
                }
            }
            Console.Write("Введите единицу измерения: ");
            this.Unit = Console.ReadLine();             
        }

        public Product (int i)
        { }

        public Product (string name, double number, string unit)
        {
            this.Name = name;
            this.Number = number;
            this.Unit = unit;
        }

        #endregion

        /// <summary>
        /// Перегрузка метода ToString()
        /// </summary>
        /// <returns> Выходная строка, которая печатается в консоль</returns>
        public override string ToString()
        {
            if(this.Price == 0)
            {
                return $"Наименование продукта питания: {Name}\t Количество: {Number}\t Единица измерения: {Unit}\t Стоимость: -";
            }
            else
            {
                return $"Наименование продукта питания: {Name}\t Количество: {Number}\t Единица измерения: {Unit}\t Стоимость: {Price}";
            }
        }

    }
}
