using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TGN = TangGame.Net;
using TGX = TangGame.Xml;
using TS=TangScene;
using TangUtils;
using zyhd.TEffect;

namespace TangGame
{
  public class ActorCache
  {
    /// <summary>
    /// 生命值集合
    /// </summary>
    public static Dictionary<long,TEffect> hitPointsDictionary = new Dictionary<long, TEffect> ();
    /// <summary>
    /// 名字集合
    /// </summary>
    public static Dictionary<long,TEffect> nameLabelDictionary = new Dictionary<long, TEffect> ();
    /// <summary>
    /// The leading actor identifier.
    /// </summary>
    public static long leadingActorId = 0;
    /// <summary>
    /// The target actor identifier.
    /// </summary>
    public static long targetActorId = 0;
    /// <summary>
    /// 被划中的角色ID
    /// </summary>
    public static List<long> swipeActorIds = new List<long> ();
    /// <summary>
    /// 被划中的英雄ID
    /// </summary>
    public static List<long> swipeHeroIds = new List<long> ();
    /// <summary>
    /// 被划中的怪物ID
    /// </summary>
    public static List<long> swipeMonsterIds = new List<long> ();
    /// <summary>
    ///   被划中的NPC ID
    /// </summary>
    public static List<long> swipeNpcIds = new List<long>();
    /// <summary>
    /// 来往网络的角色数据
    /// </summary>
    public static Dictionary<long,TGN.ActorNo> actors = new Dictionary<long, TangGame.Net.ActorNo> ();
    /// <summary>
    /// Adds the or update swipe actor identifier.
    /// </summary>
    /// <param name='id'>
    /// Identifier.
    /// </param>
    public static void AddOrUpdateSwipeActorId (long id)
    {
      if (!swipeActorIds.Contains (id)) {
        swipeActorIds.Add (id);
      }
    }
    /// <summary>
    /// Adds the or update swipe actor identifier.
    /// </summary>
    /// <param name='id'>
    /// Identifier.
    /// </param>
    public static void AddOrUpdateSwipeHeroId (long id)
    {
      if (!swipeHeroIds.Contains (id)) {
        swipeHeroIds.Add (id);
      }
    }
    /// <summary>
    /// Adds the or update swipe actor identifier.
    /// </summary>
    /// <param name='id'>
    /// Identifier.
    /// </param>
    public static void AddOrUpdateSwipeMonsterId (long id)
    {
      if (!swipeMonsterIds.Contains (id)) {
        swipeMonsterIds.Add (id);
      }
    }
    /// <summary>
    ///   Add or update swipe swiped NPC ID
    /// </summary>
    public static void AddOrUpdateSwipeNpcId (long id )
    {
      if (!swipeNpcIds.Contains( id ) )
	{
	  swipeNpcIds.Add(id);
	}
    }
    
    
    /// <summary>
    /// 更新或者是添加一个角色
    /// </summary>
    /// <param name='id'>
    /// Identifier.
    /// </param>
    /// <param name='actor'>
    /// Actor.
    /// </param>
    public static void AddOrUpdateActor (long id, TGN.ActorNo actor)
    {
      if (actors.ContainsKey (id)) {
        actors [id] = actor;
      } else {
        actors.Add (id, actor);
      }
    }
    /// <summary>
    /// 获取一个场景角色数据，用于场景实例化角色
    /// </summary>
    /// <returns>
    /// The actor.
    /// </returns>
    /// <param name='id'>
    /// Identifier.
    /// </param>
    public static TS.Actor GetActor (long id)
    {
      if (actors.ContainsKey (id)) {
        TS.Actor actor = new TS.Actor ();
        Tang.TsAnimation animation = new Tang.TsAnimation ();
        List<Tang.TsLayer> layers = new List<Tang.TsLayer> ();
        TGN.ActorNo actorNo = actors [id];
        actor.id = actorNo.id;
        actor.name = actorNo.name;
        actor.localPosition = GridUtil.PointToVector3 (actorNo.x, actorNo.y);
        //判断是否为英雄
        if (actorNo is TGN.HeroNew) {
          CreateHeroActorForScene (actor, layers, actorNo);
        }
        //判断是否为怪物
        if (actorNo is TGN.Monster) {
          CreateMonsterActorForScene (actor, layers, actorNo);
          
        }
        //判断是否为NPC
        if (actorNo is TGN.Npc) {
          CreateNpcActorForScene (actor, layers, actorNo);
        }
        animation.layers = layers.ToArray ();
        actor.animation = animation;
        return actor;
      }
      return null;
    }
    /// <summary>
    /// 创建一个英雄角色场景对象
    /// </summary>
    /// <param name="actor"></param>
    /// <param name="layers"></param>
    /// <param name="actorNo"></param>
    private static void CreateHeroActorForScene (TS.Actor actor, List<Tang.TsLayer> layers, TGN.ActorNo actorNo)
    {
      actor.actorType = TangScene.ActorType.hero;
      TGN.HeroNew hero = actorNo as TGN.HeroNew;
      //TODO 简化layer的生成过程
      /// <summary>
      /// 如果角色有身体，则显示身体
      /// </summary>
      if (!string.IsNullOrEmpty (hero.resourcesId)) {
        Tang.TsLayer layer = new Tang.TsLayer ();
        Tang.TsSprite sprite = new Tang.TsSprite ();
        sprite.name = hero.resourcesId;
        layer.name = Tang.BodyLayer.NAME;
        layer.sprite = sprite;
        layers.Add (layer);
      }
      /// <summary>
      /// 如果人物有武器，则显示武器
      /// </summary>
      if (!string.IsNullOrEmpty (hero.weaponResourcesId)) {
        Tang.TsLayer layer = new Tang.TsLayer ();
        Tang.TsSprite sprite = new Tang.TsSprite ();
        sprite.name = hero.weaponResourcesId;
        layer.name = Tang.WeaponLayer.NAME;
        layer.sprite = sprite;
        layers.Add (layer);
      }
    }
    /// <summary>
    /// 创建一个怪物角色场景对象
    /// </summary>
    /// <param name="actor"></param>
    /// <param name="layers"></param>
    /// <param name="actorNo"></param>
    private static void CreateMonsterActorForScene (TS.Actor actor, List<Tang.TsLayer> layers, TGN.ActorNo actorNo)
    {
      actor.actorType = TangScene.ActorType.monster;
      TGN.Monster monster = actorNo as TGN.Monster;
      string avatarId = monster.resourcesId;
      if (!string.IsNullOrEmpty (avatarId)) {
        Tang.TsLayer layer = new Tang.TsLayer ();
        Tang.TsSprite sprite = new Tang.TsSprite ();
        sprite.name = avatarId;
        layer.name = Tang.BodyLayer.NAME;
        layer.sprite = sprite;
        layers.Add (layer);
      }
    }
    /// <summary>
    /// 创建一个NPC场景角色对象
    /// </summary>
    /// <param name="actor"></param>
    /// <param name="layers"></param>
    /// <param name="actorNo"></param>
    private static void CreateNpcActorForScene (TS.Actor actor, List<Tang.TsLayer> layers, TGN.ActorNo actorNo)
    {
      actor.actorType = TangScene.ActorType.npc;
      TGN.Npc npc = actorNo as TGN.Npc;
      string avatarId = npc.resourcesId;
      if (!string.IsNullOrEmpty (avatarId)) {
        Tang.TsLayer layer = new Tang.TsLayer ();
        Tang.TsSprite sprite = new Tang.TsSprite ();
        sprite.name = avatarId;
        layer.name = Tang.BodyLayer.NAME;
        layer.sprite = sprite;
        layers.Add (layer);
      }
    }
    
    
    /// <summary>
    /// Gets the leading hero.
    /// </summary>
    /// <returns>
    /// The leading hero.
    /// </returns>
    public static TGN.HeroNew GetLeadingHero ()
    {
      TGN.ActorNo actorNo = GetLeadingActor ();
      if (actorNo != null) {
        return actorNo as TGN.HeroNew;
      }
      return null;
    }
    /// <summary>
    /// Gets the leading actor.
    /// </summary>
    /// <returns>
    /// The leading actor.
    /// </returns>
    public static TGN.ActorNo GetLeadingActor ()
    {
      return actors [leadingActorId];
    }
    /// <summary>
    /// Gets the monster by identifier.
    /// </summary>
    /// <returns>
    /// The monster by identifier.
    /// </returns>
    /// <param name='id'>
    /// Identifier.
    /// </param>
    public static TGN.Monster GetMonsterById (long id)
    {
      if (actors.ContainsKey (id)) {
        return actors [id] as TGN.Monster;
      }
      return null;
    }
    /// <summary>
    /// Gets the monster by identifier.
    /// </summary>
    /// <returns>
    /// The monster by identifier.
    /// </returns>
    /// <param name='id'>
    /// Identifier.
    /// </param>
    public static TGN.HeroNew GetHeroById (long id)
    {
      if (actors.ContainsKey (id)) {
        return actors [id] as TGN.HeroNew;
      }
      return null;
    }
    /// <summary>
    /// Gets the npc by identifier.
    /// </summary>
    /// <returns>
    /// The npc by identifier.
    /// </returns>
    /// <param name='id'>
    /// Identifier.
    /// </param>
    public static TGN.Npc GetNpcById (long id)
    {
      if (actors.ContainsKey (id)) {
        return actors [id] as TGN.Npc;
      }
      return null;
    }
    /// <summary>
    /// 根据配置表ID获取一个NPC对象
    /// </summary>
    /// <returns>The npc by config identifier.</returns>
    /// <param name="id">Identifier.</param>
    public static TGN.Npc GetNpcByConfigId (int Configid)
    {
      TangGame.Net.Npc npcNo = null;
      //循环根据NPC配置ID找到某个NPC
      foreach (TangGame.Net.ActorNo actorNo in ActorCache.actors.Values) {
        if (actorNo is TangGame.Net.Npc) {
          TangGame.Net.Npc npcNo1;
          npcNo1 = actorNo as TangGame.Net.Npc;
          if(npcNo1.configId == Configid){
            return npcNo1;
          }
        }
      }
      return npcNo;
    }
    /// <summary>
    /// 获取所有NPC的数据
    /// </summary>
    /// <returns></returns>
    public static Dictionary<long, TangGame.Net.Npc> GetNpcActors(){
      Dictionary<long, TangGame.Net.Npc> npcActors = new Dictionary<long, TangGame.Net.Npc>();
      foreach (TangGame.Net.ActorNo actorNo in ActorCache.actors.Values) {
        if (actorNo is TangGame.Net.Npc) {
          npcActors.Add(actorNo.id , actorNo as TangGame.Net.Npc);
        }
      }
      return npcActors;
    }

    /// <summary>
    /// Clears the except leading actor.
    /// </summary>
    public static void ClearExceptLeadingActor ()
    {
      TGN.ActorNo leadingActor = actors [leadingActorId];
      actors.Clear ();
      actors.Add ( leadingActorId, leadingActor );
    }
    
    public static TS.ActorType GetActorTypeById (long id)
    {
      if (!actors.ContainsKey (id))
        return TS.ActorType.npc;
      
      if (actors [id] is TGN.Monster)
        return TS.ActorType.monster;
      
      if (actors [id] is TGN.HeroNew)
        return TS.ActorType.hero;
      
      return TS.ActorType.npc;
    }
  }
}
