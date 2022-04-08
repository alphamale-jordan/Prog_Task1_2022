using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Prog_Task1_2022
{
    class Program
    {
        public static void Main(string[] args)
        {

            while (true)

            {
                try
                {
                    double[] grossIncome ={new double()};
                    double[] taxDeducted = { new double() };
                    double[] groceries = { new double() };
                    double[] waterAndLights = { new double() };
                    double[] travelCosts = { new double() };
                    double[] cellPhone = { new double() };
                    double[] otherexpen = { new double() };


                    double[] monthlyRental= { new double()};

                    double[] propertyPrice = { new double() };
                    double[] totalDeposit = { new double() };
                    double[] interestRate = { new double() };
                    int[] monthrepay = { new int() };

                    Custom.RentRepayment getAccess= new Custom.RentRepayment();
                    Custom.CollectionExpenses getpay= new Custom.CollectionExpenses();
                    Custom.Houseloan getHouse = new Custom.Houseloan();
                    int index = 0;

 

                    int type = 0;
                    while (true)
                    {
                        Console.WriteLine("Gross monthly income (before deductions)");
                        double.TryParse(Console.ReadLine(), out grossIncome[index]);

                        Console.WriteLine("Estimated monthly tax deducted");
                        double.TryParse(Console.ReadLine(), out taxDeducted[index]);

                        Console.WriteLine("Estimated monthly expenditures in each of the following categories");
                        Console.WriteLine("Groceries");
                        double.TryParse(Console.ReadLine(), out groceries[index]);


                        Console.WriteLine("Water and lights");
                        double.TryParse(Console.ReadLine(), out waterAndLights[index]);

                        Console.WriteLine("Travel costs (including petrol)");
                        double.TryParse(Console.ReadLine(), out travelCosts[index]);


                        Console.WriteLine("Cell phone and telephone");
                        double.TryParse(Console.ReadLine(), out cellPhone[index]);

                        Console.WriteLine("Other expenses");
                        double.TryParse(Console.ReadLine(), out otherexpen[index]);

                        Array.Resize(ref grossIncome, grossIncome.Length+1);
                        Array.Resize(ref taxDeducted, taxDeducted.Length + 1);
                        Array.Resize(ref groceries, groceries.Length + 1);
                        Array.Resize(ref waterAndLights, waterAndLights.Length + 1);
                        Array.Resize(ref travelCosts, travelCosts.Length + 1);
                        Array.Resize(ref cellPhone, cellPhone.Length + 1);
                        Array.Resize(ref otherexpen, otherexpen.Length + 1);
                        index++;


                        for(int i=0;i<grossIncome.Length-1;i++)
                        {
                           getpay= new Custom.CollectionExpenses(grossIncome[i], taxDeducted[i], groceries[i], waterAndLights[i], travelCosts[i], cellPhone[i], otherexpen[i]);
                        }
                        Console.WriteLine("The total for all expenses is:"+"    "+getpay.Month_Cal());
                              
                        while (true)
                        {
                            Console.WriteLine("For Renting accommodation select 1 or select 2 for buying a property");
                            Console.WriteLine("1. Renting accommodation");
                            Console.WriteLine("2. Buying a property");
                            Console.WriteLine("3. Exit");
                            type = Convert.ToInt32(Console.ReadLine());

                            if (type == 1)
                            {
                                index = 0;
                                Console.WriteLine("Monthly rental amount");
                                double.TryParse(Console.ReadLine(), out monthlyRental[index]);

                                Array.Resize(ref monthlyRental, monthlyRental.Length + 1);
                                index++;

                                for (int i = 0; i < monthlyRental.Length - 1; i++)
                                {
                                    getAccess = new Custom.RentRepayment(monthlyRental[i]);
                                }

                                if (getpay.getGrossIncome() < getAccess.getRent())
                                {
                                    Console.WriteLine("Your Pay is less Than Rent: You don't Meet Requirements");
                                    Environment.Exit(0);

                                }
                                else
                                {
                                    Console.WriteLine("\n\nSuccesfull....Your Pay is greater Than Rent, Press\n" +
                                        "(1) To View Remaining Balance\n" +
                                        "(2) Exit\n");
                                    int sele = Convert.ToInt32(Console.ReadLine());


                                    if (sele == 1)
                                    {
                                        string bala = "";
                                        double ded = getpay.getGrossIncome() - (getpay.Month_Cal() + getAccess.getRent());
                                        bala = "---------------------------------------------------\n" +
                                            "---------------------Balance Report-------------------\n" +
                                            "\n The Total For Expense =:" + getpay.Month_Cal().ToString() + "\n" +
                                            "The month rent is =:" + getAccess.getRent().ToString() + "\n" +
                                            "Monthly PayRoll Is =:" + getpay.getGrossIncome().ToString() + "\n" +
                                            "The remaining balance after deduction is =:" + ded + "\n" +
                                            "-------------------------------------------------------\n";
                                        Console.Write(bala.ToString());

                                        Console.WriteLine("");
                                        Console.WriteLine("Press Any Key To Exit");
                                        string key = Console.ReadLine();

                                        if (!key.Equals(""))
                                        {
                                            Environment.Exit(0);
                                        }
                                    }
                                    else

                                    {
                                        Environment.Exit(0);
                                    }
                                }

                            }
                            else if (type == 2)
                            {

                                while (true)
                                {
                                    index = 0;
                                    Console.WriteLine("Purchase price of property");
                                    double.TryParse(Console.ReadLine(), out propertyPrice[index]);
                                    Console.WriteLine("Total deposit");
                                    double.TryParse(Console.ReadLine(), out totalDeposit[index]);
                                    Console.WriteLine("Interest rate (percentage)");
                                    double.TryParse(Console.ReadLine(), out interestRate[index]);

                                    Array.Resize(ref propertyPrice, propertyPrice.Length + 1);
                                    Array.Resize(ref totalDeposit, totalDeposit.Length + 1);
                                    Array.Resize(ref interestRate, interestRate.Length + 1);

                                    while (true)
                                    {
                                        Console.WriteLine("Number of months to repay (between 240 and 360)");
                                        monthrepay[index] = Convert.ToInt32(Console.ReadLine());

                                        Array.Resize(ref monthrepay, monthrepay.Length + 1);

                                        for (int i = 0; i < propertyPrice.Length - 1; i++)
                                        {
                                            getHouse = new Custom.Houseloan(propertyPrice[i], totalDeposit[i], interestRate[i], monthrepay[i]);
                                        }

                                        if (getHouse.Month_Cal() > getpay.getGrossIncome())
                                        {
                                            Console.WriteLine("approval of the home loan is unlikely");
                                            Environment.Exit(0);
                                        }
                                        else
                                        {

                                            if (getHouse.getMonth() >= 240 && getHouse.getMonth() <= 360)
                                            {

                                                string bala = "";
                                                double ded = getpay.getGrossIncome() - (getpay.Month_Cal() + getHouse.Month_Cal());
                                                bala = "---------------------------------------------------\n" +
                                                    "---------------------Balance Report-------------------\n" +
                                                    "\n The Total For Expense =:" + getpay.Month_Cal().ToString() + "\n" +
                                                    "The Month Money To Pay For Home loan =:" + getHouse.Month_Cal() + "\n" +
                                                    "Monthly PayRoll Is =:" + getpay.getGrossIncome().ToString() + "\n" +
                                                    "The remaining balance after deduction is =:" + ded + "\n" +
                                                    "-------------------------------------------------------";
                                                Console.Write(bala.ToString());
                                                Console.ReadKey();


                                                Console.WriteLine("\n\n");
                                                Console.WriteLine("enter 1 exit");
                                                int val = 0;
                                                int.TryParse(Console.ReadLine(), out val);

                                                if (val == 1)
                                                {
                                                    Environment.Exit(0);
                                                }
                                            }




                                            else
                                            {
                                                Console.WriteLine("Number of months to repay must be(between 240 and 360)");
                                                Environment.Exit(0);
                                            }
                                        }


                                    }
                                }
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                        }
                    }
                }

                catch (Exception me)
                {
                    Console.WriteLine(me.Message);
                    Console.WriteLine("enter 1 or any other value to close the application");
                    int val = 0;
                    int.TryParse(Console.ReadLine(), out val);

                    if (val == 1)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}