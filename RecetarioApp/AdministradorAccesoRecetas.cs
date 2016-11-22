using System;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;

namespace RecetarioApp
{
	public class AdministradorAccesoRecetas
	{
		private SQLiteConnection _conexionReceta;

		public AdministradorAccesoRecetas()
		{
			_conexionReceta = DependencyService.Get<ISQLite>().ObtenerConexion();
			_conexionReceta.CreateTable<Receta>();
		}

		public void AgregarReceta(Receta receta)
		{
			_conexionReceta.Insert(receta);
		}

		public void EliminarReceta(Receta receta)
		{
			_conexionReceta.Delete(receta);
		}

		public void ModificarReceta(Receta receta)
		{
			_conexionReceta.Update(receta);
		}

		public ObservableCollection<Receta> ObtenerRecetas()
		{
			var listaRecetas = _conexionReceta.Table<Receta>().ToList();
			ObservableCollection<Receta> recetas = new ObservableCollection<Receta>(listaRecetas);
			return recetas;
		}

		public Receta ObtenerReceta(int id)
		{
			var listaRecetas = _conexionReceta.Table<Receta>().ToList();
			return listaRecetas.SingleOrDefault(x => x.ID == id);
		}
	}
}
