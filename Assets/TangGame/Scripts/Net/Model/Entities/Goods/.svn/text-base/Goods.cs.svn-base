using System;
using System.Collections.Generic;

namespace TangGame.Net
{

/** 玩家身上，背包等物品类，包含了完整的物品信息 */
public class Goods
{
    public int id;
    /** 道具名称 */
    public string name;
    /** 动作特效 */
    public string effect;
    /** 道具品质 */
    public short grade;

    /** 装备等级限制 */
    public short limitLeve;
    /** 装备性别限制 */
    public short limitSex;
    /** 装备流派限制(1.凌烟阁 2.信陵客 3.清净楼) */
    public short limitGenre;

    /** 是否是IB道具 */
    public bool isIB;
    /** 道具类型(1.武器类 2.防具类 3.装饰品类 4.材料类 5.杂物类 6.任务类 7.符文 8.骑宠 9.药品) */
    public short type;
    /** 具体类型 */
    public short miniType;
    /** 是否可以提升品质 */
    public short durable;
    /** 道具重量 */
    public short weight;
    /** 装备位置 */
    public short site;
    /** 绑定方式 */
    public short bindingType;
    /** 是否允许解除绑定 */
    public bool isRelieveBinding;
    /** 堆叠上限 */
    public short maxHeapLimit;
    /** true:可掉可卖 false:不掉不卖 */
    public bool isDrop;

    /** 货币类型(1.游戏币 2.元宝 3.代券) */
    public short coinType;
    /** 购买价格 */
    public int buyPrice;
    /** 出售价格 */
    public int sellPrice;
    /** IB道具特有折扣价 */
    public int discountPrice;

    /** 强化上限 */
    public short maxTopLimit;
    /** 孔数 */
    public short hole;
    /** 孔数上限 */
    public short maxHoleLimit;
    /** 装备效果 */
    public List<Effect> equipEffect;
    /** 使用效果 */
    public List<Effect> useEffect;

    /** 强化增强属性 */
    public short[] intensifyType;
    /** 强化到特定次数后可激活的属性(key:强化次数 value:属性效果) */
    public Dictionary<short, Effect> activate;
    /** 可随机数量 */
    public short randomCount;
    /** 随机可得到效果 */
    public List<Effect> randomEffect;
    /** 套装ID */
    public int suitId;
    /** 道具描述 */
    public string describe;
    /** 图片名 */
    public short imgNum;
    /** 升级后ID */
    public int nextId;
    /** 装备分数 */
    public int score;
    /** 有效时间(分钟) */
    public long duringMinute;
    /** 能否投放资源 */
    public bool isPut;
    /** 关联ID */
    public int relevanceId;
    /** 使用脚本 */
    public string useFunName;
    /** 是否允许批量使用 */
    public bool isBatch;

    public Suit suit;

}
}





