using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using TangUtils;

namespace TangGame.Xml
{
    public class Name
    {
        public string familyName;
        public string man;
        public string woman;
    }

    [XmlRoot("root")]
    [XmlLate("name")]
    public class NameRoot
    {
        [XmlElement("value")]
        public List<Name> items = new List<Name>();

        public static void LateProcess(object obj)
        {
            const char CHAR_NAME_SPLIT = '\n';
            NameRoot nameRoot = obj as NameRoot;
            if (nameRoot.items.Count > 0)
            {
                Name name = nameRoot.items[0];
                NameCache.familyName = name.familyName.Split(CHAR_NAME_SPLIT);
                NameCache.man = name.man.Split(CHAR_NAME_SPLIT);
                NameCache.woman = name.woman.Split(CHAR_NAME_SPLIT);
            }
        }
    }
}

