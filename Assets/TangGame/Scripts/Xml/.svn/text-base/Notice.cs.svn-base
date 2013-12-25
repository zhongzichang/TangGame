/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TangGame.Xml
{

  public class Notice
  {
    public string f_id;
    public string f_notice;
    public string f_goods_id;
  }

  [XmlRoot("root")]
  public class NoticeRoot
  {
    [XmlElement("value")]
    public List<Notice> items = new List<Notice>();
  }
}

