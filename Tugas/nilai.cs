using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas
{
    internal class Nilai
    {
        public string module_name;
        public double module_test;
        public double assigment;
        public double result;
        public double credit_value;
        public string grade;
        public double grade_Val;

        public double Calculate()
        {

            double num1 = module_test * 0.6;
            double num2 = assigment * 0.4;
            result = num1 + num2;
            return result;
        }
    }
}