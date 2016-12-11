using System;
using Xamarin.Forms;
using ClientMotor.ViewModel;
using System.Collections.Generic;

namespace ClientMotor
{
	public class MasterPageCS : ContentPage
	{
		public ListView ListView { get { return listView; } }

		ListView listView;

		public MasterPageCS()
		{
			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Kategori",
				TargetType = typeof(KategoriViewModels)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Jenis Motor",
				TargetType = typeof(JenisMotorViewModels)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Barang",
				TargetType = typeof(BarangViewModels)
			});

			listView = new ListView
			{
				ItemsSource = masterPageItems,
				ItemTemplate = new DataTemplate(() =>
				{
					var imageCell = new ImageCell();
					imageCell.SetBinding(TextCell.TextProperty, "Title");
					return imageCell;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.None
			};

			Padding = new Thickness(0, 40, 0, 0);

			Title = "Menu";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					listView
				}
			};
		}
		
	}
}
