
/*
 * Battle result push
 * Author: zzc
 * Date: 2013/3/25
 * Time: 14:26
 *
 * Date: 2013/11/12
 * Edit: zzc
 * Desc: add tokenCode
 */
using System;
using UnityEngine;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
  /// <summary>
  /// Battle result push.
  /// </summary>
  [Response(NAME)]
  public class BattleResultPush : Response
  {

    public const string NAME = "BattleResult_PUSH";
    public short sourceType; // 1:Player 2:Monster 3:NPC 4:Pet
    public long sourceId;
    public int hp;
    public int mp;
    public List<BattleMsg> battleMsgList;
    public byte tokenCode; // token code : 标记角色的一次攻击

    public BattleResultPush () : base(NAME)
    {
    }

    public static BattleResultPush Parse (MsgData data)
    {

      BattleResultPush push = new BattleResultPush ();
      int index = 0;
      push.sourceType = data.GetShort (index++);
      push.sourceId = data.GetLong (index++);
      push.hp = data.GetInt (index++);
      push.mp = data.GetInt (index++);
      MsgData battleMsgsData = data.GetMsgData (index++);
      List<BattleMsg> battleMsgList = new List<BattleMsg> ();
      for (int i=0; i<battleMsgsData.Size; i++) {
	battleMsgList.Add (BattleMsg.Parse (battleMsgsData.GetMsgData (i)));
      }
      push.battleMsgList = battleMsgList;
      push.tokenCode = data.GetByte( index++ );

      return push;


    }
  }
}
