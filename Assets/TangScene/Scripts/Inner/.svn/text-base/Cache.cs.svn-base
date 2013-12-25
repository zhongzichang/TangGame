/**
 * Created by emacs
 *
 * Date: 2013/10/8
 * Author: zzc
 */



using UnityEngine;
using System.Collections.Generic;
using PureMVC.Interfaces;

namespace TangScene
{

  public class Cache
  {
    public static bool isShuttingDown = false;
    public static bool isCursorInsideGUI = false;

    public static Queue<INotification> notificationQueue = new Queue<INotification>();
    public static Dictionary<long, GameObject> actors = new Dictionary<long, GameObject>();
    public static long controlledActorId = 0;
    public static long selectedActorId = 0;

    // Do not destroy when application running
    public static GameObject tsGobj;


    public static void Clear()
    {
      actors.Clear();
      controlledActorId = 0;
      selectedActorId = 0;
    }

    
  }

}