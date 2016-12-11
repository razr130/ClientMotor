using System;
using System.Collections.Generic;
using ClientMotor.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace ClientMotor
{
	public partial class TambahKategori : ContentPage
	{
		private async void BtnTambahKategori_Clicked(object sender, EventArgs e)
		{
			var _request = new RestRequest("api/Kategori", Method.POST);
			var newKategori = new Kategori { NamaKategori = txtNamaKategori.Text };
			_request.AddBody(newKategori);
			try
			{
				var _response = await _client.Execute(_request);
				if (_response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					await Navigation.PushAsync(new KategoriPage());
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", "Error : " + ex.Message, "OK");
			}
		}

		private RestClient _client =
			new RestClient("http://motorilusi.azurewebsites.net/");

		public TambahKategori()
		{
			InitializeComponent();
			btnTambahKategori.Clicked += BtnTambahKategori_Clicked;
		}
	}
}
