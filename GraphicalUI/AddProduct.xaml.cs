using System.Windows;
using PrettyHairLibrary;

namespace GraphicalUI {
	/// <summary>
	/// Interaction logic for AddProduct.xaml
	/// </summary>
	public partial class AddProduct : Window {
		ProductManagerFacade FacadePM = new ProductManagerFacade();

		public AddProduct() {
			InitializeComponent();
		}

		private void button_save_Click(object sender, RoutedEventArgs e) {
			string Description = textBox_desc.Text;
			string Price = textBox_price.Text;
			string Amount = textBox_amount.Text;

			FacadePM.SaveProduct(Description, Amount, Price);
			this.Close();
		}

		private void button_cancel_Click(object sender, RoutedEventArgs e) {
			this.Close();
		}

	}
}
