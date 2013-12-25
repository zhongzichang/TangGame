using UnityEngine;
using System.Collections;

namespace TangGame.View
{
public class AlertVo
{

    /// 显示的文本信息
    public string text = "";
    /// 显示的弹出类型
    public int type;
    /// 显示的标题
    public string title = "";
    /// 信息是否覆盖
    public bool isMsgCover = true;
    /// 输入值，或者默认的传递的值
    public string input = "";
    /// 参数对象
    public object param;


}
}