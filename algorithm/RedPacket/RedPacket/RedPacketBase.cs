using System;
using System.Collections.Generic;
using System.Text;

namespace RedPacket
{
    public class RedPacketBase
    {
        protected decimal _MinMoney;
        protected int _PacketNum;
        protected decimal _Money;

        public bool Init(decimal Money, int PacketNum, decimal MinMoney = 0.01M)
        {
            if (Money <= 0 || PacketNum < 1 || MinMoney <= 0 || Money < MinMoney || PacketNum * MinMoney > Money) return false;
            _Money = Money;
            _PacketNum = PacketNum;
            _MinMoney = MinMoney;
            return true;
        }
    }
}
