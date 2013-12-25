/**
 * Attack hit cmd
 *
 * Date: 2013/11/22
 * Author: zzc
 */

using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN = TangGame.Net;
using TGX = TangGame.Xml;
using TangEffect;


namespace TangGame
{
  public class AttackHitCmd : SimpleCommand
  {
    
    public override void Execute( INotification notification )
    {

      long actorId = (long) notification.Body;

      // 获取 attack token
      AttackToken attackToken = BattleCache.LastAttackToken( actorId );

      if( attackToken != null && Config.skillTable.ContainsKey( attackToken.skillId ) )
	{

	  // 获取技能
	  TGX.SkillData skill = Config.skillTable[ attackToken.skillId ];

	  // 如果是近身攻击
	  if( skill.Shotplay_type == Config.CLOSE_ATTACK )
	    {
	      // 显示战斗结果
	      TGN.BattleResultPush push = BattleCache.LastBattleResultPush( actorId );
	      if( push != null )
		{
		  // 显示战斗结果
		  SendNotification(ShowBattleResultCmd.NAME, push);
		  // 清除战斗缓存
		  BattleCache.Clear(actorId, push.tokenCode);		  		  
		}
	    }

	  // 如果是远程攻击
	  else
	    {
			      
	      int assetId = skill.Effect_shot;
	      int assetSetId = assetId;
	      if( assetId != 0 )
		{
		  // 让 TE 创建和抛出追踪物
		  TraceFlyBean traceFlyBean = new TraceFlyBean( attackToken.actorId, attackToken.targetId,
								(float) skill.Fly_speed,
								TE.DEFAULT_LIFETIME,
								TE.DEFAULT_RADIUS, 
								assetSetId, assetId,
								attackToken.code);
		  TE.TraceFly( traceFlyBean );
		      
		}
	    }
	}
    }
  }
}