using UnityEngine;
using System.Collections;

namespace TangGame.View
{
public class AlertResult
{

    /// 确认类型
    public const int CONFIRM = 1;
    /// 取消类型
    public const int CANCEL = 2;
    /// 关闭类型
    public const int CLOSE = 4;

    private int mType;
    private string mInput;
    private object mParam;

    public AlertResult(int type, string input, object param)
    {
        this.mType = type;
        this.mInput = input;
        this.mParam = param;
    }

    public AlertResult(int type, string input)
    {
        this.mType = type;
        this.mInput = input;
    }

    public AlertResult(int type)
    {
        this.mType = type;
    }

    public int type
    {
        get
        {
            return this.mType;
        }
    }

    public string input
    {
        get
        {
            return this.mInput;
        }
    }

    public object param
    {
        get
        {
            return this.mParam;
        }
    }

}
}