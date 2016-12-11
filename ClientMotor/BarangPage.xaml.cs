using System;
using System.Collections.Generic;
using ClientMotor.Models;
using Xamarin.Forms;

namespace ClientMotor
{
	public partial class BarangPage : ContentPage
	{
		void Lstbarang_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			Barang item = (Barang)e.Item;
			EditBarang editPage = new EditBarang();
			editPage.BindingContext = item;
			Navigation.PushAsync(editPage);
		}

		void Btntambah_Clicked(object sender, EventArgs e)
		{
			TambahBarang tambah = new TambahBarang();
			Navigation.PushAsync(tambah);
		}

		public BarangPage()
		{
			InitializeComponent();
			btntambah.Clicked += Btntambah_Clicked;
			lstbarang.ItemTapped += Lstbarang_ItemTapped;
		}

		protected override void OnAppearing()
		{
			this.BindingContext = new BarangViewModels();
		}
	}
}
