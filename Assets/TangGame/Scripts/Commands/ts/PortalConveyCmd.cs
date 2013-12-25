/**
 * Portal convey command
 *
 * Date: 2013/11/23
 * Author: zzc
 */


using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TN = TangNet;
using TangGame.Net;


namespace TangGame
{
  public class PortalConveyCmd : SimpleCommand
  {
    public override void Execute( INotification notification )
    {

      int portalId = (int) notification.Body;

      if( portalId != 0 )
	{
	  TN.TN.Send(new PortalConveyRequest( portalId) );
	}
      
    }
  }
}