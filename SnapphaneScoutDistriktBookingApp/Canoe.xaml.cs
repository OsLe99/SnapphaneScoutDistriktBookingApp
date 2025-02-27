using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SnapphaneScoutDistriktBookingApp;

public partial class Canoe : ContentPage
{
	public Canoe()
	{
		InitializeComponent();
	}


    private void OnCheckChange(object sender, CheckedChangedEventArgs e)
    {
		if (e.Value)
		{
			statusLabel.Text = "Scoutmedlem";
			hiddenLabel.IsVisible = true;
			orgNameInput.IsVisible = true;
		}
		else
		{
			statusLabel.Text = "Icke scoutmedlem";
			hiddenLabel.IsVisible = false;
			orgNameInput.IsVisible = false;
		}
    }

    private void OnConformation(object sender, EventArgs e)
	{
		Models.Customer customer = new Models.Customer { 
			Name = myName.Text,
			Email = myEmail.Text,
			Phone = myPhone.Text,
			IsOrg = myCheckBox.IsChecked,
			OrgName = (myCheckBox.IsChecked == true) ? hiddenLabel.Text : "",
			BookingType = Models.Customer.TypeOfBooking.Canoe,
			StartDate = new DateOnly()
		};

	}
}