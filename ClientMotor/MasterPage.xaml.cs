using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ClientMotor
{
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		public MasterPage()
		{
			InitializeComponent();

			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Kategori",
				TargetType = typeof(KategoriPage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Jenis Motor",
				TargetType = typeof(JenisMotorPage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Barang",
				TargetType = typeof(BarangPage)
			});

			listView.ItemsSource = masterPageItems;
		}
	}
}
