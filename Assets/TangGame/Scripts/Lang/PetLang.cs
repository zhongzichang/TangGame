using UnityEngine;
using System.Collections;
using System.Xml;

/// 文字
public class PetLang
{
    /// 坐骑
    public const string MOUNT = "坐骑";
    /// 名将
    public const string GENERAL = "名将";


    /// 属性
    public const string PROPERTY = "属性";
    /// 品质
    public const string PINZHI = "品质";
    /// 混元
    public const string HUNYUAN = "混元";

    /// 提升品质阶段
    public const string UPGRADE_JIEDUAN = "提升品质阶段";
    /// 提升品质
    public const string UPGRADE_PINZHI = "提升品质";
    /// 混元强化
    public const string HUNYUAN_STRENGTHEN = "混元强化";

    /// 开始混元
    public const string HUNYUAN_START = "开始混元";

    /// 坐骑变种
    public const string VARIANT = "坐骑变种";

    /// 属性未激活
    public const string NOT_ACTIVATED = "属性未激活";
    /// 坐骑品质对应的名称
    public static readonly string[] MOUNT_GRADE_NAME = {"", "杂种坐骑", "驯化坐骑", "强健坐骑", "军用坐骑", "战场坐骑", "将军坐骑"};

    /// 缺少提示段位物品！
    public const string ERROR_1 = "缺少提示段位物品！";
    /// 坐骑品质阶段已提升到顶级，请提升坐骑品质！
    public const string ERROR_2 = "坐骑品质阶段已提升到顶级，请提升坐骑品质！";
    /// 缺少提示品质物品！
    public const string ERROR_3 = "缺少提示品质物品！";
    /// 坐骑品质已提升到顶阶！
    public const string ERROR_4 = "坐骑品质已提升到顶阶！";
    /// 坐骑段位未到10段！
    public const string ERROR_5 = "坐骑段位未到10段！";
    /// 缺少坐骑混元物品！
    public const string ERROR_6 = "缺少坐骑混元物品！";
    /// 坐骑无法属性混元！
    public const string ERROR_7 = "坐骑无法属性混元！";



}
