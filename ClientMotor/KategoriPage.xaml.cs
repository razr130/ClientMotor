using System;
using System.Collections.Generic;
using ClientMotor.ViewModel;
using ClientMotor.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace ClientMotor
{
	public partial class KategoriPage : ContentPage
	{
		void Btnsearch_Clicked(object sender, EventArgs e)
		{
			this.BindingContext = new SearchKategori(txtsearch.Text);

		}

		void Btntambah_Clicked(object sender, EventArgs e)
		{
			TambahKategori tambah = new TambahKategori();
			Navigation.PushAsync(tambah);
		}

		private void Lstkategori_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			Kategori item = (Kategori)e.Item;
			EditKategori editPage = new EditKategori();
			editPage.BindingContext = item;
			Navigation.PushAsync(editPage);
		}

		public KategoriPage()
		{
			InitializeComponent();

			lstkategori.ItemTapped += Lstkategori_ItemTapped;
			btntambah.Clicked += Btntambah_Clicked;
			btnsearch.Clicked += Btnsearch_Clicked;

		}

		protected override void OnAppearing()
		{
			this.BindingContext = new KategoriViewModels();
		}

	}
}
