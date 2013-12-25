/**
 * Created by emacs
 * Date: 2013/10/18
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangNet
{
  public class ConnectCmd : SimpleCommand
  {
    public const string NAME = "TN_CONNECT";

    public override void Execute( INotification notification )
    {
      if( !Cache.connected && Cache.tnGobj != null )
	{
	  ConnectBean bean = notification.Body as ConnectBean;
	  TnBhvr tnBhvr = Cache.tnGobj.GetComponent<TnBhvr>();
	  if( tnBhvr != null )
	    {
	      if( bean != null )
		{
		  tnBhvr.server = bean.server;
		  tnBhvr.port = bean.port;
		}
	      tnBhvr.Connect();

	    }
	}
    }
  }
}