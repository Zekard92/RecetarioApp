﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecetarioApp
{
	public partial class RecetaPage : ContentPage
	{
		private AdministradorAccesoRecetas _adminRecetas;
		private Receta _receta;
		private bool _edit;

		public RecetaPage(Receta receta = null, bool Edit = true)
		{
			InitializeComponent();

			_edit = Edit;

			_adminRecetas = new AdministradorAccesoRecetas();
			tbiGuardar.Clicked += TbiGuardar_Clicked;

			if (receta != null)
			{
				_receta = receta;
				txtNombre.Text = _receta.Nombre;
				txtDescripcion.Text = _receta.Descripcion;
				txtIngrediente1.Text = _receta.Ingrediente1;
				txtIngrediente2.Text = _receta.Ingrediente2;
				txtIngrediente3.Text = _receta.Ingrediente3;
				txtIngrediente4.Text = _receta.Ingrediente4;
			}
			txtNombre.IsEnabled = Edit;
			txtDescripcion.IsEnabled = Edit;
			txtIngrediente1.IsEnabled = Edit;
			txtIngrediente2.IsEnabled = Edit;
			txtIngrediente3.IsEnabled = Edit;
			txtIngrediente4.IsEnabled = Edit;
		}

		void TbiGuardar_Clicked(object sender, EventArgs e)
		{
			if (_edit)
			{
				Receta receta;
				if (_receta == null)
				{
					receta = new Receta();
					receta = AsignarValores(receta);
					if (!string.IsNullOrEmpty(txtNombre.Text))
						_adminRecetas.AgregarReceta(receta);
					else
					{
						DisplayAlert("Aviso", "El campo de nombre se encuentra vacío", "Enterado");
						return;
					}
				}
				else
				{
					receta = _receta;
					receta = AsignarValores(receta);
					if (!string.IsNullOrEmpty(txtNombre.Text))
						_adminRecetas.ModificarReceta(receta);
					else
					{
						DisplayAlert("Aviso", "El campo de nombre se encuentra vacío", "Enterado");
						return;
					}
				}
			}

			Navigation.PopAsync();
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
