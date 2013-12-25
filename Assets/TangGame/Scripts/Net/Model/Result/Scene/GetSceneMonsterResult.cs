/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/25
 * Time: 12:07
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of GetSceneMonsterResult.
/// </summary>
  [Response(NAME)]
  public class GetSceneMonsterResult  : Response
  {
    public const string NAME = "getSceneMonster_RESULT";
    public Monster monster = null;
    /*
     * data.putData(role.getId());
    data.putData(role.getRoleMouldId()); int
    data.putData(role.getName()); string
    data.putData(role.getX()); short
    data.putData(role.getY()); short
    data.putData(role.getHp()); int
    data.putData(role.getMaxHP()); int
    data.putData(role.getLevel()); short
    data.putData(role.getResId()); short
    data.putData(role.getCamp() == 1 ? 0 : role.getCamp()); short
    if(role.getEndX() < 1 || role.getEndY() < 1){
      data.putData(role.getX());//结束位置 int
      data.putData(role.getY());//结束位置 int
    }else{
      data.putData(role.getEndX());//结束位置
      data.putData(role.getEndY());//结束位置
    }*/


    public GetSceneMonsterResult () : base(NAME)
    {
    }

    public static GetSceneMonsterResult Parse (MsgData data)
    {
      GetSceneMonsterResult result = new GetSceneMonsterResult ();
      Monster monster = Monster.Parse (data);
//        Role role = Role.ParseMonsterData(data);
//        role.id = (long)data.GetDouble(index++);
//        role.mould.id = data.GetInt(index++);
//        role.name = data.GetString(index++);
//        role.x = data.GetShort(index++);
//        role.y = data.GetShort(index++);
//        role.hp = data.GetInt(index++);
//        role.mould.hp = data.GetInt(index++);
//        role.level = data.GetShort(index++);
//        role.mould.resId = data.GetShort(index++);
//        role.camp = data.GetShort(index++);
//        if(data.Get(index) is int)
//        {
//            role.endX = data.GetInt(index++);
//            role.endY = data.GetInt(index++);
//        }
//        else
//        {
//            role.endX = data.GetShort(index++);
//            role.endY = data.GetShort(index++);
//        }
//        role.armsId = (long) data.GetDouble(index++);

      result.monster = monster;

      return result;


    }
  }
}
