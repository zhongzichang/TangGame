using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TangGame.Xml
{
  public class EnhanceOdds
  {
    public int f_id;
    public int f_level;
    public int f_odd;
    public int f_add_num;
    public int f_type;
    public int f_coin;
    public int f_xuanjing_show_odds;
    public int f_xuanjing_num;
  }

  [XmlRoot("root")]
  public class EnhanceOddsRoot
  {
    [XmlElement("value")]
    public List<EnhanceOdds> items = new List<EnhanceOdds>();
  }
}

