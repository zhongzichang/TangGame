using System;

namespace dth
{
  [Serializable]
  public class Npc
  {
 
    public int posx;
    public int posy;
    public long uid;
    public int resId;
    public string resName;
    public int direction = 0;
    public int currentFrame = 1;
    public bool nameState = true;
  }
}