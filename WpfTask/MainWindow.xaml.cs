using System.Windows;
using System.Windows.Input;
using log4net;

namespace WpfTask
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ActionTabViewModel actionTabViewModel;
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public MainWindow()
		{
			InitializeComponent();

			log.Info("Application Initialize");

			// Initialize viewModel
			actionTabViewModel = new ActionTabViewModel();
			// Bind the xaml TabControl to view model tabs
			MainTab.ItemsSource = actionTabViewModel.Tabs;
		}

		private void CloseTab_Btn_Click(object sender, MouseButtonEventArgs e)
		{
			// This event will be thrown when on a close image clicked
			actionTabViewModel.Tabs.RemoveAt(MainTab.SelectedIndex);
			log.Info("Tab Closed");
		}

		private void dataTable_Btn_Click(object sender, RoutedEventArgs e)
		{
			// Open Data Table tab and load JOSN
			// Populate the view model tabs
			actionTabViewModel.AddDataTableTab();
			MainTab.Items.Refresh();
			log.Info("data table tab added");
		}

		private void Email_Btn_Click(object sender, RoutedEventArgs e)
		{
			// Open an Email tab
			// Populate the view model tabs
			actionTabViewModel.AddEmailTab();
			MainTab.Items.Refresh();
			log.Info("Email tab added");
		}

		
	}
}
