using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClientMotor.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace ClientMotor.ViewModel
{
	public class BarangSearch : BindableObject
	{
		private RestClient _client = new RestClient("http://motorilusi.azurewebsites.net/");

		private ObservableCollection<Barang> listBarang;
		public ObservableCollection<Barang> ListBarang
		{
			get { return listBarang; }
			set { listBarang = value; OnPropertyChanged("ListBarang"); }
		}



		public async void RefreshDataAsync(string namabarang, string sesi)
		{
			RestRequest _request = new RestRequest("api/barang/?namabarang=" + namabarang + "&sesi=" + sesi, Method.GET);

			var _response = await _client.Execute<List<Barang>>(_request);
			ListBarang = new ObservableCollection<Barang>(_response.Data);
		}
		public BarangSearch(string namabarang, string sesi)
		{

			RefreshDataAsync(namabarang, sesi);

		}
	}
}
