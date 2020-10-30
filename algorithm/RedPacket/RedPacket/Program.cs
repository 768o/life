using System;

namespace RedPacket
{
    class Program
    {
        static void Main(string[] args)
        {
            RedPacket packetPlus = new RedPacket();
            packetPlus.Init(1,10);
            packetPlus.BuildRedPacket();
            var list = packetPlus.GetLuckyValues();
            foreach (var i in list)
            {
                Console.WriteLine(i.Money.ToString("0.00"));
            }
            Console.ReadKey();
        }
    }
}
