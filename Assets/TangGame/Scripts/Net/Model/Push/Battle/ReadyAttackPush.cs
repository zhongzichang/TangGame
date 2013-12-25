/**
 * ready attack push
 *
 * Author: zzc
 *
 * Date: 2013/11/12
 * Edit: zzc
 * Desc: add tokenCode
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  /// <summary>
  /// Description of ReadyAttackPush.
  /// </summary>

  [Response(NAME)]
  public class ReadyAttackPush : Response
  {
    public const string NAME = "readyAttack_PUSH";

    /// <summary>
    ///   1 Player 2 Monster 3 NPC 4 Pet
    /// </summary>
    public short sourceType;
    public long actorId;
    public long targetId;
    public int skillId;
    public byte tokenCode;

    public  ReadyAttackPush () : base(NAME)
    {
    }

    public static ReadyAttackPush Parse (MsgData data)
    {

      ReadyAttackPush push = new ReadyAttackPush ();

      int index = 0;

      push.sourceType = data.GetShort (index++);
      push.actorId = data.GetLong (index++);
      push.targetId = data.GetLong (index++);
      push.skillId = data.GetInt (index++);
      push.tokenCode = data.GetByte(index++);

      return push;

    }
  }
}