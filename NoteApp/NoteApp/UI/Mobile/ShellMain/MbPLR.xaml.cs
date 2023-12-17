using NoteApp.Models;
using NoteApp.Service;
using NoteApp.ViewModels;

namespace NoteApp.UI.Mobile.ShellMain;

public partial class MbPLR : ContentPage
{
    public string rs = "";
    private readonly IMLModel _mlervice = new VMMLModel();
    public MbPLR()
	{
		InitializeComponent();
	}

    private async void btn(object sender, EventArgs e)
    {
        var str = txtText.Text;
        ModelInput data = new ModelInput()
        {
            Language = "",
            Content = str
        };
        rs = await _mlervice.predict(data);
        if (rs != "")
        {
            lblrs.Text = rs;
        }

    }
}