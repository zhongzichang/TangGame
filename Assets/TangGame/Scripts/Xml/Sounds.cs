using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TangGame.Xml
{

  public class Sound
  {
    public string id;
    public string path;
  }

  [XmlRoot("sounds")]
  public class SoundsRoot
  {
    [XmlElement("item")]
    public List<Sound> items = new List<Sound>();
  }
}

