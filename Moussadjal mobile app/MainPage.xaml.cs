using System.Data;
using ZXing.Net.Maui.Controls;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
            connection.ConnectionString = @"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjalsql;User ID=abdomm_Moussadjalsql;Password=9876543210987";
            connection.Open(); 
            SqlCommand cmd = new SqlCommand("INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu, datamatrix_code) VALUES (@numero_dinventaire, @numero_sequentiel, @id_lieu, @datamatrix_code)");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@numero_dinventaire", int.Parse(InventoryEntry.Text));
            cmd.Parameters.AddWithValue("@numero_sequentiel",  int.Parse(SequentialEntry.Text));
            cmd.Parameters.AddWithValue("@id_lieu", PlaceEntry.Text);
            cmd.Parameters.AddWithValue("@datamatrix_code", bgv.Value);
            cmd.ExecuteNonQuery();
            connection.Close();
            DisplayAlert("add secsses", SequentialEntry.Text, "ok");

            bgv.Value = $"Numero sequential: {SequentialEntry.Text}\nNumero d'inventaire: {InventoryEntry.Text}\nLieu: {PlaceEntry.Text}";
            BarcodeImage.Source = bgv.Value;
        }

        private void GoToScann_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ScannPage());
        }
    }

}
