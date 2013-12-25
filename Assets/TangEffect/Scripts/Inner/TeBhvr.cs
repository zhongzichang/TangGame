/**
 * Tang Effect Behaviour
 * Date: 2013/11/2
 * Author: zzc
 */

using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangEffect
{
  public class TeBhvr : MonoBehaviour
  {
    private IFacade facade;

    void Start()
    {

      DontDestroyOnLoad(gameObject);

      facade = Facade.Instance;
      RegisterCommands();
    }


    void Update()
    {
      if( Cache.notificationQueue.Count > 0 )
	{
	  int count = Cache.notificationQueue.Count;
	  for( int i=0; i<count; i++ )
	    Facade.Instance.NotifyObservers( Cache.notificationQueue.Dequeue() );
	}
    }

    void OnDestroy()
    {
      RemoveCommands();
    }

    private void RegisterCommands()
    {
      facade.RegisterCommand( ActionBindingCmd.NAME, typeof(ActionBindingCmd) );
      facade.RegisterCommand( StatusActionBindingCmd.NAME, typeof(StatusActionBindingCmd) );
      facade.RegisterCommand( DirectionalFlyCmd.NAME, typeof(DirectionalFlyCmd) );
      facade.RegisterCommand( DirectionalRunCmd.NAME, typeof(DirectionalRunCmd) );
      facade.RegisterCommand( FixPointCmd.NAME, typeof(FixPointCmd) );
      facade.RegisterCommand( TraceFlyCmd.NAME, typeof(TraceFlyCmd) );
      facade.RegisterCommand( TraceRunCmd.NAME, typeof(TraceRunCmd) );
      facade.RegisterCommand( BindingCmd.NAME, typeof(BindingCmd) );
      
    }

    private void RemoveCommands()
    {
      facade.RemoveCommand( ActionBindingCmd.NAME );
      facade.RemoveCommand( StatusActionBindingCmd.NAME );
      facade.RemoveCommand( DirectionalFlyCmd.NAME );
      facade.RemoveCommand( DirectionalRunCmd.NAME );
      facade.RemoveCommand( FixPointCmd.NAME );
      facade.RemoveCommand( TraceFlyCmd.NAME );
      facade.RemoveCommand( TraceRunCmd.NAME );
      facade.RemoveCommand( BindingCmd.NAME );

    }


  }
}