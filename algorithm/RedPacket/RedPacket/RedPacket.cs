using System;
using System.Collections.Generic;
using System.Text;

namespace RedPacket
{
    class RedPacket : RedPacketBase
    {
        private List<LuckyValue> _LuckyValues = new List<LuckyValue>();
        private List<LuckyValue> _LuckyValues2 = new List<LuckyValue>();

        public void BuildRedPacket()
        {
            var temp = 0;
            for (var i = 0; i < _PacketNum; i++) {
                var LuckyValue = GetLuckyValue();
                for (var j = 0; j < LuckyValue; j++)
                {
                    temp++;
                    _LuckyValues2.Add(new LuckyValue
                    {
                        Order = i + 1,
                        Value = temp
                    });
                }
                _LuckyValues.Add(new LuckyValue {
                    Order = i + 1,
                    Value = LuckyValue,
                    Money = _MinMoney
                });
            }
            _Money = _Money - _MinMoney * _PacketNum;
            var Num = _Money / _MinMoney;
            for (var i = 0; i < Num; i++) {
                var y = new Random().Next(1, temp + 1);
                var order = _LuckyValues2.Find(d => d.Value == y).Order;
                var l = _LuckyValues.Find(d => d.Order == order);
                l.Money += _MinMoney;
            }
        }

        private int GetLuckyValue(int LuckyValue = 0, int num = 1)
        {
            if (new Random().Next(0, 2) == 0)
            {
                LuckyValue++;
                return GetLuckyValue(LuckyValue, num);
            }
            else {
                if (num == 6)
                {
                    return LuckyValue; 
                }
                else
                {
                    return GetLuckyValue(LuckyValue, ++num);
                }
            }
        }

        public List<LuckyValue> GetLuckyValues()
        {
            return _LuckyValues;
        }
    }

    class LuckyValue
    {
        public int Order { get; set; }
        public int Value { get; set; }
        public decimal Money { get; set; }
    }
}
