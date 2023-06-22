using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Cocoa : Beverage
    {
        //string array of ingredients [I tried to use the Ingredients class instances but had problem with returning values so I used string array instead]
        private string[] _ingredients = new string[] { "Cocoa Beans", "Milk", "Sugar"};
        public Cocoa(string name, double price) : base(name, price)
        {
        }
        public override string AddIng()
        {
            //overriding the parent abstract method to create a string of the ingredients
            string ingredients = "";
            for (int i = 0; i < _ingredients.Length; i++)
                ingredients = ingredients + $" {_ingredients[i]}, ";
            return ingredients;
        }
        public override int HotWater()
        {
            //return the indevidual value of water amount
            return 80;
        }
        public override int Stirring()
        {
            //return the indevidual value stirring amount
            return 4;
        }
        public override bool EnoughIng()
        {
            //validation check of the ingredients amount, for making sure the exception will occure by the valdiation time in the vending machine class "Drink_Select" method
            if (Manager.CocoaBeans.Amount <= 0 || Manager.Milk.Amount <= 0 || Manager.Sugar.Amount <= 0)
                return false;
            Manager.CocoaBeans.Amount--;
            Manager.Milk.Amount--;
            Manager.Sugar.Amount--;
            return true;
        }
    }
}
