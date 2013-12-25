/*
 * Ready attack result
 *
 * Author: zzc
 * Date: 2013/3/25
 * Time: 12:40
 *
 * Date: 2013/11/12
 * Edit: zzc
 * Desc: add tokenCode
 *
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  /// <summary>
  /// Description of ReadyAttackResult.
  /// </summary>
  [Response(NAME)]	
  public class ReadyAttackResult : Response
  {
    public const string NAME = "readyAttack_RESULT";
    public short sourceType;
    public long actorId;
    public long targetId;
    public int skillId;
    public byte tokenCode;

    public ReadyAttackResult () : base(NAME)
    {
    }

    public ReadyAttackResult(short statusCode) : base(NAME, statusCode)
    {
    }

    public static ReadyAttackResult Parse (MsgData data)
    {	

      ReadyAttackResult result = new ReadyAttackResult ();
      int index = 0;
      result.sourceType = data.GetShort (index++);
      result.actorId = data.GetLong (index++);
      result.targetId = data.GetLong (index++);
      result.skillId = data.GetInt (index++);

      if( index < data.Size )
	result.tokenCode = data.GetByte(index++);
        
      return result;

    }

    public static ReadyAttackResult Parse(short statusCode, MsgData data )
    {

      ReadyAttackResult result = Parse( data );
      result.StatusCode = statusCode;
      return result;
      
    }

  }
}
