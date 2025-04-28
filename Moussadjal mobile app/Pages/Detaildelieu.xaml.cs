using Microsoft.Maui.Devices.Sensors;
using System.Collections.ObjectModel;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Moussadjal_mobile_app.Pages;
public class ItemModel
{
    public string Id { get; set; }        // numero_dinventaire
    public string Name { get; set; }      // designation_du_bien
    public string SequenceNumber { get; set; }  // numero_sequentiel
    public string Category { get; set; }  // Id_lieu
    public string StatusColor { get; set; }
    public string ImageUrl { get; set; }
}
public partial class Detaildelieu : ContentPage
{// Database connection through central class
    private c_central _central = new c_central();

    // Store the location ID and name
    private string _locationId;
    private string _locationName;

    // Collection to hold items in this location
    private ObservableCollection<ItemModel> _items = new ObservableCollection<ItemModel>();

    // Constructor with parameters for location ID and name
    public Detaildelieu(string locationId, string locationName)
    {
		InitializeComponent();
        // Store the location information
        _locationId = locationId;
        _locationName = locationName;

        // Set location description in the UI
        LocationDescriptionLabel.Text = "Local situé à " + _locationName;

        // Load data when page appears
        LoadLocationDetails();
    }

    // This method loads the location details and items
    private void LoadLocationDetails()
    {
        try
        {
            // Clear any existing items
            _items.Clear();

            // Set initial counter to 0
            int totalItems = 0;

            // Open database connection
            _central.scn.Open();

            // Create SQL query to get items (biens) in this location
            string query = $"SELECT * FROM Bien WHERE Id_lieu = '{_locationId}'";
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
                string inventoryNumber = row["numero_dinventaire"].ToString();
                string sequenceNumber = row["numero_sequentiel"].ToString();

                // Try to get the item name from the database
                // If your table has a column for the item name, use that instead
                string itemName = "";
                if (dataTable.Columns.Contains("designation_du_bien"))
                {
                    itemName = row["designation_du_bien"].ToString();
                }
                else
                {
                    itemName = "Item " + sequenceNumber; // Fallback if no name column exists
                }

                // Increment total items counter
                totalItems++;

                // Create a new item object
                ItemModel item = new ItemModel
                {
                    Id = inventoryNumber,
                    Name = itemName,
                    SequenceNumber = sequenceNumber,
                    Category = sequenceNumber, // Showing sequence number as category as in screenshot
                    StatusColor = "#4CAF50",
                    ImageUrl = "item_placeholder.png" // Default placeholder image
                };

                // Add the item to our collection
                _items.Add(item);
            }

            // Update the UI with count
            TotalItemsLabel.Text = totalItems.ToString();

            // Set the collection as the source for our list
            ItemsCollection.ItemsSource = _items;
        }
        catch (Exception ex)
        {
            // Show error message if something goes wrong
            DisplayAlert("Erreur",
                "Impossible de charger les détails du local: " + ex.Message,
                "OK");
        }
    }

    // This method is called when an item is selected
    private void ItemSelected(object sender, SelectionChangedEventArgs e)
    {
        // Check if anything was selected
        if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
            return;

        // Get the selected item
        var selectedItem = e.CurrentSelection[0] as ItemModel;
        if (selectedItem == null)
            return;

        // Clear selection (visual feedback)
        ((CollectionView)sender).SelectedItem = null;

        // You can add code here to handle the item selection
        // For example, navigate to item details page or show details in a popup
    }

  
    private void ItemSelected(object sender, EventArgs e)
    {
       
    }
    private void EditLocationClicked(object sender, EventArgs e)
    {
        
    }
    private  async void BackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}