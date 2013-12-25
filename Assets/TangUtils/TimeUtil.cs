/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/20
 * Time: 14:37
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangUtils
{
/// <summary>
/// Description of TimeUtil.
/// </summary>
public class TimeUtil
{
    /// <summary>
    /// Methods to convert Unix time stamp to DateTime
    /// </summary>
    /// <param name="_UnixTimeStamp">Unix time stamp to convert</param>
    /// <returns>Return DateTime</returns>
    public static DateTime UnixTimestampToDateTime(long _UnixTimeStamp)
    {
        return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(_UnixTimeStamp);
    }

    /// <summary>
    /// Methods to convert DateTime to Unix time stamp
    /// </summary>
    /// <param name="_UnixTimeStamp">Unix time stamp to convert</param>
    /// <returns>Return Unix time stamp as long type</returns>
    public static long DateTimeToUnixTimestamp(DateTime _DateTime)
    {
        TimeSpan _UnixTimeSpan = (_DateTime - new DateTime(1970, 1, 1, 0, 0, 0));
        return (long)_UnixTimeSpan.TotalSeconds;
    }

}
}
