using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPD.ZLogin.AControlesPersonalizados
{
    /// <summary>
    /// Lógica de interacción para ContrasenaEnlazable.xaml
    /// </summary>
    public partial class ContrasenaEnlazable : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Contrasena", typeof(SecureString), typeof(ContrasenaEnlazable));

        public SecureString Contrasena
        {
            get { return (SecureString)GetValue(PasswordProperty); } 
            set { SetValue(PasswordProperty, value);}
        }

        public ContrasenaEnlazable()
        {
            InitializeComponent();
            txtContraseña.PasswordChanged += AlCambiarContrasena;
        }

        private void AlCambiarContrasena(object sender, RoutedEventArgs e)
        {
            Contrasena = txtContraseña.SecurePassword;
        }
    }
}
