using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTask
{
	/// view model for the TabControl To bind on
	public class ActionTabViewModel
	{
		// These Are the tabs that will be bound to the TabControl 
		public ObservableCollection<ActionTabItem> Tabs { get; set; }

		public ActionTabViewModel()
		{
			Tabs = new ObservableCollection<ActionTabItem>();
		}

		public void AddDataTableTab()
		{
			Tabs.Add(new ActionTabItem { Header = "Data Table Tab", Content = new DataTableView() });
		}

		public void AddEmailTab()
		{
			Tabs.Add(new ActionTabItem { Header = "Email Tab", Content = new SendEmailView() });
		}
	}
}
