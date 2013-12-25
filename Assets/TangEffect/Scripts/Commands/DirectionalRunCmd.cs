/**
 * Directional run command
 * Date: 2013/11/7
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangEffect
{
  public class DirectionalRunCmd : SimpleCommand
  {
    public const string NAME = "TE_INNER_DIRECTIONAL_RUN";

    public override void Execute(INotification notification)
    {
      DirectionalRunBean bean = notification.Body as DirectionalRunBean;

      if( bean != null )
	{
	  
	}
    }

  }
}