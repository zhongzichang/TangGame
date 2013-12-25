/*
 * Created by emacs
 * Date: 2013/9/12
 * Author: zzc
 */

using System;
using System.Xml.Serialization;

namespace Tang
{
  [Serializable]
  public class TsLayer
  {
    
    public const string DEFAULT_NAME = "layer";

    public string name = DEFAULT_NAME;
    public int frameDelay = 0;
    public bool hiddenBeforeBegin = true;
    public bool hiddenAfterEnd = true;
    public TsSprite sprite = null;
  }
}