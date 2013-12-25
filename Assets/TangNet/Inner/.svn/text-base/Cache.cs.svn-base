/**
 * Created by emacs
 * Date: 2013/10/15
 * Author: zzc
 */

using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;

namespace TangNet
{
  public class Cache
  {

    private static readonly object m_staticRequestSync = new object();
    private static Queue<Request> requestQueue = new Queue<Request>();

    public static GameObject tnGobj = null;
    public static Queue<INotification> notificationQueue = new Queue<INotification>();

    public static int RequestCount
    {
      get
	{
	  return requestQueue.Count;	  
	}
    }

    public static void Enqueue(Request request)
    {
      lock(m_staticRequestSync)
	{
	  requestQueue.Enqueue(request);	  
	}
    }

    public static Request Dequeue()
    {
      lock(m_staticRequestSync)
	{
	  return requestQueue.Dequeue();
	}
    }

    public static bool connected = false;

  }
}