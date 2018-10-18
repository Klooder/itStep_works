using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialize
{
	[Serializable]
	class Product
	{
		private String name;
		private double price;
		private int weight;

		public Product(String name, double price, int weight)
		{
			this.name = name;
			this.price = price;
			this.weight = weight;
		}

		public override string ToString()
		{
			return String.Format("{0}, {1} грн., {2} г.", this.name, this.price, this.weight);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Product P = new Product("Snickers", 12.5, 45);

			FileStream FS = new FileStream("products.dat", FileMode.Create, FileAccess.Write);
			BinaryFormatter BF = new BinaryFormatter();
			BF.Serialize(FS, P);
			FS.Close();

			FS = new FileStream("products.dat", FileMode.Open, FileAccess.Read);
			Product TMP = (Product)BF.Deserialize(FS);
			FS.Close();

			Console.WriteLine(TMP);
		}
	}
}
