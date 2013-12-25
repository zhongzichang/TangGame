using UnityEngine;
using System.Collections;
using System;
using System.Net.Sockets;
using PureMVC.Patterns;

namespace TangNet
{
	
  public class TnBhvr : MonoBehaviour {


    public string server;
    public int port;

    private SocketClient socketClient = new SocketClient();

    public SocketClient SocketClient
    {
      get
	{
	  return socketClient;
	}
    }

    public void Connect()
    {
      if( !socketClient.Connecting
	  && !socketClient.Connected
	  && !String.IsNullOrEmpty(server)
	  && port != 0 )
	{
	  socketClient.Connect(server, port);
	}
    }

    public void Close()
    {
      if( socketClient.Connecting || socketClient.Connected )
	socketClient.Close();
    }

    void Start()
    {
      DontDestroyOnLoad(gameObject);
      socketClient.closeHandler += OnSocketClose;
      socketClient.exceptionHandler += OnSocketException;
      socketClient.connectSuccessHandler += OnSocketConnectSuccess;
      socketClient.connectFailureHandler += OnSocketConnectFailure;
      Cache.connected = false;
    }

    // Update is called once per frame
    void Update () {
      if( socketClient.Connected )
	{
	  int count = Cache.RequestCount;
	  // Send Messages
	  if( count > 0 )
	    {
	      for( int i=0; i<count ; i++ )
		{
		  Request request = Cache.Dequeue();
		  if( request != null )
		    {
		      socketClient.SendMessage( request.NetData );
		    }

		}
	    }
	}

			
    }

    void OnApplicationQuit()
    {
      Close();
    }


    private void OnSocketClose( Socket socket )
    {
      Cache.connected = false;
      Cache.notificationQueue.Enqueue( new Notification(NtftNames.TN_CONNECTION_CLOSE) );
    }

    private void OnSocketException( Socket socket, Exception exception )
    {
      Cache.notificationQueue.Enqueue( new Notification(NtftNames.TN_EXCEPTION, exception) );
    }

    private void OnSocketConnectSuccess( Socket socket )
    {
      Cache.connected = true;
      Cache.notificationQueue.Enqueue( new Notification(NtftNames.TN_CONNECT_SUCCESS) );
    }

    private void OnSocketConnectFailure( Socket socket )
    {
      Cache.notificationQueue.Enqueue( new Notification(NtftNames.TN_CONNECT_FAILURE) );
    }

  }
}
