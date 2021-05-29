using System;

namespace LuckyTickets
{
    class LuckyTicket
    {
        public uint Max { get; set; }
        public uint Min { get; set; }

        public LuckyTicket(uint max, uint min)
        {
            this.Max = max;
            this.Min = min;
        }

        private bool CheckNumberSimpleMethod(uint num)
        {
            uint[] arr = GetArray(num);

            return ((arr[0] + arr[1] + arr[2]) == (arr[3] + arr[4] + arr[5]));
        }
        private bool CheckNumberHardMethod(uint num)
        {
            uint[] arr = GetArray(num);

            return ((arr[0] + arr[2] + arr[4]) == (arr[1] + arr[3] + arr[5]));
        }
        private uint[] GetArray(uint num)
        {
            uint[] i = new uint[6];

            i[0] = (num / 100000) % 10;
            i[1] = (num / 10000) % 10;
            i[2] = (num / 1000) % 10;
            i[3] = (num / 100) % 10;
            i[4] = (num / 10) % 10;
            i[5] = num % 10;

            return i;
        }
        public uint CountLTSimpleMethod()
        {
            uint countSimple = 0;

            for (uint i = Min; i <= Max; i++)
            {
                if (CheckNumberSimpleMethod(i))
                {
                    countSimple++;
                }
            }

            return countSimple;
        }
        public uint CountLTHardMethod()
        {
            uint countSimple = 0;
            for (uint i = Min; i <= Max; i++)
            {
                if (CheckNumberHardMethod(i))
                {
                    countSimple++;
                }
            }

            return countSimple;
        }
        public void PrintResult(uint simpleCount, uint hardCount)
        {
            if (simpleCount < hardCount)
            {
                Console.WriteLine("Сложный способ победил");
            }
            else if (simpleCount > hardCount)
            {
                Console.WriteLine("Легкий способ победил");
            }
            else
            {
                Console.WriteLine("Оба способа хороши");
            }
                
            Console.WriteLine($"Легкий способ: {simpleCount}");
            Console.WriteLine($"Сложный способ: {hardCount}");
        }
    }
}
