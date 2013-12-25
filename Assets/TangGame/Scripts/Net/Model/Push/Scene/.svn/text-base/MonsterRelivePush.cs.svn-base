using TangNet;

namespace TangGame.Net
{
	[Response(NAME)]
	public class MonsterRelivePush : Response
	{

		public const string NAME = "monsterRelive_PUSH";
//		public Role role = null;
		public Monster monster = null;

		public MonsterRelivePush () : base(NAME)
		{

		}

		public static MonsterRelivePush Parse (MsgData data)
		{
			MonsterRelivePush push = new MonsterRelivePush ();

//			push.role = Role.ParseMonsterData (data);
			push.monster = Monster.Parse(data);
			return push;
		}


	}
}