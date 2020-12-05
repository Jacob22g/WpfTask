using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTask
{
	/// <summary>
	/// Interaction logic for DataTableView.xaml
	/// </summary>
	public partial class DataTableView : UserControl
	{
		public DataTableView()
		{
			InitializeComponent();
			LoadJson();
		}

		public void LoadJson()
		{
			using (StreamReader r = new StreamReader(@"films.json"))
			{
				string json = r.ReadToEnd();
				dynamic array = JsonConvert.DeserializeObject(json);

				List<Movie> movies = new List<Movie>();

				foreach (var item in array)
				{
					//Console.WriteLine("{0} ", item);
					string itemStr = JsonConvert.SerializeObject(item);
					movies.Add(JsonConvert.DeserializeObject<Movie>(itemStr));
				}

				JsonLoad.ItemsSource = movies;
			}
		}
	}
}
