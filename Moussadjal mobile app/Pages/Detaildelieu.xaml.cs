using Microsoft.Maui.Devices.Sensors;
using System.Collections.ObjectModel;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Moussadjal_mobile_app.Pages;
public class BienModel
{

    public string Ni { get; set; } = string.Empty; 
    public string Ns { get; set; } = string.Empty; 
    public string designation { get; set; } = string.Empty; 
    public string div { get; set; } = string.Empty; 
    public int quantite { get; set; }
    public string Image { get; set; } = string.Empty; 

}
public partial class Detaildelieu : ContentPage
{ 
    private c_central db = new c_central();
     
    private string _locationId;
    private string _locationName;


    private ObservableCollection<BienModel> Bien = new ObservableCollection<BienModel>();


    public Detaildelieu(string locationId, string locationName)
    {
		InitializeComponent(); 
        _locationId = locationId;
        _locationName = locationName;
         
        LocationDescriptionLabel.Text = "Local situé à " + locationId;
        LocationNameLabel.Text = locationName;
        LoadLocationDetails();
    }
     
    private void LoadLocationDetails()
    {
        try
        {
            Bien.Clear();
             
            int totalItems = db.FillscdToSelectCount("SELECT COUNT(*) FROM Bien WHERE Id_lieu ='" + _locationId + "'");
            DataTable dt = db.DtOfSelect($"SELECT DISTINCT d.numero_sequentiel,d.division, d.designation, b.annee,  d.quantite FROM Description_de_bien d JOIN Bien b ON b.numero_sequentiel= d.numero_sequentiel Where b.Id_lieu = '{_locationId}'");
            foreach (DataRow row in dt.Rows)
            {

               // string inventoryNumber = row["numero_dinventaire"].ToString();
                string sequenceNumber = row["numero_sequentiel"].ToString();
                string  itemName = row["designation"].ToString();
                string Div = row["division"].ToString();
                int quantity = db.FillscdToSelectCount("SELECT COUNT(*) FROM Bien WHERE numero_sequentiel='" + sequenceNumber + "' AND Id_lieu = '"+_locationId+"'");
        


                BienModel item = new BienModel
                {
                    //Ni = inventoryNumber,
                    designation = itemName,
                    Ns = sequenceNumber,
                    div = Div,
                    Image = "C:\\Users\\DELL\\source\\repos\\AbderrahmaneMM\\Moussadjal\\Moussadjal mobile app\\Resources\\Images\\dotnet_bot.png",
                    quantite = quantity
                };


                Bien.Add(item);
            }


            TotalItemsLabel.Text = totalItems.ToString();


            ItemsCollection.ItemsSource = Bien;
        }
        catch (Exception ex)
        {

            DisplayAlert("Erreur",
                "Impossible de charger les détails du local: " + ex.Message,
                "OK");
        }
    }


    private async void ItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
            return;

        var selectedItem = e.CurrentSelection[0] as BienModel;
        if (selectedItem == null)
            return;


        BienModel itemToShow = selectedItem;

       
        CollectionView collectionView = (CollectionView)sender;
        Device.BeginInvokeOnMainThread(() => {
            collectionView.SelectedItem = null;
        });


        await DisplayAlert("Item Selected", $"You selected {itemToShow.designation}", "OK");
    }

  
   
    private void EditLocationClicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new ScannPage());
    }
    private  async void BackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}