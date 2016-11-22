using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecetarioApp
{
	public partial class RecetaPage : ContentPage
	{
		private AdministradorAccesoRecetas _adminRecetas;
		private Receta _receta;

		public RecetaPage(Receta receta = null)
		{
			InitializeComponent();

			_adminRecetas = new AdministradorAccesoRecetas();
			tbiGuardar.Clicked += TbiGuardar_Clicked;

			if (receta != null)
				_receta = receta;
		}

		void TbiGuardar_Clicked(object sender, EventArgs e)
		{
			Receta receta;
			if (_receta == null)
			{
				receta = new Receta();
				receta = AsignarValores(receta);
				_adminRecetas.AgregarReceta(receta);
			}
			else
			{
				receta = _receta;
				receta = AsignarValores(receta);
				_adminRecetas.ModificarReceta(receta);
			}

			Navigation.PopModalAsync();
		}
		private Receta AsignarValores(Receta receta)
		{
			receta.Nombre = txtNombre.Text;
			receta.Descripcion = txtDescripcion.Text;
			receta.Ingrediente1 = txtIngrediente1.Text;
			receta.Ingrediente2 = txtIngrediente2.Text;
			receta.Ingrediente3 = txtIngrediente3.Text;
			receta.Ingrediente4 = txtIngrediente4.Text;
			return receta;
		}
	}
}
