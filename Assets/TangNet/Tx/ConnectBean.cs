/**
 * Created by emacs
 * Author: zzc
 * Date: 2013/10/18
 */

namespace TangNet
{
  public class ConnectBean
  {
    public string server;
    public int port;

    public ConnectBean(string server, int port)
    {
      this.server = server;
      this.port = port;
    }
  }
}