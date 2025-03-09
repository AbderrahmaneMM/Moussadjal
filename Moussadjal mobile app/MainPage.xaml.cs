using System.Data;
using ZXing.Net;
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
        //byte[] convertImageToByte(Image img)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        img.Save(ms, ImageFormat.Png);
        //        return ms.ToArray();
        //    }

        //}
        byte[] convertImageToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //img.
                //img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }

        }
        private void GenerateButton_Clicked(object sender, EventArgs e)
        {
            c_central db = new c_central();

            bgv.Value = $"Numero sequential: {SequentialEntry.Text}\nNumero d'inventaire: {InventoryEntry.Text}\nLieu: {PlaceEntry.Text}";
            BarcodeImage.Source = bgv.Value;

            byte[] img; //= convertImageToByte(BarcodeImage);
           // db.FillscdToInsert("INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu, datamatrix_code) VALUES ('"+ int.Parse(InventoryEntry.Text) + "', '"+ int.Parse(SequentialEntry.Text) + "', '"+ PlaceEntry.Text + "', '"+img+"')");
           /*SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjalsql;User ID=abdomm_Moussadjalsql;Password=9876543210987";
            connection.Open(); 
            SqlCommand cmd = new SqlCommand("INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu, datamatrix_code) VALUES (@numero_dinventaire, @numero_sequentiel, @id_lieu, @datamatrix_code)");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@numero_dinventaire", );
            cmd.Parameters.AddWithValue("@numero_sequentiel",  );
            cmd.Parameters.AddWithValue("@id_lieu", );
            cmd.Parameters.AddWithValue("@datamatrix_code", bgv.Value);
            cmd.ExecuteNonQuery();
            connection.Close();*/
            DisplayAlert("add secsses", InventoryEntry.Text + SequentialEntry.Text, "ok");

        }

        private void GoToScann_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ScannPage());
        }
    }

}
