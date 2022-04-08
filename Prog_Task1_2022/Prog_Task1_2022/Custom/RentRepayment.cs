using System;
using System.Collections.Generic;
using System.Text;

namespace Prog_Task1_2022.Custom
{
    public class RentRepayment: Expense
    {
        private double rentalCost;

        public RentRepayment()
        { 
        }
        public RentRepayment(double amount)
        {
            this.rentalCost = amount;

        }
        public double getRent()
        {
            return Convert.ToDouble(this.rentalCost);
        }

        public override double Month_Cal()
        {
            return rentalCost;
        }
    }
}
