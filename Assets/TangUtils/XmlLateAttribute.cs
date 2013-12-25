/**
 * Created by emacs
 * Date: 2013/10/21
 * Author: zzc
 */

namespace TangUtils
{
    [ System.AttributeUsage(System.AttributeTargets.Class)]
    public class XmlLateAttribute : System.Attribute
    {
        private string name;

        public XmlLateAttribute(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}