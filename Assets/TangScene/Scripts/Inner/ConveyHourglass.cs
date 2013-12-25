/**
 * Convey hourglass
 * 传送沙漏
 * Date: 2013/11/22
 * Author: zzc
 */

using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangScene
{
  public class ConveyHourglass : MonoBehaviour
  {

    public const float TIME = 2F;
    
    private Vector3 lastPosition = Vector3.zero;
    private Transform myTransform;

    void Awake()
    {

      myTransform = transform;
      //Facade.Instance.SendNotification(NtftNames.PORTAL_CONVEY, );
      
    }


    void OnEnable()
    {
      lastPosition = myTransform.localPosition;
    }

    void OnDisable()
    {
      
    }

  }
}