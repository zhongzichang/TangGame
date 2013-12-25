/*
 * Created by emacs
 * Date: 2013/9/11
 * Author: zzc
 */
using System;
using System.Xml.Serialization;
using UnityEngine;


namespace TangScene
{
  public class Actor : TsObject
  {

    public long id = 0;
    public int baseId = 0;
    public string nickName = "default";
    public ActorType actorType = ActorType.npc;
    public CharacterStatus status = CharacterStatus.idle;
    public EightDirection direction = EightDirection.D;
    public float speed = 240F;
	  
		
    public Actor(long id,int baseId,string nickName){
      this.id=id;
      this.baseId=baseId;
      this.nickName=nickName;
      this.name=nickName;
    }
    public Actor(){
			
    }

  }
}