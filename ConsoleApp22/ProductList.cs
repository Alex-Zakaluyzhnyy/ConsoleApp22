using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class ProductList
    {

        public delegate void ActionWithProducts(Product product);

        /// <summary>
        /// Событие, которое показывает, что товар был куплен
        /// </summary>
        public event ActionWithProducts deleteFromList;

        #region Свойства
        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get { return products.Count; } }

        /// <summary>
        /// Лист, предназначенный для хранения продуктов
        /// </summary>
        List<Product> products = new List<Product>();

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path = @"D:\test.txt";
        #endregion

        #region Индексатор
        public Product this[string Name]
        {
            get
            {
                var myProduct = products.First(fruit => fruit.Name.ToLower() == Name.ToLower());
                return myProduct;
            }  
        }
        #endregion

        #region Конструкторы
        public ProductList() { }

        public ProductList(Product product)
        {
            products.Add(product);
        }
        #endregion

        #region Методы


        /// <summary>
        /// Метод поиска необходимо продукта
        /// </summary>
        /// <param name="Name">Наименование продукта</param>
        /// <returns>Номер в списке</returns>
        private int FindProduct(string Name)
        {
            int i = 0;
            while (i < Count)
            {
                var product = products[i];
                if (product.Name.ToLower() == Name.ToLower())
                {
                    break;
                }
                else if (i == Count - 1)
                {
                    return i = -1;
                }
                i++;
            }
            return i;
        }


        /// <summary>
        /// Метод добавления элементов в список
        /// </summary>
        /// <param name="product">Продукт питания</param>
        public void ProductAdd(Product product)
        {
            Console.WriteLine($"{"\n"}\"{product}\" был добавлен в список\n");
            products.Add(product);
        }


        /// <summary>
        /// Метод удаления элемента из списка
        /// </summary>
        /// <param name="Name"> Наименование продукта</param>
        public void ProductRemove(string Name)
        {
            var index = FindProduct(Name);
            if((index >= 0) && (Count > 0))
            {
                Console.WriteLine($"{"\n"} \"{products[index]}\" был удален из списка");
                deleteFromList(products[index]);
                products.RemoveAt(index);
            }
            else if (Count == 0)
            {
                Console.WriteLine("Список пуст!");
            }

            else if (index == -1)
            {
                Console.WriteLine("Элемент не найден!");
            }

        }

        /// <summary>
        /// Вывод списка в консоль
        /// </summary>
        public void PrintList()
        {
            if(Count > 0)
            {
                foreach (var fruit in products)
                {
                    Console.WriteLine(fruit);
                }
                Console.WriteLine($"Количество наименований в списке {Count}");
            }
            
            else
            {
                Console.WriteLine("Список пуст!");
            }

        }

        /// <summary>
        /// Запись списка продуктов в файл
        /// </summary>
        /// <param name="products">Продукт питания</param>
        private void WriteListToFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i <= Count - 1; i++)
                {
                   sw.WriteLine($"{products[i].Name}\t{products[i].Number}\t{products[i].Unit}\t{products[i].Price}");
                }
            }
        }

        /// <summary>
        /// Асинхронный метод записи в файл
        /// </summary>
        /// <param name="products"></param>
        public async void WriteToFileAsync()
        {
            await Task.Run(() => WriteListToFile());
        }

        /// <summary>
        /// Чтение списка продуктов из файла
        /// </summary>
        /// <param name="products">Продукт питания</param>
        private void ReadFiletoList()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                var current = "";
                int n = 0;
                var product = new Product(6);
                while (sr.Peek() > -1)
                {
                    current = sr.ReadLine();
                    var element = current.Split('\t');
                    products.Add(new Product(6));
                    products[n].Name = element[0];
                    products[n].Number = Convert.ToDouble(element[1]);
                    products[n].Unit = element[2];
                    n++;
                }
            }
        }


        /// <summary>
        /// Асинхронный метод считывания списка продуктов из файла
        /// </summary>
        public async void ReadFiletoListAsync()
        {
            await Task.Run(() => ReadFiletoList());
        }


        #endregion
    }
}