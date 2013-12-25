/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TangUtils
{

public class DateUtil
{

    /// 获取字符串形式的时间M-D H:M
    public static string GetTime(long time)
    {
        string result = "";
        DateTime date = new DateTime(1970, 1, 1, 8, 0, 0);
        date = date.AddMilliseconds(time);
        result = date.Month + "-" + date.Day + " " + date.Hour + ":" + date.Minute;
        return result;
    }

    /// 获取字符串形式的时间Y-M-D H:M
    public static string GetYMDTime(long time)
    {
        string result = "";
        DateTime date = new DateTime(1970, 1, 1, 8, 0, 0);
        date = date.AddMilliseconds(time);
        result = date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour + ":" + date.Minute;
        return result;
    }
}
}
