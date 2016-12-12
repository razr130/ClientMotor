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

		private ObservableCollection<Kategori> listKategori;
		public ObservableCollection<Kategori> ListKategori
		{
			get { return listKategori; }
			set { listKategori = value; OnPropertyChanged("ListKategori"); }
		}



		public async void RefreshDataAsync(string namakategori)
		{
			var _request = new RestRequest("api/kategori/?namakategori=" + namakategori, Method.GET);


			var _response = await _client.Execute<List<Kategori>>(_request);
			ListKategori = new ObservableCollection<Kategori>(_response.Data);
		}
		public SearchKategori(string namakategori)
		{

			RefreshDataAsync(namakategori);

		}
	}
}
