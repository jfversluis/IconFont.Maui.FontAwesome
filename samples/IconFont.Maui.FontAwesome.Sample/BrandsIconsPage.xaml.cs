using IconFont.Maui.FontAwesome.Sample.ViewModels;

namespace IconFont.Maui.FontAwesome.Sample;

public partial class BrandsIconsPage : ContentPage
{
	public BrandsIconsPage()
	{
		InitializeComponent();
		BindingContext = new IconsViewModel("FontAwesomeBrands");
	}
}
