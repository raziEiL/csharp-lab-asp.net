
using System;
using System.Collections.Generic;

namespace mvc_calculator.Models
{
    public interface NumberSystem
    {
        void add();
        void sub();
        void div();
        void mul();
        void mod();
        void pow();
        void log();
        void array(bool odd);
    }
    public class Calculator : NumberSystem
    {
        public double a { get; set; }
        public double b { get; set; }
        public string c { get; set; }
        public double result { get; set; }
        public List<String> logList { get; set; }

        public void add()
        {
            result = a + b;
        }
        public void sub()
        {
            result = a - b;
        }
        public void div()
        {
            result = a / b;
        }
        public void mul()
        {
            result = a * b;
        }
        public void mod()
        {
            result = a % b;
        }
        public void pow()
        {
            result = Math.Pow(a, b);
        }
        public void log()
        {
            result = Math.Log(a, b);
        }
        public void operation(string command)
        {
            switch (command)
            {
                case "+":
                    add();
                    break;
                case "-":
                    sub();
                    break;
                case "*":
                    mul();
                    break;
                case "/":
                    div();
                    break;
                case "mod":
                    mod();
                    break;
                case "pow":
                    pow();
                    break;
                case "log":
                    log();
                    break;
            }
        }
        public void array(bool odd)
        {
            string[] array = c.Trim().Split(",");
            double sum = 0;
            logList = new List<String>();

            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    double num = Convert.ToDouble(array[i]);
                    bool isOdd = i % 2 != 0;
                    if (odd && isOdd || !odd && !isOdd)
                        sum += num;

                    logList.Add($"элемент - {i} ({(isOdd ? "нечетное" : "четное")}), значение - {array[i]}");
                }
                catch (Exception e)
                {
                    logList.Add($"элемент - {i}, значение - {array[i]}, Исключительная ситуация! {e.Message}");
                }
            }

            result = sum;
        }
    }
}
