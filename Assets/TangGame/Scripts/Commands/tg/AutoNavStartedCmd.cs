/**
 * 自动寻路已开始
 *
 * Date: 2013/11/23
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

namespace TangGame
{
  public class AutoNavStartedCmd : SimpleCommand
  {
    
    public override void Execute( INotification notification )
    {
      // 显示自动寻路中
      Debug.Log("Auto navigation started");
    }

  }
}