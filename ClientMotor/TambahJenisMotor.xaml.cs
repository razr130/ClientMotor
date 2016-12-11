using System;
using System.Collections.Generic;
using RestSharp.Portable;
using Xamarin.Forms;
using ClientMotor.Models;
using ClientMotor.ViewModel;
using RestSharp.Portable.HttpClient;

namespace ClientMotor
{
	public partial class TambahJenisMotor : ContentPage
	{
		async void BtnTambahKategori_Clicked(object sender, EventArgs e)
		{
			var _request = new RestRequest("api/JenisMotor", Method.POST);
			var newJenisMotor = new JenisMotor 
			{
				NamaMerk = txtNamaMerek.Text,
				NamaJenisMotor = txtNamaJenisMotor.Text
			};
			
			_request.AddBody(newJenisMotor);
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

		public TambahJenisMotor()
		{
			InitializeComponent();
			btnTambahKategori.Clicked += BtnTambahKategori_Clicked;
		}
	}
}
