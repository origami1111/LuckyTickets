
namespace LuckyTickets
{
    class LuckyTicket
    {
        private const uint QUANTITY_NUMBERS = 6;
        public uint Max { get; }
        public uint Min { get; }

        public LuckyTicket(string min, string max)
        {
            this.Min = uint.Parse(min);
            this.Max = uint.Parse(max);
        }

        private bool CheckNumberSimpleMethod(uint number)
        {
            uint[] num = GetArray(number);

            return ((num[0] + num[1] + num[2]) == (num[3] + num[4] + num[5]));
        }
        private bool CheckNumberHardMethod(uint number)
        {
            uint[] num = GetArray(number);

            return ((num[0] + num[2] + num[4]) == (num[1] + num[3] + num[5]));
        }

        private uint[] GetArray(uint number)
        {
            uint[] num = new uint[QUANTITY_NUMBERS];

            num[0] = (number / 100000) % 10;
            num[1] = (number / 10000) % 10;
            num[2] = (number / 1000) % 10;
            num[3] = (number / 100) % 10;
            num[4] = (number / 10) % 10;
            num[5] = (number / 1) % 10;

            return num;
        }

        public uint QuantitySimpleMethod()
        {
            uint quantitySimpleTickets = 0;

            for (uint i = Min; i <= Max; i++)
            {
                if (CheckNumberSimpleMethod(i))
                {
                    quantitySimpleTickets++;
                }
            }

            return quantitySimpleTickets;
        }

        public uint QuantityHardMethod()
        {
            uint quantityHardTickets = 0;

            for (uint i = Min; i <= Max; i++)
            {
                if (CheckNumberHardMethod(i))
                {
                    quantityHardTickets++;
                }
            }

            return quantityHardTickets;
        }
    }
}
