using UnityEngine;
using System.Collections;

namespace TangGame
{
  public class InputEventBean
  {
    public string eventName;
    public Rect eventParam;
    
    public InputEventBean (string key, Rect area)
    {
      this.eventName = key;
      this.eventParam = area;
    }
  }
}
