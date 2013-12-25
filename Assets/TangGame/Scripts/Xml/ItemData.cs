using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using TangUtils;
using TGV = TangGame.View;

namespace TangGame.Xml
{
    public class ItemData
    {
		public int Id;				//道具
		public string Name;			//道具名称
		public string Note;			//道具描述
		public int BindState;		//是否绑定
		public int Icon;			//大图标
		public int Quality;			//道具品质
		public int Shine;			//颜色发光
		public int Type;			//道具类型
		public int Minitype;		//道具小类型
		public int Maxcount;		//最大堆叠数量
		public int Effectivetime;	//有效时间
		public int Issell;			//是否可以出售
		public int Prince;			//出售价格
		public int Batchuse;		//是否可以批量使用
		public int NeedItem;		//使用需求辅助道具
		public int Discard;			//是否可以丢弃
		public int Interval;
		public string Useofresults;
		public int BuffId;			//使用效果
		public int Isprompt;		//怪物掉落是否提示
		public int ProfessionRule;  //职业限制
		public int NeedLv;			//等级限制
		public int EquipSite;		//装备位置
		public string Equipproperty;	//装备效果
		public int IntensifyLv;		//强化上限
		public int Activateproperty;//强化激活属性
		public int Gemproperty;		//装备自带宝石属性
		public int Kill;
		public int Ui_id;	
		
    }
  [XmlRoot("root")]
  [XmlLate("goods")]
  public class ItemRoot
  {
    [XmlElement("T")]
    public List<ItemData> items = new List<ItemData>();
    public static void LateProcess(object obj)
    {
        ItemRoot root = obj as ItemRoot; 		
        foreach (ItemData item in root.items)
        {
        	Config.itemTable.Add(item.Id, item);
        }
     }
  }
}