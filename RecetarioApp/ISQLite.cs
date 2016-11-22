using System;
using SQLite.Net;

namespace RecetarioApp
{
	public interface ISQLite
	{
		SQLiteConnection ObtenerConexion();
	}
}
