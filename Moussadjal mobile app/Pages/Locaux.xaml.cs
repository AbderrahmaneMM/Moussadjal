using System.Collections.ObjectModel;
using System.Data; 

using Microsoft.Data.SqlClient;
namespace Moussadjal_mobile_app.Pages;

public partial class Locaux : ContentPage
{  
     c_central _central = new c_central();
    
 
     ObservableCollection<LocationModel> _locations = new ObservableCollection<LocationModel>();

	public Locaux()
	{
		InitializeComponent();

        // When the page loads, fetch the locations from database
        LoadLocationsFromDatabase();
    }
    private async void LoadLocationsFromDatabase()
    {
        try
        {
            // Clear any existing locations
            _locations.Clear();

            // Open database connection
            _central.scn.Open();

            // Create SQL query to get locations
            string query = "SELECT Id_lieu, designationLieu FROM Lieu";
            SqlCommand command = new SqlCommand(query, _central.scn);

            // Create data adapter and table to hold results
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Close the connection after getting data
            _central.scn.Close();

            // Loop through each row in the results
            foreach (DataRow row in dataTable.Rows)
            {
                // Get values from the current row
                string id = row["Id_lieu"].ToString();
                string name = row["designationLieu"].ToString();

                // Create a new location object
                LocationModel location = new LocationModel
                {
                    Id = id,
                    Name = name,
                    Description = "Local " + name,  // Simple description
                    ItemCount = 0  // Default to 0 items (can update this later)
                };

                // Add the location to our collection
                _locations.Add(location);
            }

            // Set the collection as the source for our list
            LocationsCollection.ItemsSource = _locations;
        }
        catch (Exception ex)
        {
            // Show error message if something goes wrong
            await DisplayAlert("Erreur",
                "Impossible de charger les locaux: " + ex.Message,
                "OK");
        }
    }
    private async void LocationSelected(object sender, SelectionChangedEventArgs e)
    {
        // Check if anything was selected
        if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
            return; 
        // Get the selected location
        var selectedLocation = e.CurrentSelection[0] as LocationModel;
        if (selectedLocation == null)
            return;

        // Clear selection (visual feedback)
        ((CollectionView)sender).SelectedItem = null;

        // Navigate to the detail page and pass the location ID
        await Navigation.PushAsync(new Detaildelieu(selectedLocation.Id, selectedLocation.Name));
    }
    private void SearchTextChanged( object sender, TextChangedEventArgs e)
    {
        // Get what the user typed
        string searchText = LocationSearchBar.Text?.ToLower() ?? "";

        // If nothing is typed, show all locations
        if (string.IsNullOrWhiteSpace(searchText))
        {
            LocationsCollection.ItemsSource = _locations;
            return;
        }


        var filteredLocations = _locations.Where(location =>
            location.Name.ToLower().Contains(searchText) ||
            location.Description.ToLower().Contains(searchText)).ToList();


        LocationsCollection.ItemsSource = filteredLocations;
    }
}