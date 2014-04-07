using System;
using System.Xml.Serialization;
namespace dth
{
  [Serializable, XmlRoot("map")]
  public class Map
  {
    
    public Meta meta;

    public int id;
    public string name;
    public int mapW;
    public int mapH;
    public int tileX = 128;
    public int tileY = 128;
    public string resName;
    
    [XmlArrayItem("obj")]
    public Npc[] npc;

    [XmlArrayItem("obj")]
    public Monster[] monster;

    [XmlArrayItem("obj")]
    public Door[] door;

    [XmlArrayItem("y")]
    public string[] road;

  }
}