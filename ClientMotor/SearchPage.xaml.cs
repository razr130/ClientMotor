using System;
using System.Collections.Generic;
using ClientMotor.ViewModel;
using Xamarin.Forms;

namespace ClientMotor
{
	public partial class SearchPage : ContentPage
	{
		public SearchPage()
		{
			InitializeComponent();

		}
		protected override void OnAppearing()
		{
			this.BindingContext = new KategoriViewModels();
		}
	}
}
