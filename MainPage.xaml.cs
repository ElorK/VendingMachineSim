using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VendingMachine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //starting button to initialize all the other buttons and creating manager
            btnCoffee.IsEnabled = true;
            btnTea.IsEnabled = true;
            btnCocoa.IsEnabled = true;
            btnAdd.IsEnabled = true;
            btnRestock.IsEnabled = true;
            btnStart.IsEnabled = false;
            Manager manager = new Manager();
            Manager.Restock();
            ingredientsRefresh();
            tblProccess.Text = $"Initialized successfuly";
        }

        private void btnCoffee_Click(object sender, RoutedEventArgs e)
        {
            //calling the prepare method with i as index
            int i = 0;
            tblProccess.Text = Manager.Prepare(i);
            ingredientsRefresh();

        }

        private void btnTea_Click(object sender, RoutedEventArgs e)
        {
            //calling the prepare method with i as index
            int i = 1;
            tblProccess.Text = Manager.Prepare(i);
            ingredientsRefresh();
        }
        private void btnCocoa_Click(object sender, RoutedEventArgs e)
        {
            //calling the prepare method with i as index
            int i = 2;
            tblProccess.Text = Manager.Prepare(i);
            ingredientsRefresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //validating input
            double insertMoney;
            bool validInput = double.TryParse(tbxMoney.Text.ToString(), out insertMoney);
            if (validInput && insertMoney >= 0)
            {
                //if valid, insert the input to the balance
                Manager.Balance += insertMoney;
                tblBalance.Text = Manager.Balance.ToString();
                tblProccess.Text = $"Added {insertMoney} successfuly";
            }
            else
                tblProccess.Text = "Error: Inserted money is not valid";
        }

        private void btnRestock_Click(object sender, RoutedEventArgs e)
        {
            //restocking all the ingredients
            Manager.Restock();
            ingredientsRefresh();
            tblProccess.Text = $"Restocked successfuly";
        }
        private void ingredientsRefresh()
        {
            //this function is being called everytime there is a change to the ingridients or the balance,
            //to make the displayed text show the internal value
            tblCups.Text = Manager.Cups.ToString();
            tblWater.Text = Manager.Water.ToString();
            tblMilk.Text = Manager.Milk.Amount.ToString();
            tblSugar.Text = Manager.Sugar.Amount.ToString();
            tblCoffee.Text = Manager.CoffeeBeans.Amount.ToString();
            tblCocoa.Text = Manager.CocoaBeans.Amount.ToString();
            tblTea.Text = Manager.TeaLeaves.Amount.ToString();
            tblBalance.Text = Manager.Balance.ToString();
        }
    }
}
