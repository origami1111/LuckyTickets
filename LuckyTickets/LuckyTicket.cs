using System.Linq;

namespace LuckyTickets
{
    class LuckyTicket
    {
        public delegate bool CheckNumberHandler(string number);
        public CheckNumberHandler checkNumberHandler { get; set; }
        public uint Max { get; }
        public uint Min { get; }


        public LuckyTicket(string min, string max)
        {
            this.Min = uint.Parse(min);
            this.Max = uint.Parse(max);
        }

        public bool CheckNumberSimpleMethod(string number)
        {
            char[] num = GetArray(number);

            uint leftSide = (uint)(num[0] + num[1] + num[2]);
            uint rightSde = (uint)(num[3] + num[4] + num[5]);

            return Equals(leftSide, rightSde);
        }
        public bool CheckNumberHardMethod(string number)
        {
            char[] num = GetArray(number);

            uint evenSum = (uint)(num[0] + num[2] + num[4]);
            uint oddSum = (uint)(num[1] + num[3] + num[5]);

            return Equals(oddSum, evenSum);
        }

        private char[] GetArray(string number)
        {
            char[] nums = number.Select(x => (char)char.GetNumericValue(x)).ToArray();

            return nums;
        }


        public uint CountingLuckyTickets()
        {
            uint quantitySimpleTickets = 0;

            for (uint i = Min; i <= Max; i++)
            {

                if (checkNumberHandler(i.ToString("000000")))
                {
                    quantitySimpleTickets++;
                }
            }

            return quantitySimpleTickets;
        }
    }
}
