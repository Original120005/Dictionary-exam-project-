using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_exam_project
{
    interface CreateDictionary //Содержит 1 метод который создает новый словарь
    {
        void Create();
    }
    interface EditDictionary //Содержит 3 метода предназначеные для Удаления,Редактирования и Поиска слов в словаре
    {
        void Delete(Dictionary<string, string> dic, string file);
        void Edit(Dictionary<string, string> dic, string file);
        void Search(Dictionary<string, string> dic);
    }
    interface PrintDictionary  //Содержит 1 метод который выводит на экран содержимое словаря 
    {
        void Print();
    }

    class Dictionary : CreateDictionary, EditDictionary, PrintDictionary //Определяем класс Dictionary который содержит все 3 интерфейса
    {
        public Dictionary<string, string> dictionary;
        public string type;

        public Dictionary() { } //Конструктор без параметров создает экземпляр класса
        public Dictionary(Dictionary<string, string> word) //Констуктор принимает словарь в качестве параметра и инициализирует поле dictionary
        {
            dictionary = word;
        }

        public void Create()  //Метод создает новый словарь запрашивая у пользователя тип словаря
        {
            dictionary = new Dictionary<string, string>();
            Console.Write("Enter type of dictionary: ");
            type = Console.ReadLine();
            FileStream file = new FileStream(type + ".txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            file.Close();
        }

        public void Delete(Dictionary<string, string> dic, string file)  //Метод позволяет удалить слово из словаря запрашивая слова которое надо удалить,после слово удаляется
        {
            Console.Write("Enter word to delete: ");
            string word = Console.ReadLine();
            var lines = File.ReadAllLines(file).ToList();
            int index = lines.IndexOf(word + " -- " + dic[word]);

            if (dic.ContainsKey(word))
            {
                dic.Remove(word);
                lines.RemoveAt(index);
                File.WriteAllLines(file, lines);
            }
        }

        public void Edit(Dictionary<string, string> dic, string file)  //Метод позволяет редактировать слово,запрашивая слово кторое надо изменить
        {
            Console.Write("Enter word you want to edit: ");
            string find = Console.ReadLine();
            if (dic.ContainsKey(find))
            {
                var lines = File.ReadAllLines(file).ToList();
                int index = lines.IndexOf(find + " -- " + dic[find]);

                Console.Write("Enter new word: ");
                string word = Console.ReadLine();
                Console.Write("Enter new translate: ");
                string translate = Console.ReadLine();
                dic.Remove(find);
                lines.RemoveAt(index);

                string save = null;
                foreach (var i in dic)
                {
                    save += $"{i.Key} - {i.Value}\n";
                }
                File.WriteAllLines($"{file}", lines);
                dic.Add(word, translate);
                string text = null;
                foreach (var i in dic)
                {
                    text += $"{i.Key} - {i.Value}\n";
                }
                File.WriteAllText(file, text);
            }
            else { Console.WriteLine("U wrong,i cant find this word!"); }
        }

        public void Search(Dictionary<string, string> dic)  //Метод позволяет найти слово ,запрашивая у пользователя слово которое нужно найти
        {
            if (dic != null)
            {
                Console.Write("Enter word you want to search: ");
                string word = Console.ReadLine();
                if (dic.ContainsKey(word))
                {
                    Console.WriteLine($"{word} - {dic[word]}");
                }
                else
                {
                    foreach (var key in dic.Keys)
                    {
                        if (dic[key] == word)
                        {
                            Console.WriteLine($"{key} - {dic[key]}");
                        }
                    }
                }
            }
        }

        public void Print()  //Финальный метод выводит содержимое словаря в консоль используя StreamReader для чтения из файла
        {
            Console.WriteLine($"  Type: {type}");
            StreamReader sr = new StreamReader(type + ".txt", Encoding.UTF8);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }

    }
}