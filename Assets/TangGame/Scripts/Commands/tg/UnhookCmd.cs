/**
 * unhook cmd
 *
 * Date: 2013/11/24
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

namespace TangGame
{
  public class UnhookCmd : SimpleCommand
  {

    public const string NAME = NtftNames.TG_UNHOOK;

    public override void Execute(INotification notification)
    {
      BattleHelper.Unhook();
    }
  }
}