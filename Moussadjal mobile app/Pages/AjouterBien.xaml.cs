
using Microsoft.Maui;
using System.Data;
using ZXing.Common;

namespace Moussadjal_mobile_app.Pages;

public partial class AjouterBien : ContentPage
{
	public AjouterBien()
	{
		InitializeComponent();
        LoadData();

    }
    
 
    private void LoadData()
    {

        DataTable dtDesignations = db.DtOfSelect("SELECT DISTINCT designation FROM Description_de_Bien");
        foreach (DataRow row in dtDesignations.Rows)
        {
            string des = row["designation"].ToString();
            if (!string.IsNullOrWhiteSpace(des))
                designations.Add(des);
        }


        DataTable dtDivs = db.DtOfSelect("SELECT  division FROM Division");
        foreach (DataRow row in dtDivs.Rows)
        {
            string div = row["division"].ToString();
            if (!string.IsNullOrWhiteSpace(div))
                divisions.Add(div);
        }

        divPicker.ItemsSource = divisions;


        DataTable dtLieux = db.DtOfSelect("SELECT designationLieu FROM Lieu");
        foreach (DataRow row in dtLieux.Rows)
        {
            string loc = row["designationLieu"].ToString();
            if (!string.IsNullOrWhiteSpace(loc))
                lieux.Add(loc);
        }

        AtelierPicker.ItemsSource = lieux;
    }
    private void PhotoButton_Clicked(object sender, EventArgs e)
	{
        
    }
        c_central db = new c_central();
    string d,Ns, Ann, L, nom ,ni;
    List<string> designations = new List<string>();
    List<string> divisions = new List<string>();
    List<string> lieux = new List<string>();
    private async void SaveClicked(object sender, EventArgs e)
    {
        try
        {

            if (existCB.IsChecked == false)
            {

                ni= db.FillscdToSelectCount("select count(*)+1 from Bien").ToString();
                nom = Nsb.Text.ToString();
                if (db.FillscdToSelectCount("select count(*) from Description_de_bien where designation = '" + nom + "'") >= 1)
                {
                    Ns = db.FillscdToSelectCount("select count(*)+1 from Description_de_bien").ToString();
                    d = db.SELECT("select division from Description_de_bien  where designation = '" + nom + "'");
                }
                else
                {
                    existCB.IsChecked= true;
                    Ns = Nsentry.Text.ToString();
                    d = divPicker.SelectedItem.ToString();
                }
                Ann = DateTime.Now.Year.ToString();
                L = db.SELECT("select Id_lieu from Lieu  where designationLieu = '" + AtelierPicker.SelectedItem.ToString() + "'");

            }
            else
            {

                ni = Ni.Text;
                nom = Nsb.Text.ToString();
                if (db.FillscdToSelectCount("select count(*) from Description_de_bien where designation = '" + nom + "'") >= 1)
                {
                    Ns = db.FillscdToSelectCount("select count(*)+1 from Description_de_bien").ToString();
                    d = db.SELECT("select division from Description_de_bien  where designation = '" + nom + "'");
                }
                else
                {
                    Ns = Nsentry.Text.ToString();
                    d = divPicker.SelectedItem.ToString();
                }
                Ann = AnnPicker.Date.Year.ToString();
                L = db.SELECT("select Id_lieu from Lieu  where designationLieu = '" + AtelierPicker.SelectedItem.ToString() + "'");

            }
            string Nu = $"Division: {d}\nArticle N°: {Ns}/{nom}\nN° Inventaire: {ni + 1}\n Année d'entrée: {Ann}\n Lieu d'utilisation: \n {L}.";

             NuL.Text = d + "/" + Ns + "/" + ni + "/" + db.SELECT("select '" + Ann + "'% 100 ") + "/" + L;

            //insert 'bien' to db
            db.FillscdToInsert("INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu ,Annee) VALUES (" + Convert.ToInt32(ni) + ", " + Convert.ToInt32(Ns) + ", '" + L + "','" + Ann + "')");

            bgv.Value = Nu;
            BarcodeImage.Source = bgv.Value;
            db.FillscdToInsert("UPDATE Description_de_bien SET quantite = quantite + 1 WHERE numero_sequentiel = '" + Convert.ToInt32(Ns) + "' ");

            await DisplayAlert("add secsses", (ni).ToString(), "ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("errore", ex.Message, "ok");
        }
    }
    private void CancelClicked(object sender, EventArgs e)
    {

    }

    private void existCB_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
      
        if (existCB.IsChecked) {  existCB.Color = Color.FromHex("#00B4D8"); Nsentry.IsEnabled = true;  Ni.IsEnabled = true; AnnPicker.IsEnabled = true; }
        else { Nsentry.IsEnabled = false; Ni.IsEnabled = false; AnnPicker.IsEnabled = false; }
    }

    private void Nsb_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue?.ToLower() ?? "";

        var filtered = designations
            .Where(d => d.ToLower().Contains(searchText))
            .ToList();

        if (filtered.Any())
        {
            DesignationPicker.ItemsSource = filtered;
            DesignationPicker.IsVisible = true;
            if (DesignationPicker.SelectedItem != null)   Nsb.Text = DesignationPicker.SelectedItem.ToString();
            
        }
        else
        {
            DesignationPicker.IsVisible = false;
        }
    }
}