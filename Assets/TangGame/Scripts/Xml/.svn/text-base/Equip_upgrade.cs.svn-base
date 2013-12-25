// yc : 2013/11/20
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using TangUtils;
using UnityEngine;

namespace TangGame.Xml
{
  public class Equip_upgrade
  {
    public int Id;								//装备ID
    public int Next_id;							//装备升级后的装备ID
	public int Exp;								//宝石升级所需经验
	public string Upgradenum;					//升级需求物品 minitype,num;mintype,num
	public int Money;							//升级需求铜币		
	public int Upexp;							//宝石升级一次获得的经验
	public string Minitype_id;					//minitype对应的 itemID,minitype:itemId,itemId;minitype:itemId,itemId
	public string Gold;							//道具对应的金锭价格 itemId,num;itemId,num
	public string Silver;						//道具所需的银锭价格 itemId,num;itemId,num
	public int Total_gold;						//升级到当前id的物品所需的金锭数
  }

  [XmlRoot("ROOT")]
  [XmlLate("Up_goods")]
  public class Equip_upgradeRoot
  {
    [XmlElement("T")]
    public List<Equip_upgrade> items = new List<Equip_upgrade> ();

	public static void LateProcess (object obj)
	{
	
	  Equip_upgradeRoot root = obj as Equip_upgradeRoot;
	  foreach (Equip_upgrade item in root.items) {
	  	Config.equip_upgrade.Add (item.Id, item);
	  }
	
	}
  }
}