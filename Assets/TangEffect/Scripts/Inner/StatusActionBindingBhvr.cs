/**
 * Status action binding bhvr
 * Date: 2013/11/8
 * Author: zzc
 */

using UnityEngine;
using TangScene;

namespace TangEffect
{

  
  public class StatusActionBindingBhvr : ActionBindingBhvr
  {
    /// <summary>
    ///   只能在指定状态下才显示
    /// </summary>
    public CharacterStatus status;

    protected override void LateStart()
    {
      // 如果只需要在指定状态下显示出来
      if( status != statusBhvr.Status )
	transform.localScale = Vector3.zero;
 
    }

    protected override void OnTargetStatusChange( CharacterStatus status )
    {
      statusBhvr.Status = status;
      if( this.status != statusBhvr.Status )
	transform.localScale = Vector3.zero;
      else
	transform.localScale = Vector3.one;

    }

  }
}