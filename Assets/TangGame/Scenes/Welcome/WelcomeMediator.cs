/**
 * Created by emacs
 * Date: 2013/10/18
 * Author: zzc
 */

using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;

using TN = TangNet;

namespace TangGame
{

	public class WelcomeMediator : Mediator
	{
    public new const string NAME = "WELCOME_MEDIATOR";
		
		
		private delegate void Handle(INotification notification);
		private Dictionary<string, Handle> handleTable = new Dictionary<string, Handle>();
    private GameObject gameObject;

		public WelcomeMediator(GameObject gameObject) : base(NAME)
		{
      this.gameObject = gameObject;

      handleTable.Add( NtftNames.TG_PRELOAD_COMPLETED, HandlePreloadCompleted );
			handleTable.Add( TN.NtftNames.TN_CONNECT_SUCCESS, HandleConnectSuccess );
			handleTable.Add( TN.NtftNames.TN_CONNECT_FAILURE, HandleConnectFailure );
			handleTable.Add( TN.NtftNames.TN_EXCEPTION, HandleException );
			handleTable.Add( TN.NtftNames.TN_CONNECTION_CLOSE, HandleConnectionClose );
}

		public override IList<string> ListNotificationInterests()
		{
      List<string> interests = new List<string> ();
      foreach(string key in handleTable.Keys){
        interests.Add(key);
      }
      return interests;
		}

		public override void HandleNotification( INotification notification )
		{
			if( handleTable.ContainsKey( notification.Name ) )
			{
				handleTable[notification.Name]( notification );
			}
		}

    private void HandlePreloadCompleted(INotification notification){
      WelcomeNetworkBhvr networkBehaviour = this.gameObject.GetComponent<WelcomeNetworkBhvr>();
      TN.ConnectBean bean = notification.Body as TN.ConnectBean;
      TangNet.TN.Connect(networkBehaviour.server, networkBehaviour.port);
      Facade.SendNotification(NtftNames.TG_LOADING_MESSAGE, LoadingLang.NETWORK_CONNECTING);
    }

    private void HandleConnectSuccess( INotification notification )
    {
      Application.LoadLevel("Home");
    }

    
    private void ShowErrorMessge (string message)
    {
      Facade.SendNotification(NtftNames.TG_SHOW_ERROR_MESSAGE, message);
    }

		private void HandleConnectFailure( INotification notification )
		{
      ShowErrorMessge(LoadingLang.NETWORK_CONNECT_FAILED);
		}

		private void HandleConnectionClose( INotification notification )
		{
      ShowErrorMessge(LoadingLang.NETWORK_CONNECT_CLOSED);
		}

		private void HandleException( INotification notification )
		{
      ShowErrorMessge(LoadingLang.NETWORK_CONNECT_EXCEPTION);
		}
		
	}
	
}