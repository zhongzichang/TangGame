
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TangUtils
{

public class TextUtil
{

    /// 判断字符串是否为数字
    public static bool IsNumeric(string stringToTest)
    {
        int result;
        return int.TryParse(stringToTest, out result);
    }

    /// 处理颜色文本字符串
    public static string PackColorText(string color, string text)
    {
        return "["+ color +"]" + text + "[-]";
    }

    /// 替换文本
    public static string Replace(string text, string data)
    {
        return string.Format(text, data);
    }

    /// 替换文本
    public static string Replace(string text, string[] data)
    {
        string result = text;
        for(int i = 0; i < data.Length; i++)
        {
            result = result.Replace("{" + i + "}", data[i]);
        }
        return result;
    }

    /**
     * 中文验证，验证输入的字符串在UTF-8区间(\u4e00-\u9fa5，a-z，A-Z，0-9)
     * @param input 传入的字符串
     * @param min 验证的最小长度，默认为0
     * @param max 验证的最大长度，默认为16
     * @return 合法返回true，否则返回false
     */
    public static bool ZhValidator(string input, int min, int max)
    {
        Regex rg = new Regex("^[\u4e00-\u9fa5a-zA-Z0-9]{" + min + "," + max + "}$", RegexOptions.Multiline | RegexOptions.Singleline);
        return rg.IsMatch(input);
    }

    /**
     * 验证输入的数字，是否合法的数字串，该字符串的开头必须是1-9
     * @param input 传入的字符串
     * @return 合法返回true，否则返回false
     */
    public static bool NumberValidator(string input)
    {
        Regex rg = new Regex("^[1-9][0-9]{0," + (input.Length - 1) + "}$", RegexOptions.Multiline | RegexOptions.Singleline);
        return rg.IsMatch(input);
    }

    /**
     * 是否存在关键字
     * @param input:String 传入的字符串
     * @return 存在返回true，否则false
     * */
    public static bool IsKeyWords(string input)
    {
        return false;
    }


    /**
     * 关键字替换
     * @param input:String 传入的字符串
     * @return 被替换后的字符串，一个关键词被替换成“**”
     * */
    public static string KeyWordsReplace(string input)
    {
        string result = input;
//			if(CommonAssets.keyWords)
//			{
//				for each(var str:String in CommonAssets.keyWords)
//				{
//					var re:RegExp = new RegExp(str, "g");
//					result = result.replace(re, "**");
//				}
//			}
        return result;
    }

    /**
     * Returns safe text from TextAsset.
     *
     * Text files can contain byte order mark (BOM) to specify encoding details.
     * Generally, BOM is consumed when loading text from a file (for example with TextReader or XmlReader).
     * TextAsset provides "text" field that contains "raw" file text where BOM is preserved.
     * This can cause errors.
     * For example, when trying to read xml with XmlReader.
     *     (XmlException: Text node cannot appear in this state.  Line 1, position 1.
     *      Mono.Xml2.XmlTextReader.ReadText (Boolean notWhitespace)... )
     *
     * */
    public static string GetTextWithoutBOM(byte[] bytes)
    {
        MemoryStream memoryStream = new MemoryStream(bytes);
        StreamReader streamReader = new StreamReader(memoryStream, true);

        string result = streamReader.ReadToEnd();

        streamReader.Close();
        memoryStream.Close();

        return result;
    }

}
}
