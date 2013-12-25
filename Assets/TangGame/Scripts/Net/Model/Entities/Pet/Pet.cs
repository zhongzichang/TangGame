/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/7
 * Time: 15:40
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// Description of Pet.
/// </summary>
public class Pet : PlayerABS
{

    /** 寄主 */
    public HeroNew hero;
    /** 宠物基础ID */
    public int petMouldId;
    /** 品质 */
    public short quality;
    /** 星级 */
    public short starLevel;

    /** 力量 */
    public short strength;
    /** 体力 */
    public short stamina;
    /** 敏捷 */
    public short agility;
    /** 悟性 */
    public short savvy;
    /** 附加强化属性(0:力量 1:体质 2:敏捷 3:悟性) */
    public short[] addAttributeValue = new short[4];

    /** 成长值 */
    public short growValue;
    /** 经验值 */
    public long exp;
    /** 技能 */
    public PetSkill[] skillArray;
    /** 装备物品 */
    public HeroGoods[] petGoods;
    /** 是否使用 */
    public bool isUse;

    /** 宠物实力 */
    public long strengthValue;
    /** 宠物升级经验 */
    public int upExp;
    /** 宠物模型 */
    public short mould;
    /** 动态属性 */
    public PetTrendsAttribute trendsAttribute = new PetTrendsAttribute();
    /** buff列表 */
    public List<Buff> buffList;
    /** 所在网格 */
    public NGrid grid;
    /** 最后一次战斗时间 */
    public long lastBattleTime;
    /** 移动停止时间 */
    public long stopMoveTime;
    /** 攻击对象 */
    public RoleMethod attackObj;
    /** 下次战斗使用技能 */
    public PetSkill nextUseSkill;
    /** 宠物基础攻击技能 */
    public PetSkill baseSkill;
    /** 附加速度 */
    public short speed;


}
}
