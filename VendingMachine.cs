using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine
    {
        //this class holds an array of beverages and has the method that creates the corresponding beverage's string
        private Beverage[] _beverages;
        int _index;
        public VendingMachine(Beverage[] beverages)
        {
            _beverages = beverages;
            _index = 0;
        }
        public string DrinkSelect(int i)
        {
            //this method gets an i from the manager class, and after checking for insufficient ingredients exception,
            //return the corresponding string that created by beverage class polymorphism
            if (Manager.Balance < _beverages[i].Price)
                throw new Manager.InsufficientingredientsException("insufficient Money");
            if (Manager.Cups <= 0)
                throw new Manager.InsufficientingredientsException("Insufficient Cups");
            if (Manager.Water < _beverages[i].HotWater())
                throw new Manager.InsufficientingredientsException("Insufficient Water");
            if (_beverages[i].EnoughIng() == false)
                throw new Manager.InsufficientingredientsException("Insufficient Ingridients");
            Manager.Water -= _beverages[i].HotWater();
            Manager.Cups -= 1;
            Manager.Balance -= _beverages[i].Price;
            return _beverages[i].Prepare();
        }
        public void AddBev(Beverage beverage)
        {
            //for future feature, add new beverage to the array if there is any place
            if ((_index + 1) > _beverages.Length)
                throw new ArgumentOutOfRangeException();
            else
                _beverages[_index++] = beverage;
        }
        public void RemoveBev()
        {
            if ((_index - 1) < 0)
                throw new ArgumentOutOfRangeException();
            else
                _beverages[_index--] = null;
        }
    }
}
