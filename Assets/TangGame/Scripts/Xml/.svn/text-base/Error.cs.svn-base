using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TangGame.Xml
{
  public class Error
  {
    public int state;
    public string asc;
  }

  [XmlRoot("ROOT")]
  public class ErrorRoot
  {
    [XmlElement("T")]
    public List<Error> items = new List<Error>();
  }
}

