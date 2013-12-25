/*
 * Created by emacs
 * Author: zzc
 * Date: 2013/5/31
 */
namespace TangGame.View
{
public class Vessel
{
    public bool Updated = false;
    public int max = 100;
    public int Max
    {
        get
        {
            return max;
        }
        set
        {
            this.max = value;
            this.Updated = true;
        }
    }
    public int val = 100;
    public int Val
    {
        get
        {
            return val;
        }
        set
        {
            this.val = value;
            this.Updated = true;
        }
    }
    private float scale = 1F;
    public float Scale
    {
        get
        {
            if(Max == 0)
                scale = 1F;
            else
                scale = (float) Val / (float) Max;

            return scale;

        }
    }

    public Vessel()
    {

    }

    public Vessel(int val, int max)
    {
        this.Val = val;
        this.Max = max;
        this.Updated = true;
    }
}
}