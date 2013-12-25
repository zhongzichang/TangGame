/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/20
 * Time: 15:15
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Security.Cryptography;
using System.Text;

namespace dthbs
{
/// <summary>
/// Description of SecurityUtil.
/// </summary>
public class SecurityUtil
{
    public static string StringToMD5Hash(string str)
    {
        MD5 m = new MD5CryptoServiceProvider();
        byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
        return BitConverter.ToString(s);
    }

}
}
