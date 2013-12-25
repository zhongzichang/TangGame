/*
 * Created by emacs
 * Date: 2013/10/9
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;


namespace TangScene
{
  public class ActorAttackCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_ACTOR_ATTACK";

    public override void Execute( INotification notification )
    {
      AttackBean bean = notification.Body as AttackBean;
      if( bean != null &&  Cache.actors.ContainsKey( bean.casterId ) )
	{

	  GameObject caster = Cache.actors[bean.casterId];

	  // single attack ------

	  if( bean is SingleAttackBean)
	    {

	      SingleAttackBean sab = bean as SingleAttackBean;
	      if( Cache.actors.ContainsKey( sab.receiverId ) )
		{
		  GameObject receiver = Cache.actors[sab.receiverId];

		  EightDirection attackDirection = VectorUtils.Direction(caster.transform.localPosition, receiver.transform.localPosition );
		  Directional directional = caster.GetComponent<Directional>();
		  if( attackDirection != directional.Direction )
		    directional.Direction = attackDirection;
		}
	    }

	  // directional attack ------

	  else if( bean is DirectionalAttackBean )
	    {

	      DirectionalAttackBean dab = bean as DirectionalAttackBean;
	      Directional directional = caster.GetComponent<Directional>();
	      if( dab.direction != directional.Direction )
		directional.Direction = dab.direction;
	      
	    }


	  // range attack bean ------

	  else if( bean is RangeAttackBean )
	    {

	      RangeAttackBean rab = bean as RangeAttackBean;
	      if( rab.center != Vector3.zero )
		{
		  EightDirection attackDirection = VectorUtils.Direction(caster.transform.localPosition, rab.center );
		  Directional directional = caster.GetComponent<Directional>();
		  if( attackDirection != directional.Direction )
		    directional.Direction = attackDirection;
		  
		}
	    }

	  // play default attack action
	  CharacterStatusBhvr characterStatusBhvr = Cache.actors[bean.casterId].GetComponent<CharacterStatusBhvr>();
	  characterStatusBhvr.Status = CharacterStatus.attack;
	      
	}
    }
  }
}