using Xamarin.Forms;

namespace RecetarioApp
{
	public partial class RecetarioAppPage : ContentPage
	{
		private AdministradorAccesoRecetas _adminRecetas;

		public RecetarioAppPage()
		{
			InitializeComponent();

			_adminRecetas = new AdministradorAccesoRecetas();

			tbiAgregar.Clicked += TbiAgregar_Clicked;
			lstRecetas.ItemSelected += LstRecetas_ItemSelected;
		}

		void TbiAgregar_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new RecetaPage());
		}

		void LstRecetas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			Receta receta = e.SelectedItem as Receta;
			if (receta != null)
				Navigation.PushAsync(new RecetaPage(receta,false));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			lstRecetas.ItemsSource = _adminRecetas.ObtenerRecetas();
		}

		void MenuItemModificar_OnClicked(object sender, System.EventArgs e)
		{
			var menuItem = (MenuItem)sender;
			Receta receta = (Receta)menuItem.CommandParameter;
			if (receta != null)
				Navigation.PushAsync(new RecetaPage(receta));
		}

		void MenuItemEliminar_OnClicked(object sender, System.EventArgs e)
		{
			var menuItem = (MenuItem)sender;
			Receta receta = (Receta)menuItem.CommandParameter;
			_adminRecetas.EliminarReceta(receta);
			lstRecetas.ItemsSource = _adminRecetas.ObtenerRecetas();
		}
	}
}
