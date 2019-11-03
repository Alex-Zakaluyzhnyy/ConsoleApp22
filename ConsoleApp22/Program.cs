using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        /// <summary>
        /// Метод, отвечающий за интерактивное общение с пользователем
        /// </summary>
        public static void PrintInformation()
        {
            Console.Clear();
            Console.WriteLine("Выберете действия: ");
            Console.WriteLine("1 - Добавить в список новый продукт");
            Console.WriteLine("2 - Вывести на экран список продуктов");
            Console.WriteLine("3 - Сохранить в файл список продуктов");
            Console.WriteLine("4 - Считать список продуктов из файла");
            Console.WriteLine("5 - Вычеркнуть продукт из списка");
            Console.WriteLine("6 - Вывести на экран список продуктов в продуктовой корзине");
            Console.WriteLine("0 - Выйти из программы");
        }


        static void Main(string[] args)
        {
            //создали по экземпляру продуктовой корзины и списка продуктов
            var myWishList = new ProductList();
            var myProductBasket = new ProductInBasket();


            //подписали метод добавления продукта в продуктову корзину при удалении наименования товара из списка
            myWishList.deleteFromList += myProductBasket.ProductAdd;

            while (true)
            {
                PrintInformation();
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (number == 0)
                    {
                        break;
                    }
                    else
                    {
                        switch (number)
                        {
                         case 1:
                                myWishList.ProductAdd(new Product());
                                continue;

                         case 2:
                                myWishList.PrintList();
                                Console.WriteLine("Нажмите клавишу Enter...");
                                Console.ReadLine();
                                continue;

                         case 3:
                                myWishList.WriteToFileAsync();
                                Console.WriteLine("Файл сохранен в следующую директорию: D:\\test.txt \nНажмите клавишу Enter для продолжения...");
                                Console.ReadLine();
                                continue;

                         case 4:
                                myWishList.ReadFiletoListAsync();
                                Console.WriteLine("Файл считан из директории: D:\\test.txt \nНажмите клавишу Enter для продолжения...");
                                continue;

                         case 5:
                                Console.Write("Введите наименование товара: ");
                                myWishList.ProductRemove(Console.ReadLine());
                                continue;

                         case 6:
                                myProductBasket.PrintList();
                                Console.WriteLine("Нажмите клавишу Enter...");
                                Console.ReadLine();
                                continue;

                        }
                    }

                    break;
                }

                else
                {
                    Console.WriteLine("Введите корректное значение");
                    continue;
                }

            }
            Console.WriteLine("Нажмите клавишу Enter...");
            Console.ReadLine();
        }
    }
}
