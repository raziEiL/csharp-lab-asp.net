
using System;

namespace mvc_calculator.Models
{
    public class HexCalculator : Calculator
    {
        public string hexA { get; set; }
        public string hexB { get; set; }
        public string hexResult { get; set; }

        public void hexOperation(string command)
        {
            try
            {
                base.a = Convert.ToInt32(hexA, 16);
                base.b = Convert.ToInt32(hexB, 16);
                base.operation(command);
                hexResult = Convert.ToInt32(base.result).ToString("X");
            }
            catch (Exception e)
            {
                hexResult = e.Message;
            }
        }
    }
}
