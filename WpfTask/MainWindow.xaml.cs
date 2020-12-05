using System.Windows;
using System.Windows.Input;

namespace WpfTask
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ActionTabViewModel actionTabViewModel;

		public MainWindow()
		{
			InitializeComponent();

			// Initialize viewModel
			actionTabViewModel = new ActionTabViewModel();
			// Bind the xaml TabControl to view model tabs
			MainTab.ItemsSource = actionTabViewModel.Tabs;
		}

		private void CloseTab_Btn_Click(object sender, MouseButtonEventArgs e)
		{
			// This event will be thrown when on a close image clicked
			actionTabViewModel.Tabs.RemoveAt(MainTab.SelectedIndex);
		}

		private void dataTable_Btn_Click(object sender, RoutedEventArgs e)
		{
			// Open Data Table tab and load JOSN
			// Populate the view model tabs
			actionTabViewModel.AddDataTableTab();
			MainTab.Items.Refresh();
		}

		private void Email_Btn_Click(object sender, RoutedEventArgs e)
		{
			// Open an Email tab
			// Populate the view model tabs
			actionTabViewModel.AddEmailTab();
			MainTab.Items.Refresh(); 
		}

		
	}
}
