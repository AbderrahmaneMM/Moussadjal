using System.Collections.ObjectModel;
using System.Data; 

using Microsoft.Data.SqlClient;
namespace Moussadjal_mobile_app.Pages;
public class LieuModel
{
    public string Id { get; set; }         
    public string Name { get; set; }      
    public string Description { get; set; } 
    public int ItemCount { get; set; }     
}
public partial class Locaux : ContentPage
{  
     c_central db = new c_central();
    
 
     ObservableCollection<LieuModel> locations = new ObservableCollection<LieuModel>();

	public Locaux()
	{
		InitializeComponent();
         
        LoadLocationsFromDatabase();
    }
    private async void LoadLocationsFromDatabase()
    {
        try
        { 

            locations.Clear();

            foreach (DataRow row in db.DtOfSelect("SELECT Id_lieu, designationLieu FROM Lieu").Rows)
            { 
                string id = row["Id_lieu"].ToString();
                string name = row["designationLieu"].ToString();

                LieuModel location = new LieuModel
                {
                    Id = id,
                    Name = name,
                    Description = "Local " + name,   
                    ItemCount = db.FillscdToSelectCount("SELECT COUNT(*) FROM Bien WHERE Id_lieu ='"+id+"'")   
                };
                 
                locations.Add(location);
            }
             
            LocationsCollection.ItemsSource = locations;
        }
        catch (Exception ex)
        { 
            await DisplayAlert("Erreur",
                "Impossible de charger les locaux: " + ex.Message,
                "OK");
        }
    }
    private async void LocationSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
            return;

        var selectedLocation = e.CurrentSelection[0] as LieuModel;
        if (selectedLocation == null)
            return;

        // Important: Clear selection AFTER capturing the selected item
        CollectionView collectionView = (CollectionView)sender;

        // Navigate to detail page
        await Navigation.PushAsync(new Detaildelieu(selectedLocation.Id, selectedLocation.Name));

        // Clear selection AFTER navigation completes - this fixes the issue
        // Use Device.BeginInvokeOnMainThread to ensure UI updates properly
        Device.BeginInvokeOnMainThread(() => {
            collectionView.SelectedItem = null;
        });
    }
    private async void SearchTextChanged( object sender, TextChangedEventArgs e)
    {

        string searchText = LocationSearchBar.Text?.ToLower() ?? "";


        if (string.IsNullOrWhiteSpace(searchText))
        {
            LocationsCollection.ItemsSource = locations;
            return;
        }


        var filteredLocations = locations.Where(location =>
            location.Name.ToLower().Contains(searchText) ||
            location.Description.ToLower().Contains(searchText)).ToList();


        LocationsCollection.ItemsSource = filteredLocations;
    }
}