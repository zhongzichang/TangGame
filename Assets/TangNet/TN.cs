/**
 * Created by emacs
 * Date: 2013/10/14
 * Author: zzc
 */

using UnityEngine;
using PureMVC.Patterns;

namespace TangNet
{
  public class TN
  {

    public const string GOBJ_NAME = "TN";

    private static object m_staticSync = new object();
		
    /// <summary>
    ///   Ensure TS GameObject in scene
    /// </summary>
    public static GameObject EnsureTNGobj()
    {
      lock( m_staticSync )
	{
	  if( Cache.tnGobj == null )
	    {
	      Cache.tnGobj = GameObject.Find( GOBJ_NAME );
	      if( Cache.tnGobj == null )
		Cache.tnGobj = NewTNGobj();
	    }
	}
      return Cache.tnGobj;
    }


    public static bool Connected
    {
      get
	{
	  return Cache.connected;
	}
    }

    public static void Connect(string server, int port)
    {
      if( !Cache.connected )
	Cache.notificationQueue.Enqueue( new Notification(ConnectCmd.NAME, new ConnectBean(server, port)) );
    }

    public static void Reconnect()
    {
      if( !Cache.connected )
	Cache.notificationQueue.Enqueue( new Notification(ConnectCmd.NAME) );
    }

    public static void Close()
    {
      if( Cache.connected )
	Cache.notificationQueue.Enqueue( new Notification(CloseCmd.NAME) );
    }


    /// <summary>
    ///  Provide SocketClient For Deubugging
    /// </summary>
    public static SocketClient SocketClient
    {
      get
	{
	  if( Cache.tnGobj == null )
	    {
	      EnsureTNGobj();
	    }
	    return Cache.tnGobj.GetComponent<TnBhvr>().SocketClient;
	}
    }
		
	  

    /// <summary>
    ///   Send Request
    /// </summary>
    public static void Send(Request request)
    {
      Cache.Enqueue( request );
    }


    private static GameObject NewTNGobj()
    {
      GameObject gobj = new GameObject();
      gobj.name = GOBJ_NAME;
      gobj.AddComponent<TnBhvr>();
      gobj.AddComponent<TnFacadeBhvr>();
      return gobj;
    }
  }
}
