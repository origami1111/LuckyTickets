using System;

namespace LuckyTickets
{
    class View
    {
        private LuckyTicket luckyTicket;

        private void PrintTask()
        {
            Console.WriteLine("==============================================================================");
            Console.WriteLine("Есть 2 способа подсчёта счастливых билетов:" +
                              "\n1.Простой — если на билете напечатано шестизначное число, и сумма первых трёх цифр равна сумме последних трёх, то этот билет считается счастливым." +
                              "\n2.Сложный — если сумма чётных цифр билета равна сумме нечётных цифр билета, то билет считается счастливым." +
                              "\nОпределить программно какой вариант подсчёта счастливых билетов даст их большее количество на заданном интервале.");
            Console.WriteLine("==============================================================================");
        }
        private void PrintHelp()
        {
            Console.WriteLine("==============================================================================");
            Console.WriteLine("Возможные аргументы: " +
                              "\n-help - информация о возможных аргументах" +
                              "\n-task - информация о задачу");
            Console.WriteLine("==============================================================================");
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
            uint simpleMethod = luckyTicket.CountLTSimpleMethod();
            uint hardMethod = luckyTicket.CountLTHardMethod();

            luckyTicket.PrintResult(simpleMethod, hardMethod);
        }
        public void FillData()
        {
            uint min = 0, max = 0;
            bool flag = true;

            while (flag)
            {
                try
                {
                    Console.Write("Введите min номер билета: ");
                    if (!uint.TryParse(Console.ReadLine(), out min) || min == 0)
                    {
                        throw new Exception($"Можно вводить числа в диапазоне [1;{uint.MaxValue}]");
                    }

                    Console.Write("Введите max номер билета: ");
                    if (!uint.TryParse(Console.ReadLine(), out max) || max == 0)
                    {
                        throw new Exception($"Можно вводить числа в диапазоне [1;{uint.MaxValue}]");
                    }
                    else if (max < min)
                    {
                        throw new Exception("max номер билета не может быть меньше min номера билета!");
                    }

                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            luckyTicket = new LuckyTicket(max, min);
        }
    }
}
