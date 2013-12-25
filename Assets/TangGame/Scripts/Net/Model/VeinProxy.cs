using System;
using TangNet;

namespace TangGame.Net
{
public class VeinProxy
{
    public const int TYPE = 0x1900;
    /// 经脉升级
    public const int S_VEIN_UPGRADE = TYPE + 0x0001;
    /// 穴位升级
    public const int S_ACUPOINT_UPGRADE = TYPE + 0x0002;
    /// 查看经脉和穴位
    public const int S_SHOW_VEIN = TYPE + 0x0003;

}
}
