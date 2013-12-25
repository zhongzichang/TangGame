using System;
using UnityEngine;
using TangGame.Net;
using TangUtils;
using TangScene;

namespace TangGame.View
{
  public class HeroVoNew : ActorVo
  {

    public const int SKILL_COUNT = 6;

    public Part[] parts = null;

    /// <summary>
    /// remote data
    /// </summary>
    public HeroNew data = null;

    private HeroVoNew (long id) : base(id)
    {
      parts = Part.NewParts();

      this.actorType = ActorType.hero;
    }
    public static HeroVoNew NewKZHero(long id)
    {
      HeroVoNew hero = new HeroVoNew(id);
      return hero;
    }

    public static HeroVoNew FromData(HeroNew hero)
    {

      HeroVoNew heroVo = null;
      string genre = null;
      string gender = GlobalLang.MALE;

      heroVo = HeroVoNew.NewKZHero(hero.id);
      if(heroVo == null)
	return null;

      genre = GenreType.GetGenreString(hero.genre);

      heroVo.name = hero.name;

      if(hero.sex == HeroNew.SEX_FEMALE)
	gender = GlobalLang.FEMALE;

      // TODO 需要添加技能
      // heroVo.skills = SkillVo.FormData(hero.skills);
      /*
      TangGame.Xml.HeroInitialize heroInitialize = Config.heroInitializeTable[hero.genre.ToString()]as TangGame.Xml.HeroInitialize;
      if( heroVo.skills != null && heroVo.skills.skillBases.Count > 0 )
	{
	  heroVo.skills.skillBase=heroVo.skills.skillBases[heroInitialize.Default_skill] as SkillBaseVoNew;
	  heroVo.skills.defaultSkillId=heroInitialize.Default_skill;
	  //heroVo.CurrentSkill=heroVo.skills.skillBase;
	}
	*/
      heroVo.genre = new Genre(Genre.Name.KZ);

      // position

      heroVo.position.GamePoint = new Point((int)hero.x, (int)hero.y);
      heroVo.remotePosition.GamePoint = new Point((int)hero.x, (int)hero.y);

      // hp
      heroVo.hp.Val = hero.hp;
      heroVo.hp.Max = hero.hpMax;
      // mp
      heroVo.mp.Val = hero.mp;
      heroVo.mp.Max = hero.mpMax;

      // save data
      heroVo.data = hero;

      return heroVo;
    }

  }
}

