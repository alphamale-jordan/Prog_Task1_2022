using System;
using System.Collections.Generic;
using System.Text;

namespace Prog_Task1_2022.Custom
{
   public  class Houseloan: Expense
    {
        private double propertyAmount;
        private double totalDepositAmount;
        private double interest;
        private int nMoths;
        double Accumulator = 0.0;

        public Houseloan()
        { 

        }
        public Houseloan(double amount, double total, double i, int n)
        {
            this.propertyAmount = amount;
            this.totalDepositAmount = total;
            this.interest = i;
            this.nMoths = n;

        }

        public double getPrice()
        {
            return Convert.ToDouble(this.propertyAmount);
        }
        public double getDeposit()
        {
            return Convert.ToDouble(this.totalDepositAmount);
        }
        public double getRate()
        {
            return Convert.ToDouble(this.interest);
        }
        public int getMonth()
        {
            return Convert.ToInt32(this.nMoths);
        }
        public override double Month_Cal()
        {
            Accumulator = (propertyAmount - totalDepositAmount) * (1 + (interest / 100.0) * (nMoths / 12.0));

            return (Accumulator / nMoths);
        }
    }
}
