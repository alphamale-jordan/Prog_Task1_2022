using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class CollectionExpenses: Expense
    {
        private double monthIncome = 0.0;
        private double deductTax;
        private double grocery;
        private double lightWater;
        private double travelCost;
        private double phoneCost;
        private double otherCostAmount;

        public CollectionExpenses(double income, double taxDed, double gro, double light, double travel, double pho, double other)
        {
            this.monthIncome = income;
            this.deductTax = taxDed;
            this.grocery = gro;
            this.lightWater = light;
            this.travelCost = travel;
            this.phoneCost = pho;
            this.otherCostAmount = other;

        }

        public double getGrossIncome()
        {
            return Convert.ToDouble(this.monthIncome);
        }

        public double getDeduction()
        {
            return Convert.ToDouble(this.deductTax);
        }
        public double getGroceries()
        {
            return Convert.ToDouble(this.grocery);
        }

        public double getWaterAndlight()
        {
            return Convert.ToDouble(this.lightWater);
        }

        public double getTravelCost()
        {
            return Convert.ToDouble(this.travelCost);
        }
        public double getCellPhone()
        {
            return Convert.ToDouble(this.phoneCost);
        }
        public double getOther()
        {
            return Convert.ToDouble(this.otherCostAmount);
        }
        public override double Month_Cal()
        {
            return deductTax + grocery + lightWater + travelCost + phoneCost + otherCostAmount;
        }
    }
}
