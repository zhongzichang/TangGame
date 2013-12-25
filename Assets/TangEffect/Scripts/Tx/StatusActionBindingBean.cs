/**
 * Action Binding Bean
 * Date: 2013/11/6
 * Author: zzc
 */

using UnityEngine;
using TangScene;

namespace TangEffect
{
  public class StatusActionBindingBean : ActionBindingBean
  {
    public CharacterStatus status;

    public StatusActionBindingBean(long actorId, CharacterStatus status, int assetSetId, int assetId)
    : base(actorId, assetSetId, assetId)
    {
      this.status = status;
    }

  }
}