/*
 * Created by emacs
 * Author: zzc
 * Date: 2013/5/31
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TangScene;

namespace TangGame.View
{

  public class ActorVo
  {

    public long Id
    {
      get;
      private set;
    }

    // actor name
    public string name = "DefaultName";


    // skill
    public SkillVo skills = null;

    public Position position = new Position(Vector3.zero);
    public Position remotePosition = new Position(Vector3.zero);

    // mode
    public Mode mode = new Mode(Mode.Type.NORMAL);

    // actor type
    public ActorType actorType;

    // genre
    public Genre genre = null;

    // camp
    public Camp camp = null;

    // club
    public Club club = null;

    // team
    public Team team = null;

    // hp vessel
    public Vessel hp = new Vessel();

    // mp vessel
    public Vessel mp = new Vessel();

    // visible
    public bool visible;

    // auto attack
    public bool autoAttack = false;

    // attack period
    public float attackPeriod = 1F;

    // be selected or not
    public bool selected = false;

    // visible count
    public int visibleMonsterCount = 0;
    public int visibleHeroCount = 0;

    // highlight
    public bool highlight = false;

    // block queue
    public Queue<BattleBlock> blockQueue = new Queue<BattleBlock>();

    // hit queue
    public Queue<BattleHit> hitQueue = new Queue<BattleHit>();

    public ActorVo(long id)
    {
      this.Id = id;
    }

#region override from object

    public override int GetHashCode ()
    {
      return GetType().GetHashCode() ^ Id.GetHashCode();
    }

    public override bool Equals (object obj)
    {
      return this.GetType().Equals(obj.GetType()) && this.Id == (obj as ActorVo).Id;
    }

#endregion
  }
}

