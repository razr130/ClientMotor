using System;
using System.Collections.Generic;
using ClientMotor.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace ClientMotor
{
	public partial class EditJenisMotor : ContentPage
	{
		async void BtnDelete_Clicked(object sender, EventArgs e)
		{
			var _request = new RestRequest("api/JenisMotor/{id}", Method.DELETE);

			_request.AddParameter("id", txtIdJenisMotor.Text);
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
			var _request = new RestRequest("api/JenisMotor", Method.PUT);
			var newJenisMotor = new JenisMotor
			{
				IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
				NamaMerk = txtnamamerek.Text,
				NamaJenisMotor = txtnamajenismotor.Text
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

		public EditJenisMotor()
		{
			InitializeComponent();
			btnEdit.Clicked += BtnEdit_Clicked;
			btnDelete.Clicked += BtnDelete_Clicked;
		}
		private RestClient _client =
		   new RestClient("http://motorilusi.azurewebsites.net/");
	}
}
