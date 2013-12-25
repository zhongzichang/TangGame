/*
 * Created by emacs
 * Date: 2013/9/12
 * Autor: zzc
 */

using System;
using System.Xml.Serialization;

namespace Tang
{
  [Serializable]
  public class TsAnimation
  {
    public const string DEFAULT_NAME = "animation";

    [XmlArrayItem("layer")]
    public TsLayer[] layers;
    public int loop = -1;
    public int fps = Config.fps;
    public bool playOnStart = true;
    public string name = DEFAULT_NAME;
  }
}