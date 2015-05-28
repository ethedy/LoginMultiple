using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

using Servicios;

namespace WinLogin
{
  /// <summary>
  /// Interaction logic for winMain.xaml
  /// </summary>
  public partial class winMain : Window
  {
    private Sesion _ses;

    public winMain(Sesion ses)
    {
      InitializeComponent();

      _ses = ses;
      _ses.WatchDog += ProcesarWD;

      txtMensaje.Content = _ses.FullName;
    }

    private void Logout(object sender, RoutedEventArgs e)
    {
      _ses.WatchDog -= ProcesarWD;
      _ses.Logout();
    }

    private void ProcesarWD(string s, DateTime d)
    {
      Dispatcher.Invoke(() =>
      {
        if (semaforo.Fill == Brushes.Blue)
          semaforo.Fill = Brushes.Red;
        else
        {
          semaforo.Fill = Brushes.Blue;
        }
      });
    }
  }
}
