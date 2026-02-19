using IconFont.Maui.FontAwesome.Sample.ViewModels;

namespace IconFont.Maui.FontAwesome.Sample;

public partial class MainPage : ContentPage
{
public MainPage()
{
InitializeComponent();
BindingContext = new IconsViewModel("FontAwesomeSolid");
}
}
