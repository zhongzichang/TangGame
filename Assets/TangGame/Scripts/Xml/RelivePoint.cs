/*
 * Created by Emacs
 * Author: zzc
 * Date: 2013/6/9
 */

using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace TangGame.Xml
{
  public class RelivePoint
  {
    // map_id, camp, x, y
    public int map_id;
    public int camp;
    public int x;
    public int y;
  }

  [XmlRoot("root")]
  public class RelivePointRoot
  {
    [XmlElement("value")]
    public List<RelivePoint> items = new List<RelivePoint>();
  }
}