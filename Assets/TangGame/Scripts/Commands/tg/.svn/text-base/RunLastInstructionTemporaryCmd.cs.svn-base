/// <summary>
/// Run last instruction temporary cmd.
/// xbhuang create at 2013/10/30
/// </summary>
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangGame
{
	/// <summary>
	/// Run last instruction temporary cmd.
	/// </summary>
	public class RunLastInstructionTemporaryCmd : SimpleCommand
	{
		public static string NAME = NtftNames.TG_RUN_LAST_INSTRUCTION_TEMPORARY;

		public override void Execute (INotification notification)
		{
			//Send last notification in InstructionCache.instructionStack when InstructionCache's instructionStack Count than zero bigger
			
			while(InstructionCache.instructionQueue.Count > 0 ){
				notification = InstructionCache.instructionQueue.Dequeue() as INotification;
				if (notification != null) {
					SendNotification (notification.Name, notification.Body);
					InstructionCache.instructionQueue.Clear();
				}
			}
		}
	}
}