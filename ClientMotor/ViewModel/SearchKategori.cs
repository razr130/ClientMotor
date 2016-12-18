using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClientMotor.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace ClientMotor.ViewModel
{
	public class SearchKategori : BindableObject
	{
		private RestClient _client = new RestClient("http://motorilusi.azurewebsites.net/");

		private ObservableCollection<BarangVM> listBarang;
		public ObservableCollection<BarangVM> ListBarang
		{
			get { return listBarang; }
			set { listBarang = value; OnPropertyChanged("ListBarang"); }
		}



		public async void RefreshDataAsync(string namakategori)
		{
			var _request = new RestRequest("api/barang/?namakategori=" + namakategori, Method.GET);
			var _response = await _client.Execute<List<BarangVM>>(_request);
			ListBarang = new ObservableCollection<BarangVM>(_response.Data);
		}
		public SearchKategori(string namakategori)
		{

			RefreshDataAsync(namakategori);

		}
	}
}
