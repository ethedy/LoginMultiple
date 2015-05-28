using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Entidades.Seguridad;
using System.Threading;

namespace Servicios
{
  /// <summary>
  /// Mantiene durante el transcurso de la aplicacion toda la informacion necesaria asociada con el usuario conectado
  /// </summary>
  public class Sesion
  {
    private Task _wdTask;
    private CancellationTokenSource _tokenSource;

    public event Action<string, DateTime> WatchDog;

    public Usuario UsuarioConectado { get; private set; }

    public string FullName
    {
      get
      {
        return string.Format("{0} {1}",
          UsuarioConectado.Persona.Nombre,
          UsuarioConectado.Persona.Apellido);
      }
    }

    public DateTime FechaExpiracion
    {
      get { return UsuarioConectado.FechaExpiracionPassword; }
    }

    public Sesion(Usuario usr)
    {
      UsuarioConectado = usr;
      CancellationToken tkn;
      
      _tokenSource = new CancellationTokenSource();
      tkn = _tokenSource.Token;

      _wdTask = new Task(() =>
      {
        while (true)
        {
          if (tkn.IsCancellationRequested)
            break;
          Thread.Sleep(2000);
          if (WatchDog != null)
            WatchDog("I'm alive!!!", DateTime.Now);
        }
      }, tkn);
      _wdTask.Start();
    }

    public void Logout()
    {
      _tokenSource.Cancel();
      _wdTask.Wait();
      _tokenSource.Dispose();
    }
  }
}
