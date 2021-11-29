using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace ConsoleApp16._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Введите общее количество товаров: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine();

            Goods[] Product = new Goods[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Наименование товара: ");
                string name = Console.ReadLine();
                Console.Write("Код товара: ");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.Write("Цена товара: ");
                double price = double.Parse(Console.ReadLine());
                Product[i] = new Goods(name, code, price);
            }

            //Console.WriteLine("\n");
            //Console.WriteLine("Информация о продуктах");
            //Console.WriteLine();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("Наименование товара: {0}", Product[i].Name);
            //    Console.WriteLine("Код (номер) товара: {0}", Product[i].Code);
            //    Console.WriteLine("Стоимость товара: {0} рублей", Product[i].Price);
            //    Console.WriteLine();
            //}

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString1 = JsonSerializer.Serialize(Product, options);
            Console.WriteLine(jsonString1);

            string path = @"C:/Task16/Products.json";
            if (!File.Exists(path))
            {
               File.Create(path);
            }

            File.WriteAllText(path, jsonString1);

            Console.ReadKey();
        }

    }

    public class Goods
    {
        //[JsonPropertyName("Наименование товара")]
        public string Name { get; set; }
        //[JsonPropertyName("Код (номер) товара")]
        public int Code { get; set; }
        //[JsonPropertyName("Стоимость товара")]
        public double Price { get; set; }

        public Goods(string Name, int Code, double Price)
        {
            this.Name = Name;
            this.Code = Code;
            this.Price = Price;
            
        }
               
    }
}
