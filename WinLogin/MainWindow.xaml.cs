using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

using Servicios;

namespace WinLogin
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void LoginIngresar(object sender, RoutedEventArgs e)
    {
      SecurityServices serv = new SecurityServices();

      Sesion ses = serv.Login(txtUsuario.Text, txtPassword.Password);

      if (ses == null)
        MessageBox.Show("Error de credenciales...");
      else
      {
        winMain wm = new winMain(ses);
        
        wm.Show();

        Close();
      }
    }

  }
}
