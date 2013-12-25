/**
 * Generic Xml Parser
 * Date: 2013/10/21
 * Author: zzc
 */
using System.IO;

namespace TangUtils
{
  public class XmlParser
  {
    public static T Parse<T>(byte[] bytes)
    {
      TextReader reader = new StringReader(TextUtil.GetTextWithoutBOM(bytes));
      return XmlRootHelper.LoadXml<T>(reader);
    }

    public static T Parse<T>(string text)
    {
      TextReader reader = new StringReader(text);
      return XmlRootHelper.LoadXml<T>(reader);
      
    }
  }
}
