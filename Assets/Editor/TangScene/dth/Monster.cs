using System;

namespace dth
{
    [Serializable]
    public class Monster
    {
        public int posx;
        public int posy;
        public long monsterId;
        public int resId;
        public string resName;
        public int currentFrame = 1;
        public int teamId = 0;
        public int teamAI = 0;
    }
}