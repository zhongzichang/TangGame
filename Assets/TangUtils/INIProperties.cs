
using System;
using System.Collections;
using System.IO;

namespace TangUtils
{


public class INIProperties
{

    public static Hashtable FromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        return FromStringArray(lines);
    }

    public static Hashtable FromString(string content)
    {
        return FromStringArray(content.Split('\n'));
    }

    public static Hashtable FromStringArray(string[] lines)
    {

        Hashtable data = new Hashtable();
        foreach (string row in lines)
        {
            int seperateIndex = row.IndexOf('=');
            string key = row.Substring(0,seperateIndex);
            string val = row.Substring(seperateIndex+1);
            if(TextUtil.IsNumeric(val))
            {
                data.Add(key, int.Parse(val));
            }
            else
            {
                data.Add(key, val);
            }
        }
        return data;
    }


}
}
