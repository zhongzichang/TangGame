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
  public class CloseCmd : SimpleCommand
  {
    public const string NAME = "TN_CLOSE";

    public override void Execute( INotification notification )
    {
      if( Cache.connected && Cache.tnGobj != null )
	{
	  TnBhvr tnBhvr = Cache.tnGobj.GetComponent<TnBhvr>();
	  if( tnBhvr != null )
	    tnBhvr.Close();
	}
    }
  }
}