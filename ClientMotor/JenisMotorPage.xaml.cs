using System;
using System.Collections.Generic;
using ClientMotor.ViewModel;
using ClientMotor.Models;
using Xamarin.Forms;

namespace ClientMotor
{
	public partial class JenisMotorPage : ContentPage
	{
		void Btntambah_Clicked(object sender, EventArgs e)
		{
			TambahJenisMotor tambah = new TambahJenisMotor();
			Navigation.PushAsync(tambah);
		}

		void Lstjenismotor_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			JenisMotor item = (JenisMotor)e.Item;
			EditJenisMotor editPage = new EditJenisMotor();
			editPage.BindingContext = item;
			Navigation.PushAsync(editPage);
		}

		public JenisMotorPage()
		{
			InitializeComponent();

			lstjenismotor.ItemTapped += Lstjenismotor_ItemTapped;
			btntambah.Clicked += Btntambah_Clicked;


		}
		protected override void OnAppearing()
		{
			this.BindingContext = new JenisMotorViewModels();
		}
	}
}
