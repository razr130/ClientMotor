using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClientMotor.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace ClientMotor
{
	public class JenisMotorViewModels : BindableObject
	{
		private RestClient _client = new RestClient("http://motorilusi.azurewebsites.net");

		private ObservableCollection<JenisMotor> listJenisMotor;
		public ObservableCollection<JenisMotor> ListJenisMotor
		{
			get { return listJenisMotor; }
			set { listJenisMotor = value; OnPropertyChanged("ListJenisMotor"); }
		}



		public async void RefreshDataAsync()
		{
			RestRequest _request = new RestRequest("api/jenismotor", Method.GET);
			var _response = await _client.Execute<List<JenisMotor>>(_request);
			ListJenisMotor = new ObservableCollection<JenisMotor>(_response.Data);
		}
		public JenisMotorViewModels()
		{

			RefreshDataAsync();

		}
	}
}
