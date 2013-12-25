/**
 * Battle cache
 *
 * Date: 2011/11/12
 * Author: zzc
 */

using System.Collections.Generic;
using TangGame.Net;

namespace TangGame
{

  public class BattleCache
  {

    public static bool onHook = false;


#region PrivateFields
    
    /// <summary>
    ///   主角的 token 计数器，在每一次主角发起攻击时，需要将这个数值 +1
    /// </summary>
    private static byte tokenCounter = 0;


    /// <summary>
    ///   场景上所有角色的 AttackToken
    /// </summary>
    private static Dictionary<long, Dictionary<byte,AttackToken>> attackTokenTable 
    = new Dictionary<long, Dictionary<byte, AttackToken>>();

    /// <summary>
    ///   所有角色的 BattleResult
    /// </summary>
    private static Dictionary<long, Dictionary<byte,BattleResultPush>> battleResultTable
    = new Dictionary<long, Dictionary<byte, BattleResultPush>>();

    /// <summary>
    ///   所有角色最后一次攻击的 token code
    /// </summary>
    public static Dictionary<long, byte> lastTokenCodeTable = new Dictionary<long, byte>();

#endregion

#region AttackTokenProperties

    /// <summary>
    ///   主角的 token counter
    /// </summary>
    public static byte LeadingTokenCounter
    {
      get
	{
	  return tokenCounter;
	}
    }

#endregion


#region AttackTokenMethods

    public static AttackToken NewLeadingAttackToken(int skillId, long targetId)
    {
      AttackToken token = new AttackToken( ActorCache.leadingActorId, targetId,
					   tokenCounter++, AttackToken.Status.wait, skillId);
      return token;

    }

    public static void PutAttackToken(AttackToken token)
    {
      if( attackTokenTable.ContainsKey( token.actorId ) )
	{
	  if( attackTokenTable[ token.actorId ].ContainsKey( token.code ) )
	    attackTokenTable[ token.actorId ][ token.code ] = token;
	  else
	    attackTokenTable[ token.actorId ].Add( token.code, token );
	}
      else
	{
	  Dictionary<byte, AttackToken> dic = new Dictionary<byte, AttackToken>();
	  dic.Add( token.code, token );
	  attackTokenTable.Add( token.actorId, dic );
	}

      lastTokenCodeTable[token.actorId] = token.code;
    }

    public static AttackToken GetAttackToken(long actorId, byte tokenCode)
    {
      if( attackTokenTable.ContainsKey( actorId ) )
	{
	  if( attackTokenTable[ actorId ].ContainsKey( tokenCode ) )
	    {
	      return attackTokenTable[ actorId ][ tokenCode ];
	    }
	}
      return null;

    }

    public static void RemoveAttackToken(long actorId, byte tokenCode)
    {
      if( attackTokenTable.ContainsKey( actorId ) )
	{
	  if( attackTokenTable[ actorId ].ContainsKey( tokenCode ) )
	    {
	      attackTokenTable[ actorId ].Remove( tokenCode );
	    }
	}
      
    }

    public static AttackToken LastAttackToken(long actorId)
    {
      if( lastTokenCodeTable.ContainsKey( actorId ) )
	{
	  return GetAttackToken(actorId, lastTokenCodeTable[ actorId ]);
	}
      return null;
    }


#endregion


#region BattleResultPushMethods

    public static void PutBattleResultPush(BattleResultPush push)
    {
      if( battleResultTable.ContainsKey( push.sourceId ) )
	{
	  if( battleResultTable[ push.sourceId ].ContainsKey( push.tokenCode ) )
	    battleResultTable[ push.sourceId ][ push.tokenCode ] = push;
	  else
	    battleResultTable[ push.sourceId ].Add( push.tokenCode, push );
	}
      else
	{
	  Dictionary<byte, BattleResultPush> dic = new Dictionary<byte, BattleResultPush>();
	  dic.Add( push.tokenCode, push );
	  battleResultTable.Add( push.sourceId, dic );
	}
    }

    public static BattleResultPush GetBattleResultPush(long actorId, byte tokenCode)
    {
      if( battleResultTable.ContainsKey( actorId ) )
	{
	  if( battleResultTable[ actorId ].ContainsKey( tokenCode ) )
	    {
	      return battleResultTable[ actorId ][ tokenCode ];
	    }
	}
      return null;
    }

    public static void RemoveBattleResultPush(long actorId, byte tokenCode)
    {
      if( battleResultTable.ContainsKey( actorId ) )
	{
	  if( battleResultTable[ actorId ].ContainsKey( tokenCode ) )
	    {
	      battleResultTable[ actorId ].Remove( tokenCode );
	    }
	}
    }

    public static BattleResultPush LastBattleResultPush(long actorId)
    {
      if( lastTokenCodeTable.ContainsKey( actorId ) )
	{
	  return GetBattleResultPush(actorId, lastTokenCodeTable[ actorId ]);
	}
      return null;
    }

#endregion

    public static void Clear( long actorId, byte tokenCode )
    {
      BattleCache.RemoveAttackToken( actorId, tokenCode );
      BattleCache.RemoveBattleResultPush( actorId, tokenCode );
    }

    public static void Clear()
    {
      attackTokenTable.Clear();
      battleResultTable.Clear();
    }

  }
  
}