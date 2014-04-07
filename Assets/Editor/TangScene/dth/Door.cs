using System;
using System.Xml.Serialization;

namespace dth
{
  [Serializable,XmlRoot(ElementName = "obj")]
  public class Door
  {
    public int posx;
    public int posy;
    public int uid;
    public int toMapId;
    public int toX;
    public int toY;
    public string name;
  }
}