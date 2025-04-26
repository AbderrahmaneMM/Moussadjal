namespace Moussadjal_mobile_app.Pages;

public partial class Detaildelieu : ContentPage
{
    public class ItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }
        public string ImageUrl { get; set; }
    }
    public Detaildelieu()
	{
		InitializeComponent();
	}
    private void ItemSelected(object sender, EventArgs e)
    {
       
    }
    private void EditLocationClicked(object sender, EventArgs e)
    {

    }
    private void BackClicked(object sender, EventArgs e)
    { 
    
    }
}