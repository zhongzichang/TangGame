using UnityEngine;
using System.Collections;
using TangNet;

namespace TangGame.Net
{
	public class Monster : ActorNo
	{
		public int configurationId;
		public int hp;
		public short endX;
		public short endY;
		public static Monster Parse (MsgData data)
		{

			Monster monster = new Monster ();
			int index = 0;
			monster.id = data.GetLong (index++);
			monster.configurationId = data.GetInt (index++);
			monster.x = data.GetShort (index++);
			monster.y = data.GetShort (index++);
			monster.hp = data.GetInt (index++);
			monster.level = data.GetInt (index++);
			monster.endX = data.GetShort (index++);
			monster.endY = data.GetShort (index++);
			monster.name = data.GetString (index++);
			monster.resourcesId = data.GetString(index++);
			monster.hpMax = data.GetInt(index++);
			monster.speed = data.GetShort(index++);
			return monster;
		}
	}
}