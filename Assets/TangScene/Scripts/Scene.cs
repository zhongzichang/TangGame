using System;
using System.Xml.Serialization;

namespace TangScene
{

  [Serializable, XmlRoot("scene")]
  public class Scene
  {
    [XmlElement("meta")]
    public Meta meta;

    public int id;
    public string name;
    public SceneType type;

    public int width;
    public int height;
    
    [XmlArray]
    [XmlArrayItem(typeof(Actor), ElementName="actor"),
     XmlArrayItem(typeof(Stage), ElementName="stage"),
     XmlArrayItem(typeof(Portal), ElementName="portal"),
     XmlArrayItem(typeof(Scenery), ElementName="scenery"),
     XmlArrayItem(typeof(TsCamera), ElementName="camera")]
    public TsObject[] objs;
		
  }
}

