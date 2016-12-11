using System;
using System.Collections.Generic;
using ClientMotor.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace ClientMotor
{
	public partial class TambahBarang : ContentPage
	{
		async void BtnTambahKategori_Clicked(object sender, EventArgs e)
		{
			var _request = new RestRequest("api/barang", Method.POST);
			var newBarang = new Barang
			{
				KodeBarang = txtkode.Text,
				Nama = txtNama.Text,
				IdJenisMotor = Convert.ToInt32(txtidjenismotor.Text),
				KategoriId = Convert.ToInt32(txtidkategori.Text),
				Stok = Convert.ToInt32(txtstok.Text),
				HargaBeli = Convert.ToInt32(txthargabeli.Text),
				HargaJual = Convert.ToInt32(txthargajual.Text),
				TanggalBeli = DateTime.Today
			};
			_request.AddBody(newBarang);
			try
			{
				var _response = await _client.Execute(_request);
				if (_response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					await Navigation.PopAsync();
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", "Error : " + ex.Message, "OK");
			}

		}
		private RestClient _client =
			new RestClient("http://motorilusi.azurewebsites.net/");

		public TambahBarang()
		{
			InitializeComponent();
			btnTambahKategori.Clicked += BtnTambahKategori_Clicked;
		}


	}
}
