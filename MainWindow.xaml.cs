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

namespace LR7_N3
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			Store = new Store();
			InitializeComponent();
		}

		readonly Store Store;

		private void Create_Click(object sender, RoutedEventArgs e)
		{
			int price;

			 if (NewStoreName.Text.Length == 0)
			{
				MessageBox.Show("Введiть назву магазина!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else if(NewItemName.Text.Length == 0)
			{
				MessageBox.Show("Введiть назву товара!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else if (!int.TryParse(NewPrice.Text, out price) || price <= 0)
			{
				MessageBox.Show($"Введена помилкова цiна!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else
			{
				Article article = new Article(NewItemName.Text, NewStoreName.Text, price);
				Store.AddArticle(article);
				MessageBox.Show("Ви успiшно дадали товар!", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		private void FindIndex_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (FindIndex.Text == "")
			{
				IndexOut.Text = "";
			}
			else if (!int.TryParse(FindIndex.Text, out int index) || index < 0)
			{
				IndexOut.Text = $"'{FindIndex.Text}' не є індексом!";
			}
			else if (Store[index] == null)
			{
				IndexOut.Text = $"Товар за індексом {index} не знайдено!";
			}
			else
			{
				IndexOut.Text =
					$"Назва магазину: {Store[index].StoreName}\n" +
					$"Назва товару: {Store[index].ItemName}\n" +
					$"Вартість, ₴: {Store[index].Price}\n";
			}
		}

		private void FindName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (FindName.Text == "")
			{
				NameOut.Text = "";
			}
			else if (Store[FindName.Text] == null)
			{
				NameOut.Text = "Товар за даною назвою відсутній!";
			}
			else
			{
				NameOut.Text =
					$"Назва магазину: {Store[FindName.Text].StoreName}\n" +
					$"Назва товару: {Store[FindName.Text].ItemName}\n" +
					$"Вартість, ₴: {Store[FindName.Text].Price}\n";
			}
		}
    }
}
