/**
 * TangScene Effect
 * Date: 2013/11/5
 * Author: zzc
 */
using System;
using System.Xml.Serialization;

namespace TangEffect
{
  [Serializable]
  public class TsEffect
  {

    public int id;
    public string name;
    public int assetSetId;
    public int assetId;
    
    
    [XmlArray]
    [XmlArrayItem(typeof(string), ElementName="c")]
    public string[] scripts;

  }
}