/**
 * Cache for TangEffect
 * Date: 2013/11/7
 * Author: zzc
 */

using PureMVC.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace TangEffect
{
  public class Cache
  {


    public static GameObject teGobj = null;

    public static GameObject selectedEffect = null;

    /// <summary>
    ///   通知队列
    /// </summary>
    public static Queue<INotification> notificationQueue = new Queue<INotification>();


    /// <summary>
    ///   特效对象
    /// </summary>
    public static Dictionary<int, GameObject> effects = new Dictionary<int, GameObject>();

  }
}