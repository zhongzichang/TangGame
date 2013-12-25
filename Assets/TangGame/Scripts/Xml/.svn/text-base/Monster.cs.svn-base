/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/15
 * Time: 16:24
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using TangUtils;
using UnityEngine;

namespace TangGame.Xml
{
    /// <summary>
    /// Monster.
    /// </summary>
    public class Monster
    {
        public int Id;
        public string Monster_name;
        public int Monster_type;
        public string Avatar;
        public int Level;
        public int Hp_c;
        public int Mp_c;
        public int Move_speed;
    }

    [XmlRoot("root")]
    [XmlLate("monster")]
    public class MonsterRoot
    {
        [XmlElement("value")]
        public List<Monster> items = new List<Monster>();

        public static void LateProcess(object obj)
        {
			
            MonsterRoot root = obj as MonsterRoot;
            foreach (Monster item in root.items)
            {
                Config.monsterTable[item.Id] = item;
            }

        }
    }
}
