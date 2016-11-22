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
		}

		void TbiAgregar_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new RecetaPage());
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
			//Receta receta = lstRecetas.SelectedItem as Receta;
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
