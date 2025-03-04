using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace SnapphaneScoutDistriktBookingApp;

public partial class Canoe : ContentPage
{
	
	public Canoe()
	{
		InitializeComponent();
		BindingContext = new BookingViewModel();

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
	public partial class BookingViewModel : ObservableObject
	{
		[ObservableProperty]
		private DateTime startDate = DateTime.Today;

        [ObservableProperty]
        private DateTime endDate = DateTime.Today.AddDays(1);

		public ICommand SelectStartDateCommand => new AsyncRelayCommand(async () => await SelectStartDate());
        public ICommand SelectEndDateCommand => new AsyncRelayCommand(async () => await SelectEndDate());
		private async Task SelectStartDate()
		{
            DateTime? result = await ShowDatePicker(StartDate);
            if (result.HasValue)
            {
                StartDate = result.Value;
            }
        }
        private async Task SelectEndDate()
        {
			DateTime? result = await ShowDatePicker(EndDate);
			if(result.HasValue)
			{
				EndDate = result.Value;
			}
        }
		private async Task<DateTime?> ShowDatePicker(DateTime initalDate)
		{
			var datePicker = new DatePicker { Date = initalDate };

			var popup = new ContentPage
			{
				Content = new VerticalStackLayout
				{
					Padding = 20,
					Children =
					{
						new Label { Text = "V�lj ett datum", FontSize = 20},
						datePicker,
						new Button
						{
							Text = "OK",
							Command = new Command(() => Application.Current.MainPage.Navigation.PopModalAsync()) 
							
						}
					}
				}
			};
			await Application.Current.MainPage.Navigation.PushModalAsync(popup);
			await Task.Delay(100);
			
			return datePicker.Date;

        }
    }
    private void OnConformation(object sender, EventArgs e)
    {
		var customerCollection = new Collection<Models.Customer>();
		var custumer = new Models.Customer()
		{
			Name = myName.Text,
			Phone = myPhone.Text,
			Email = myEmail.Text,
			IsOrg = myCheckBox.IsChecked,
			OrgName = (myCheckBox.IsChecked == true ? hiddenLabel.Text : ""),
			StartDate = MyStartDate.Date,
			EndDate = MyEndDate.Date,
			BookingType = Models.Customer.TypeOfBooking.Canoe
		};
		customerCollection.Add(custumer);
		
    }

    private void OnCheckCanoe(object sender, CheckedChangedEventArgs e)
    {
		if (e.Value)
		{
			AntalKanoter.IsVisible = true;
		}
		else
		{
			AntalKanoter.IsVisible = false;
        }
    }

    private void OnCheckCabin(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            AntalStuga.IsVisible = true;
        }
        else
        {
            AntalStuga.IsVisible = false;
        }
    }
}