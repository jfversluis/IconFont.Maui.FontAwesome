using IconFont.Maui.FontAwesome.Sample.ViewModels;

namespace IconFont.Maui.FontAwesome.Sample;

public partial class RegularIconsPage : ContentPage
{
	public RegularIconsPage()
	{
		InitializeComponent();
		BindingContext = new IconsViewModel("FontAwesomeRegular");
	}
}
