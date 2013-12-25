/*
 * Created by emacs
 * Date: 2013/10/5
 * Author: zzc
 */

using System;
using UnityEngine;

namespace TangScene
{

  [Serializable]
  public class SkillEffect
  {

    public long casterId;
    public long[] receiverIds;
    public EightDirection direction;
    public Vector3 position;
    public int specialEffectId;

    public override string ToString()
    {
      return "casterId: " + casterId
	+ "; receiverIds: " + receiverIds
	+ "; direction: " + direction
	+ "; position: " + position
	+"; specialEffectId: " + specialEffectId;
    }
  }
}