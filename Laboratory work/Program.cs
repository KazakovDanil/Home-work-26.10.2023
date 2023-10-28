using Laboratory_work;
using System;
using System.Collections.Generic;
using System.IO;

namespace Home_work_26._10._2023
{
    internal class Program
    {
        static public string FlipsTheWord(string word)
        {
            char[] chars_word = word.ToCharArray();
            Array.Reverse(chars_word);
            return String.Concat(chars_word);
        }
        static bool IsFormat(object something)
        {
            if (something is IFormattable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static public void SearchMail(ref string s)
        {
            string[] email = s.Split((char)'#');
            if (email.Length == 2)
            {
                s = email[1];
            }
            else
            {
                s = "0";
            }
        }

        static void Main(string[] args)
        {
            // Упражнение 8.1
            Console.WriteLine("Упражнение 8.1");
            Console.WriteLine("В этом упражнение нужно в класс счет в банке добавить возможность перевода денежных средств с другого счета");
            BankAccount bankAccount_1 = new BankAccount(12345678, 100000.24, BankAccountType.Current_account);
            BankAccount bankAccount_2 = new BankAccount(1234567890, 10000000, BankAccountType.Current_account);
            Console.WriteLine($"Счет под номером {bankAccount_1.AccountNumber} и типом {bankAccount_1.AccountType} содержит {bankAccount_1.AccountBalance} рублей");
            Console.WriteLine($"Счет под номером {bankAccount_2.AccountNumber} и типом {bankAccount_2.AccountType} содержит {bankAccount_2.AccountBalance} рублей");
            bankAccount_1.TransferFromAnotherAccount(bankAccount_2, 1000.30);
            Console.WriteLine($"Счет под номером {bankAccount_1.AccountNumber} и типом {bankAccount_1.AccountType} содержит {bankAccount_1.AccountBalance} рублей");
            Console.WriteLine($"Счет под номером {bankAccount_2.AccountNumber} и типом {bankAccount_2.AccountType} содержит {bankAccount_2.AccountBalance} рублей");
            // Упражнение 8.2
            Console.WriteLine("Упражнение 8.2");
            Console.WriteLine("В этом упражнение нужно написать метод который переворачивает строку");
            Console.Write("Введите слово и нажмите enter: ");
            string word = Console.ReadLine();
            Console.WriteLine($"Перевернутое слово: {FlipsTheWord(word)}");
            // Упражнение 8.3
            Console.WriteLine("Упражнение 8.3");
            Console.WriteLine("В этом упражнение программа получает на вход путь к файлу и проверяет есть ли он, если есть, то создает новый и добавляет туда весь " +
                "текст заглавными буквами");
            Console.Write("Введите путь к файлу и нажмите enter: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                string all_symbols = File.ReadAllText(path);
                string all_symbols_upper = "";
                for (int i = 0; i < all_symbols.Length; i++)
                {
                    all_symbols_upper += all_symbols[i].ToString();
                }
                File.AppendAllText(path, all_symbols_upper);
            }
            else
            {
                Console.WriteLine("Такого файла не существует");
            }
            // Упражнение 8.4
            Console.WriteLine("Упражнение 8.4");
            Console.WriteLine("Реализовать метод, который проверяет реализует ли входной параметр метода интерфейс System.IFormattable");
            BankAccount second_object = new BankAccount(100000, BankAccountType.Current_account);
            if (IsFormat(second_object))
            {
                Console.WriteLine("Объект реализует интерфейс System.IFormattable");
            }
            else
            {
                Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
            }
            // Домашняя работа 8.1
            Console.WriteLine("Домашняя работа 8.1");
            Console.WriteLine("Данная программа считывает в файле строки и из них получает адреса эл. почты, затем их записывает в другой файл");
            string[] lines = File.ReadAllLines("ProgramFiles/FileFithNameAndEmail.txt");
            for (int i = 0;i < lines.Length;i++)
            {
                string email = lines[i];
                SearchMail(ref email);
                if ((email != "0"))
                {
                    File.AppendAllText("ProgramFiles/EmailFile.txt", email + "\n");
                }
                else
                {
                    Console.WriteLine("В файле некоректные данные");
                }
            }

            Console.ReadKey();
        }
    }
}
