﻿using Xamarin.Forms;

namespace RecetarioApp
{
	public partial class RecetarioAppPage : ContentPage
	{
		private AdministradorAccesoRecetas _adminRecetas;

		public RecetarioAppPage()
		{
			InitializeComponent();

			tbiAgregar.Clicked += TbiAgregar_Clicked;
		}

		void TbiAgregar_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new RecetaPage());
		}

		void MenuItemModificar_OnClicked(object sender, System.EventArgs e)
		{
			Receta receta = lstRecetas.SelectedItem as Receta;
			if (receta != null)
				Navigation.PushAsync(new RecetaPage(receta));
		}

		void MenuItemEliminar_OnClicked(object sender, System.EventArgs e)
		{
			Receta receta = lstRecetas.SelectedItem as Receta;
			_adminRecetas.EliminarReceta(receta);
			lstRecetas.ItemsSource = _adminRecetas.ObtenerRecetas();
		}
	}
}