/*
 * Created by emacs
 * Date: 2013/9/11
 * Author: zzc
 */

using System;
using UnityEngine;
using PureMVC.Patterns;
using Tang;


namespace TangScene
{
  [ExecuteInEditMode]
  public class ActorBhvr : MonoBehaviour
  {

    private const float HEIGHT = 10F;

    public long id;
    public int baseId;
    public string nickName;
    public ActorType actorType;

#region Mono Methods

    // Use this for initialization
    void Start () {
			
      OnStart();

      LateStart();

    }// m.Start

    void OnDestroy()
    {
      if( Cache.actors.ContainsKey( id ) )
	Cache.actors.Remove(id);
    }

    void OnTouch(TouchHit touchHit)
    {
      // 发出被触摸的消息
      if( Cache.controlledActorId != id )
	{
	  Facade.Instance.SendNotification( NtftNames.TOUCH_ACTOR,
					    new ActorTouchHit(id, touchHit) ) ;

	  // 高亮衰减
	  HighlightFadeBhvr highlightFadeBhvr = GetComponent<HighlightFadeBhvr>();
	  if( highlightFadeBhvr == null )
	    highlightFadeBhvr = gameObject.AddComponent<HighlightFadeBhvr>();
	  else if( !highlightFadeBhvr.enabled )
	    highlightFadeBhvr.enabled = true;

	}


    }
		
#endregion

    protected void OnStart()
    {

      if( id == 0 )
	id = baseId;

      Vector3 pos = transform.localPosition;
      transform.localPosition = new Vector3(pos.x, HEIGHT, pos.z);

      if( ! String.IsNullOrEmpty(nickName) )
	gameObject.name =  nickName + Tang.Config.NAME_SEP + baseId + Tang.Config.NAME_SEP + id;
      else
	gameObject.name =  Texts.ACTOR + Tang.Config.NAME_SEP + baseId + Tang.Config.NAME_SEP + id;
			
    }


    protected void LateStart()
    {

      if( !Cache.actors.ContainsKey( id ) )
	Cache.actors.Add(id, gameObject);
			
    }

		
		
  }
}