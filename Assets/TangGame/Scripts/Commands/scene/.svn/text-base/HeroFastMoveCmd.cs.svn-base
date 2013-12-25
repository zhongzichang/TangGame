/**
 * Remote command for heroFastMove_PUSH
 * 
 * Date: 2013/11/1
 * Author: zzc
 *
 * Date: 2013/11/21
 * Edit: zzc
 * Desc: 使用目标位置进行冲刺
 */
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;
using TangUtils;

namespace TangGame
{
  /// <summary>
  /// 英雄快速移动处理
  /// </summary>
  public class HeroFastMoveCmd : SimpleCommand
  {
    public static string NAME = TGN.HeroFastMovePush.NAME;

    public override void Execute (INotification notification)
    {
			
      TGN.HeroFastMovePush push = notification.Body as TGN.HeroFastMovePush;

      if ( TS.TS.GetActorGameObject (push.sourceId) != null )
	{
	  // TS.TS.Sprint(push.sourceId, GridUtil.PointToVector3(push.endx, push.endy) );
	  //TS.TS.Sprint (push.sourceId, push.targetId);
	  // 主角已经提前冲刺
	  if( push.sourceId != ActorCache.leadingActorId )
	    {
	      
	     TS.TS.Sprint(push.sourceId, GridUtil.PointToVector3(push.endx, push.endy) ); 
	    }
	}
    }
  }
}


