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
				if(PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		[NotNull]
		public string Nombre
		{
			get { return _nombre; }
			set
			{
				_nombre = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(nameof(Nombre)));
			}
		}

		public string Descripcion
		{
			get { return _descripcion; }
			set
			{
				_descripcion = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(nameof(Descripcion)));
			}
		}

		public string Ingrediente1
		{
			get { return _ingrediente1; }
			set
			{
				_ingrediente1 = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(nameof(Ingrediente1)));
			}
		}

		public string Ingrediente2
		{
			get { return _ingrediente2; }
			set
			{
				_ingrediente2 = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(nameof(Ingrediente2)));
			}
		}

		public string Ingrediente3
		{
			get { return _ingrediente3; }
			set
			{
				_ingrediente3 = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(nameof(Ingrediente3)));
			}
		}

		public string Ingrediente4
		{
			get { return _ingrediente4; }
			set
			{
				_ingrediente4 = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(nameof(Ingrediente4)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
