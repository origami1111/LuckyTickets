using System;
using System.Text.RegularExpressions;

namespace LuckyTickets
{
    class View
    {
        private LuckyTicket luckyTicket;
        private void PrintTask()
        {
            Console.WriteLine("===========================================================================================");
            Console.WriteLine("Есть 2 способа подсчёта счастливых билетов:" +
                              "\n1.Простой — если на билете напечатано шестизначное число, и сумма первых трёх цифр равна сумме последних трёх, то этот билет считается счастливым." +
                              "\n2.Сложный — если сумма чётных цифр билета равна сумме нечётных цифр билета, то билет считается счастливым." +
                              "\nОпределить программно какой вариант подсчёта счастливых билетов даст их большее количество на заданном интервале.");
            Console.WriteLine("===========================================================================================");
        }
        private void PrintHelp()
        {
            Console.WriteLine("===========================================================================================");
            Console.WriteLine("Возможные аргументы: " +
                              "\n-help - информация о возможных аргументах" +
                              "\n-task - информация о задачу");
            Console.WriteLine("===========================================================================================");
        }
        public void CheckArguments(string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelp();
            }
            else
            {
                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "-help":
                            PrintHelp();
                            break;
                        case "-task":
                            PrintTask();
                            break;
                        default:
                            Console.WriteLine("Указанного аргумента не существует. Чтобы посмотреть список аргументов, укажите '-help'");
                            break;
                    }
                }
            }
        }

        public void PrintResult()
        {
            uint quantitySimpleMethod = luckyTicket.QuantitySimpleMethod();
            uint quantityHardMethod = luckyTicket.QuantityHardMethod();

            Console.WriteLine("===========================================================================================");
            Console.WriteLine("Информация о победившем методе и количестве счастливых билетов для каждого способа подсчета");
            Console.WriteLine("===========================================================================================");
            if (quantitySimpleMethod > quantityHardMethod)
            {
                Console.WriteLine("Легкий способ победил");
            }
            else if (quantitySimpleMethod < quantityHardMethod)
            {
                Console.WriteLine("Сложный способ победил");
            }
            else
            {
                Console.WriteLine("Оба способа хороши");
            }

            Console.WriteLine($"Легкий способ  : {quantitySimpleMethod}");
            Console.WriteLine($"Сложный способ : {quantityHardMethod}");
            Console.WriteLine("===========================================================================================");
        }
        public void SetInterval()
        {
            bool flag = true;
            string min = "";
            string max = "";

            while (flag)
            {
                try
                {
                    Console.Write("Введите min номер билета: ");
                    min = Console.ReadLine();
                    if (min.Length != 6)
                    {
                        throw new Exception("Номер билета должен состоять из 6 цифр!");
                    }
                    else if (!Regex.IsMatch(min, "^[0-9]+$"))
                    {
                        throw new Exception("Номер билета не может содержать в себе буквы!");
                    }

                    Console.Write("Введите max номер билета: ");
                    max = Console.ReadLine();
                    if (max.Length != 6)
                    {
                        throw new Exception("Номер билета должен состоять из 6 цифр!");
                    }
                    else if (!Regex.IsMatch(max, "^[0-9]+$"))
                    {
                        throw new Exception("Номер билета не может содержать в себе буквы!");
                    }

                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            luckyTicket = new LuckyTicket(min, max);
        }
    }
}
