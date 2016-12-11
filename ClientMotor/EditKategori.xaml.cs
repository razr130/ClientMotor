using System;
using System.Collections.Generic;
using ClientMotor.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace ClientMotor
{
	public partial class EditKategori : ContentPage
	{
		private async void BtnDelete_Clicked(object sender, EventArgs e)
		{
			var _request = new RestRequest("api/Kategori/{id}", Method.DELETE);

			_request.AddParameter("id", txtIdKategori.Text);
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

		private async void BtnEdit_Clicked(object sender, EventArgs e)
		{
			var _request = new RestRequest("api/Kategori", Method.PUT);
			var newKategori = new Kategori
			{
				KategoriId = Convert.ToInt32(txtIdKategori.Text),
				NamaKategori = txtNamaKategori.Text
			};

			_request.AddBody(newKategori);
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

		public EditKategori()
		{
			InitializeComponent();
			btnEdit.Clicked += BtnEdit_Clicked;
			btnDelete.Clicked += BtnDelete_Clicked;
		}

		private RestClient _client =
		   new RestClient("http://motorilusi.azurewebsites.net/");
	}
}
