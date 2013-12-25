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

namespace TangGame.Xml
{
	/// <summary>
	/// Description of Role.
	/// </summary>
	public class Role
	{
		public int id;
		public string name;
		public int level;
		public string icon;
		//    public int is_attack;
		//    public int sort;
		//    public int type;
		//    public int camp;
		public int hpMax;
		public string Avatar;
		public int speed;
		//    public string attack;
		//    public int attack_addition;
		//    public int defence;
		//    public long exp;
		//    public int reduce_hurt;
		//    public int dritical;
		//    public int evade;
		//    public int patrol_area;
		//    public int vision_area;
		//    public int coin;
		//    public string script_name;
		//    public int ai_id;
		//    public int skill_id;
		//    public string talk;
		//    public int skill_point;
		//    public string dead_script;
		//    public int absolute_attack;
		public static Role FromData (TangGame.Xml.Monster monster)
		{
			Role role = new Role ();
			role.id = monster.Id;
			role.name = monster.Monster_name;
			role.level = monster.Level;
			role.Avatar = monster.Avatar;
			role.hpMax = monster.Hp_c;
			role.speed = monster.Move_speed * 25;
			return role;
		}
	}

	[XmlRoot("root")]
  public class RoleRoot
	{

		[XmlElement("value")]
		public List<Role> items = new List<Role> ();
	}
}
