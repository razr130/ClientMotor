using System;
using System.Collections.Generic;
using ClientMotor.Models;
using ClientMotor.ViewModel;
using Xamarin.Forms;

namespace ClientMotor
{
	public partial class BarangPage : ContentPage
	{
		void Btnsearch_Clicked(object sender, EventArgs e)
		{
			if (switcher.IsToggled.ToString() == "True")
			{
				this.BindingContext = new BarangSearch(txtsearch.Text,switcher.IsToggled.ToString());
			}
			if (switcher.IsToggled.ToString() == "False")
			{
				this.BindingContext = new SearchKategori(txtsearch.Text );
			}

		}

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
			btnsearch.Clicked += Btnsearch_Clicked;

		}

		protected override void OnAppearing()
		{
			this.BindingContext = new BarangViewModels();

		}
	}
}
