using System.Data;
using ZXing.Net.Maui.Controls;
using System.Data.SqlClient;
namespace Moussadjal_mobile_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
     
        private void GenerateButton_Clicked(object sender, EventArgs e)
        {  
            
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=sql.bsite.net\MSSQL2016;Persist Security Info=True;User ID=abdomm_Moussadjal;Password=9876543210;Encrypt=True;Trust Server Certificate=True";
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Biens (division, numéro_séquentiel ,numéro_dinventaire, lanné, lieu) VALUES (@division, @numéro_séquentiel ,@numéro_dinventaire, @lanné, @lieu)");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@division", DivisionEntry.Text);
            cmd.Parameters.AddWithValue("@numéro_séquentiel", SequentialEntry.Text);
            cmd.Parameters.AddWithValue("@numéro_dinventaire", InventoryEntry.Text);
            cmd.Parameters.AddWithValue("@lanné", YearEntry.Text);
            cmd.Parameters.AddWithValue("@lieu", PlaceEntry.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            DisplayAlert("add secsses", SequentialEntry.Text, "ok");

            bgv.Value = $"Division: {DivisionEntry.Text}\nNumero sequential: {SequentialEntry.Text}\nNumero d'inventaire: {InventoryEntry.Text}\nAnne: {YearEntry.Text}\nLieu: {PlaceEntry.Text}";
            BarcodeImage.Source = bgv.Value;
        }

        private void GoToScann_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ScannPage());
        }
    }

}
