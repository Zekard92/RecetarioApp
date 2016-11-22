using SQLite.Net;
using Xamarin.Forms;
using System;
using System.IO;
using RecetarioApp.iOS;

[assembly: Dependency(typeof(SQLiteServicio))]
namespace RecetarioApp.iOS
{
	public class SQLiteServicio : ISQLite
	{
		public SQLiteConnection ObtenerConexion()
		{
			var archivoBaseDatos = "Recetas.db3";
			string directorioBaseDatos = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string rutaLibreria = Path.Combine(directorioBaseDatos, "..", "Library");
			var rutaCompleta = Path.Combine(rutaLibreria, archivoBaseDatos);
			if (!File.Exists(rutaCompleta))
				File.Create(rutaCompleta);
			var plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var conexion = new SQLiteConnection(plataforma, rutaCompleta);
			return conexion;
		}
	}
}
