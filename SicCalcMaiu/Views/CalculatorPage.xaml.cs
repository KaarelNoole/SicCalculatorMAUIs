using Microsoft.Maui.Controls;

namespace SicCalcMaiu.Views;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();

        //init the view model
        this.BindingContext = new CalculatorPageViewModel();
    }
}