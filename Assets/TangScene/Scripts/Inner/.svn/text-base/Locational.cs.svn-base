/**
 * Created by emacs
 *
 * Date: 2013/10/1
 * Author: zzc
 */
using PureMVC.Patterns;
using UnityEngine;
using Tang;

namespace TangScene
{
  public class Locational : MonoBehaviour
  {

    void OnTouch (TouchHit touchHit)
    {

      // 取消已选择角色的选中状态
      if (Cache.selectedActorId != 0)
	Facade.Instance.NotifyObservers (new Notification (UnselectActorCmd.NAME));
      
      Facade.Instance.SendNotification (NtftNames.TOUCH_MAP, touchHit);

    }
  }
}