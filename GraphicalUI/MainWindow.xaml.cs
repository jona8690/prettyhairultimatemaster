using System;
using System.Windows;
using PrettyHairLibrary;

namespace GraphicalUI {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IObserver {
		ProductManagerController ControllerPM = new ProductManagerController();
		public MainWindow() {
			InitializeComponent();
			ControllerPM.Init();

			UpdateList();

			ControllerPM.SubscribeToProductList(this);
		}
		private void button_SaveClick(object sender, RoutedEventArgs e) {

		}
		private void button_DeleteClick(object sender, RoutedEventArgs e) {

		}

		private void button_searchClick(object sender, RoutedEventArgs e) {

		}

		private void UpdateList() {
			listBox_items.Items.Clear();
			foreach (string Item in ControllerPM.GetProducts()) {
				listBox_items.Items.Add(Item);
			}
		}

		private void button_New_Click(object sender, RoutedEventArgs e) {
			AddProduct AP = new AddProduct();
			AP.ShowDialog();
		}

		public void Change() {
			UpdateList();
		}
	}
}
