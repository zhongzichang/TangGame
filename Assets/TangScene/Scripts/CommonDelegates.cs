/**
 * Created by Emacs
 * Date: 2013/9/2
 * Author: zzc
 */

using UnityEngine;

namespace TangScene
{
  public class CommonDelegates
  {

    // scene click
    public delegate void Location(Vector3 position);
    public static Location locationHandler;

  }
}