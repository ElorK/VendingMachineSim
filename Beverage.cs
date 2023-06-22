using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Beverage
    {
        //abstract parent class for the other kinds of the beverages
        //hold the mutual properties such as name and price, and inherit the polymorphed methods that create the final string
        private string _name;
        private double _price;

        public Beverage(string name, double price)
        {
            _name = name;
            _price = price;
        }
        public double Price { get { return _price; } }
        public abstract string AddIng();
        public abstract int HotWater();
        public abstract int Stirring();
        public string Prepare()
        {
            //the string that get returned to the vending machine class. created by polymorphed methods by the children classes
            return $"Adding {AddIng()}\n================\nAdding {HotWater()}ml of hot water\n================\nStirring {Stirring()} times\n================\n{_name} is ready!";
        }
        public abstract bool EnoughIng();
    }
}
