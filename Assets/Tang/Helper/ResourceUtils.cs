/**
 * Created by emacs
 * 
 * Date: 2013/9/26
 * Author: zzc
 */

namespace Tang
{
  public class ResourceUtils
  {

    public static string GetAbFilePath(string name)
    {
      return Config.AbDir + name + Config.AB_EXT_NAME;
    }

    public static string GetXmlFilePath(string name)
    {
      return Config.XmlDir + name + Config.XML_EXT_NAME;
    }
    
  }
}