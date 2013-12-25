using System;
using TangNet;

namespace TangGame.Net
{
	/// <summary>
	/// 更新当前选中的人物的头像信息
	/// </summary>
	[Response(NAME)]
	public class UpdateTargetInfoPush : Response
	{
		
		public const string NAME = "otherinfo_PUSH";
		public long objId;
		public int curHp;			
		public int maxHp;
		public int level;
		public UpdateTargetInfoPush() : base(NAME)
		{
		}
		public static UpdateTargetInfoPush Parse(MsgData data)
		{
			UpdateTargetInfoPush push = new UpdateTargetInfoPush();
			
			int index = 0;
			push.objId = data.GetLong(index++);
			push.curHp = data.GetInt(index++);
			push.maxHp = data.GetInt(index++);
			push.level = data.GetInt(index++);
			return push;
			
		}
	}
}
