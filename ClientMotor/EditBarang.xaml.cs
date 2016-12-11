
using System;
using System.Collections.Generic;
using ClientMotor.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace ClientMotor
{
	public partial class EditBarang : ContentPage
	{
		async void BtnDelete_Clicked(object sender, EventArgs e)
		{
			var _request = new RestRequest("api/Barang/{id}", Method.DELETE);

			_request.AddParameter("id", txtkode.Text);
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

		async void BtnEdit_Clicked(object sender, EventArgs e)
		{
			var _request = new RestRequest("api/Barang", Method.PUT);
			var newBarang = new Barang
			{
				KodeBarang = txtkode.Text,
				Nama = txtnama.Text,
				IdJenisMotor = Convert.ToInt32(txtidjenis.Text),
				KategoriId = Convert.ToInt32(txtidkategori.Text),
				Stok = Convert.ToInt32(txtstok.Text),
				HargaBeli = Convert.ToInt32(txthargabeli.Text),
				HargaJual = Convert.ToInt32(txthargajual.Text),
				TanggalBeli = datetanggal.Date
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

		public EditBarang()
		{
			InitializeComponent();
			btnEdit.Clicked += BtnEdit_Clicked;
			btnDelete.Clicked += BtnDelete_Clicked;
		}

		private RestClient _client =
		   new RestClient("http://motorilusi.azurewebsites.net/");
	}
}
