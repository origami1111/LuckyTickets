using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            LuckyTicket luckyTickets = new LuckyTicket();
            int min = 0, max = 0;
            bool flag = true;

            while (flag)
            {
                try
                {
                    Console.Write("Введите min номер билета: ");
                    min = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите max номер билета: ");
                    max = Convert.ToInt32(Console.ReadLine());

                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int simpeMethod = luckyTickets.countLTSimpleMethod(min, max);
            int hardMethod = luckyTickets.countLTHardMethod(min, max);

            luckyTickets.printResult(simpeMethod, hardMethod);

            Console.WriteLine("Програма завершена");
            Console.ReadLine();
        }
    }
}
