/**
 * Hit Command
 * 特效命中角色的处理
 *
 * Date: 2013/11/15
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using TangEffect;
using TGN = TangGame.Net;

namespace TangGame
{
  public class HitCmd : SimpleCommand
  {

    public override void Execute( INotification notification )
    {
      HitBean bean = notification.Body as HitBean;
      if( bean != null )
	{
	  // 显示战斗结果
	  TGN.BattleResultPush push = BattleCache.GetBattleResultPush( bean.actorId, bean.tokenCode );
      
	  if( push != null )
	    {
	      SendNotification( ShowBattleResultCmd.NAME, push );
	      BattleCache.Clear( bean.actorId, push.tokenCode );
	    }

	}
    }

  }
}