//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.Net;
using System.Collections.Generic;
using UnityEngine;
namespace  TangGame
{
	/// <summary>
	/// 更新技能相关command
	/// create by huxiaobo
	/// 2013.12.6
	/// </summary>
	public class SkillStudyCmd : SimpleCommand
	{
		public static string NAME = TangGame.Net.SkillStudyResult.NAME;
		public override void Execute (INotification notification)
		{
			SkillStudyResult result = notification.Body as SkillStudyResult;
			switch (result.statusCode)
			{
				case HandlerState.NORMAL:
				GlobalFunction.ShowInfoAtCenter(SkillLang.STUDY_SKLL_SUCCESS);
					break;
			case HandlerState.CONFIG_ERROR:
				GlobalFunction.ShowInfoAtCenter(SkillLang.CONFIG_ERROR);
				break;
			case HandlerState.SKILL_CONDITION_NOT_SATISFIED:
				GlobalFunction.ShowInfoAtCenter(SkillLang.STUDY_ERROR_6);
				break;
			}
		}
	}
}

