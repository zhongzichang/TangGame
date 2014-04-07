using System.Xml.Serialization;

namespace dth
{
  public class Road
  {
    [XmlElement(typeof(string), ElementName="y")]
    public string[] rows;
  }
}