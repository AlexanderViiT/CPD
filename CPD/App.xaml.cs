using System.Configuration;
using System.Data;
using System.Windows;
using CPD.ZLogin.AView;
using CPD.ZLogin.AViewModel;
using CPD.ZView;


namespace CPD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void InicioAplicacion(object sender, StartupEventArgs e)
        {
            var loginview = new LoginP();
            loginview.Show();
            loginview.IsVisibleChanged += (s, ev) =>
            {
                 if (loginview.IsVisible == false && loginview.IsLoaded)
                {
                    var mainView = new Dashboard();
                    mainView.Show();
                    loginview.Close();
                }
            };
        }
    }

}
