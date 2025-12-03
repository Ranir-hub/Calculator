using Calculator;

namespace Calc;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new Calculator.Calculator();
    }
}
