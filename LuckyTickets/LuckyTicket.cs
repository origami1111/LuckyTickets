
namespace LuckyTickets
{
    class LuckyTicket
    {
        private const uint QUANTITY_NUMBERS = 6;
        public delegate bool CheckNumberHandler(uint number);
        public CheckNumberHandler checkNumberHandler { get; set; }
        public uint Max { get; }
        public uint Min { get; }
    

        public LuckyTicket(string min, string max)
        {
            this.Min = uint.Parse(min);
            this.Max = uint.Parse(max);
        }

        public bool CheckNumberSimpleMethod(uint number)
        {
            uint[] num = GetArray(number);

            uint leftSide = num[0] + num[1] + num[2];
            uint rightSde = num[3] + num[4] + num[5];

            return Equals(leftSide, rightSde);
        }
        public bool CheckNumberHardMethod(uint number)
        {
            uint[] num = GetArray(number);
            
            uint evenSum = num[0] + num[2] + num[4];
            uint oddSum = num[1] + num[3] + num[5];

            return Equals(oddSum, evenSum);
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

        public uint QuantityByMethod()
        {
            uint quantitySimpleTickets = 0;

            for (uint i = Min; i <= Max; i++)
            {
                if (checkNumberHandler(i))
                {
                    quantitySimpleTickets++;
                }
            }

            return quantitySimpleTickets;
        }
    }
}
