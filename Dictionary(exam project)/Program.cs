using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_exam_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создаем файловый поток,и записываем в него инфу из словаря

            /*Dictionary dict = new Dictionary();
            dict.Create();
            FileStream fs = new FileStream(dict.type + ".txt", FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            dict.Add(dict.dictionary, fs, sw);
            dict.Add(dict.dictionary, fs, sw);
            sw.Close();

            dict.Delete(dict.dictionary, dict.type + ".txt");
            dict.Edit(dict.dictionary, dict.type + ".txt");
            dict.Print();*/


            Dictionary dict = new Dictionary(); //Создаем экземпляр класса dictionary

            Console.WriteLine("Hello,im your personal dictionary.");
            bool exit = false;
            while (exit != true) //while до тех пор пока пользователь не выберет exit
            {
                Console.Write("Choose what you need:   1.Create  2.Delete  3.Edit  4.Print  5.Search  6.Exit  Write: ");
                try
                {
                    string a = Console.ReadLine();
                    int choose = Convert.ToInt32(a);
                    switch (choose) // реализуем свитч с 6 опциями 
                    {
                        case 1:
                            dict.Create();
                            Console.WriteLine();
                            break;

                        case 2:
                            dict.Delete(dict.dictionary, dict.type + ".txt");
                            Console.WriteLine();
                            break;

                        case 3:
                            dict.Edit(dict.dictionary, dict.type + ".txt");
                            Console.WriteLine();
                            break;

                        case 4:
                            dict.Print();
                            Console.WriteLine();
                            break;

                        case 5:
                            dict.Search(dict.dictionary);
                            Console.WriteLine();
                            break;

                        case 6:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine($"\nMisstake!!\n{ex.Message}\n"); } // если возникает исключение выводим ошибку
            }



        }
    }
}
