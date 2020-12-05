using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Configuration;
using System;

namespace WpfTask
{
	/// <summary>
	/// Interaction logic for DataTableView.xaml
	/// </summary>
	public partial class DataTableView : System.Windows.Controls.UserControl
	{
		public DataTableView()
		{
			InitializeComponent();
			OpenFile();
		}

		public void OpenFile()
		{
			try
			{
				using (OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.InitialDirectory = ConfigurationManager.AppSettings["InitialDirectory"];
					openFileDialog.Filter = "json files (*.json)|*.json";
					openFileDialog.RestoreDirectory = true;

					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						var fileStream = openFileDialog.OpenFile();

						using (StreamReader reader = new StreamReader(fileStream))
						{
							LoadJSON(reader.ReadToEnd());
						}
					}
				}
			}
			catch (Exception ex) {
				MessageBox.Show($"Fail to load file\n{ex}");
			}

		}

		public void LoadJSON(string content) {
			if (string.IsNullOrEmpty(content)) {
				throw new Exception("File content cannot be empty");
			}

			JsonLoad.ItemsSource = JsonConvert.DeserializeObject<List<Movie>>(content);
		}
	}
}
