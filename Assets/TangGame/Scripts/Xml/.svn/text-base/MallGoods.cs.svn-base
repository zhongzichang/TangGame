using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TangGame.Xml
{
  public class MallGoods
  {

    public int id;

    public string type;

    public string sell_type;

    public int bindIngot;

    public int bindIngot_sale;

    public int coin;

    public int coin_sale;

    public int goods_type;

    public int miniType;

    public int honor_sale;

    public int popularity_sale;
  }

  [XmlRoot("root")]
  public class MallGoodsRoot
  {
    [XmlElement("value")]
    public List<MallGoods> items = new List<MallGoods>();
  }
}

