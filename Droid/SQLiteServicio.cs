using RecetarioApp.Droid;
using SQLite.Net;
using Xamarin.Forms;
using System;
using System.IO;

[assembly: Dependency(typeof(SQLiteServicio))]
namespace RecetarioApp.Droid
{
	public class SQLiteServicio : ISQLite
	{
		public SQLiteConnection ObtenerConexion()
		{
			var archivoBaseDatos = "Contactos.db3";
			string directorioBaseDatos = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string rutaCompleta = Path.Combine(directorioBaseDatos, archivoBaseDatos);
			if (!File.Exists(rutaCompleta))
			{
				File.Create(rutaCompleta);
			}
			var plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var conexion = new SQLiteConnection(plataforma, rutaCompleta);
			return conexion;
		}
	}
}
