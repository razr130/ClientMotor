using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using ClientMotor.Models;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using System.Collections.Generic;

namespace ClientMotor.ViewModel
{
	public class KategoriViewModels : BindableObject
	{
		private RestClient _client = new RestClient("http://motorilusi.azurewebsites.net");

		private ObservableCollection<Kategori> listKategori;
		public ObservableCollection<Kategori> ListKategori
		{
			get {return listKategori; } 
			set { listKategori = value; OnPropertyChanged("ListKategori");}
		}



		public async void RefreshDataAsync()
		{ 
			RestRequest _request = new RestRequest("api/kategori", Method.GET);
			var _response = await _client.Execute<List<Kategori>>(_request);
			ListKategori = new ObservableCollection<Kategori>(_response.Data);
		}
		public KategoriViewModels()
		{

			RefreshDataAsync();

		}
	}
}
