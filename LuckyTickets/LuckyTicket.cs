using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    class LuckyTicket
    {
        private bool checkNumberSimpleMethod(int num)
        {
            int[] arr = getArr(num);
            return ((arr[0] + arr[1] + arr[2]) == (arr[3] + arr[4] + arr[5]));
        }
        private bool checkNumberHardMethod(int num)
        {
            int[] arr = getArr(num);
            return ((arr[0] + arr[2] + arr[4]) == (arr[1] + arr[3] + arr[5]));
        }
        private int[] getArr(int num)
        {
            int[] i = new int[6];
            i[0] = (num / 100000) % 10;
            i[1] = (num / 10000) % 10;
            i[2] = (num / 1000) % 10;
            i[3] = (num / 100) % 10;
            i[4] = (num / 10) % 10;
            i[5] = num % 10;

            return i;
        }
        public int countLTSimpleMethod(int min, int max)
        {
            int countSimple = 0;
            for (int i = min; i <= max; i++)
            {
                if (checkNumberSimpleMethod(i))
                    countSimple++;
            }
            return countSimple;
        }
        public int countLTHardMethod(int min, int max)
        {
            int countSimple = 0;
            for (int i = min; i <= max; i++)
            {
                if (checkNumberHardMethod(i))
                    countSimple++;
            }
            return countSimple;
        }
        public void printResult(int simpleCount, int hardCount)
        {
            if (simpleCount < hardCount)
                Console.WriteLine("Сложный способ победил");
            else if (simpleCount > hardCount)
                Console.WriteLine("Легкий способ победил");
            else
                Console.WriteLine("Оба способа хороши");

            Console.WriteLine("Легкий способ: " + simpleCount);
            Console.WriteLine("Сложный способ: " + hardCount);
        }
    }
}
