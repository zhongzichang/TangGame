/*
 * Created by SharpDevelop.
 * User: huxiaobo
 * Date: 2013/12.6
 * Time: 17:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
using UnityEngine;

namespace TangGame.Net
{
	/// <summary>
	/// 技能学习回复
	/// </summary>
	[Response(NAME)]
	public class SkillStudyResult : Response
	{
		public const string NAME = "skillStudy_RESULT";
		public short statusCode;
		public SkillStudyResult() : base(NAME)
		{
		}
		public static SkillStudyResult Parse(short statusCode, MsgData data)
		{
			SkillStudyResult result = new SkillStudyResult();
			result.statusCode = statusCode;
			return result;
		}
	}
}
