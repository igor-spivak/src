using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Updraft.Logic;

namespace Updraft
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private const int Million = 1000000;

		public MainWindow()
		{
			InitializeComponent();

			btnTrigger.Click += (sender, args) =>
			{
				btnTrigger.IsEnabled = false;
				Task.Run(() => Go());
			};
		}

		private void SomeAction()
		{
			for (int i = 1; i < 5; i++)
			{
				int result = 0;
			}
		}

		//Task<int> GetPrimesCountAsync(int start, int count)
		//{
		//    return Task.Run(() => GetPrimesCount(start, count));
		//}


		private void Go()
		{
			for (int i = 1; i < 5; i++)
			{
				int result = GetPrimesCount(i * Million, Million);
				Dispatcher.BeginInvoke(
					new Action(() =>
						tbResults.Text +=
							result + " primes between " + (i * Million) + " and " + ((i + 1) * Million - 1) + Environment.NewLine)
					);
			}
			Dispatcher.BeginInvoke(
				new Action(() =>
					btnTrigger.IsEnabled = true));
		}

		private int GetPrimesCount(int start, int count)
		{
			return ParallelEnumerable.Range(start, count).Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
		}

		public void TestGetData()
		{
			new CostManager().GetData();
		}
		
		
	}
}
