using System.ComponentModel;
using SQLite.Net.Attributes;

namespace RecetarioApp
{
	public class Receta : INotifyPropertyChanged
	{
		private int _id;
		private string _nombre;
		private string _descripcion;
		private string _ingrediente1;
		private string _ingrediente2;
		private string _ingrediente3;
		private string _ingrediente4;

		[AutoIncrement, PrimaryKey]
		public int ID
		{
			get { return _id; }
			set
			{
				_id = value;
				PropertyChangedHandler(ID);
			}
		}

		[NotNull]
		public string Nombre
		{
			get { return _nombre; }
			set
			{
				_nombre = value;
				PropertyChangedHandler(Nombre);
			}
		}

		public string Descripcion
		{
			get { return _descripcion; }
			set
			{
				_descripcion = value;
				PropertyChangedHandler(Descripcion);
			}
		}

		public string Ingrediente1
		{
			get { return _ingrediente1; }
			set
			{
				_ingrediente1 = value;
				PropertyChangedHandler(Ingrediente1);
			}
		}

		public string Ingrediente2
		{
			get { return _ingrediente2; }
			set
			{
				_ingrediente2 = value;
				PropertyChangedHandler(Ingrediente2);
			}
		}

		public string Ingrediente3
		{
			get { return _ingrediente3; }
			set
			{
				_ingrediente3 = value;
				PropertyChangedHandler(Ingrediente3);
			}
		}

		public string Ingrediente4
		{
			get { return _ingrediente4; }
			set
			{
				_ingrediente4 = value;
				PropertyChangedHandler(Ingrediente4);
			}
		}

		private void PropertyChangedHandler<T>(T name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(name)));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
