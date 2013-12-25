using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangScene
{
  public class SceneFacadeBhvr : MonoBehaviour
  {
    private IFacade facade;

    void Start()
    {
      facade = Facade.Instance;
      RegisterCommands();      
    }

    void Update()
    {
      if( Cache.notificationQueue.Count > 0 )
	{
	  int count = Cache.notificationQueue.Count;
	  for( int i=0; i<count; i++ )
	    {
	      Facade.Instance.NotifyObservers( Cache.notificationQueue.Dequeue() );
	    }
	}
    }


    void OnDestroy()
    {
      RemoveCommands();
    }

    private void RegisterCommands()
    {
      facade.RegisterCommand( ActorEnterCmd.NAME, typeof(ActorEnterCmd) );
      facade.RegisterCommand( ActorExitCmd.NAME, typeof(ActorExitCmd) );
      facade.RegisterCommand( ActorNavigateCmd.NAME, typeof(ActorNavigateCmd) );
      facade.RegisterCommand( ActorAttackCmd.NAME, typeof(ActorAttackCmd) );
      facade.RegisterCommand( ActorAttackResultCmd.NAME, typeof(ActorAttackResultCmd) );
      facade.RegisterCommand( SwitchControlledActorCmd.NAME, typeof(SwitchControlledActorCmd));
      facade.RegisterCommand( SwitchSelectedActorCmd.NAME, typeof(SwitchSelectedActorCmd));
      facade.RegisterCommand( UnselectActorCmd.NAME, typeof(UnselectActorCmd));
      facade.RegisterCommand( ChangeActorSpeedCmd.NAME, typeof(ChangeActorSpeedCmd));
      facade.RegisterCommand( ActorMoveCmd.NAME, typeof(ActorMoveCmd));
      facade.RegisterCommand( ActorTraceCmd.NAME, typeof(ActorTraceCmd));
      facade.RegisterCommand( CancelTraceCmd.NAME, typeof(CancelTraceCmd));
      facade.RegisterCommand( ActorReTraceCmd.NAME, typeof(ActorReTraceCmd));
      facade.RegisterCommand( UncontrollActorCmd.NAME, typeof(UncontrollActorCmd));
      facade.RegisterCommand( ActorShiftCmd.NAME, typeof(ActorShiftCmd) );
      facade.RegisterCommand( SprintCmd.NAME, typeof(SprintCmd) );
      facade.RegisterCommand( SprintWithPosCmd.NAME, typeof(SprintWithPosCmd) );
      facade.RegisterCommand( StagnantCmd.NAME, typeof(StagnantCmd) );
      facade.RegisterCommand( ActorDieCmd.NAME, typeof(ActorDieCmd) );
      facade.RegisterCommand( ActorReliveCmd.NAME, typeof(ActorReliveCmd) );
      

    }
    
    private void RemoveCommands()
    {
      facade.RemoveCommand( ActorEnterCmd.NAME );
      facade.RemoveCommand( ActorExitCmd.NAME );
      facade.RemoveCommand( ActorNavigateCmd.NAME );
      facade.RemoveCommand( ActorAttackCmd.NAME );
      facade.RemoveCommand( ActorAttackResultCmd.NAME );
      facade.RemoveCommand( SwitchControlledActorCmd.NAME );
      facade.RemoveCommand( SwitchSelectedActorCmd.NAME );
      facade.RemoveCommand( UnselectActorCmd.NAME );
      facade.RemoveCommand( ChangeActorSpeedCmd.NAME );
      facade.RemoveCommand( ActorMoveCmd.NAME );
      facade.RemoveCommand( ActorTraceCmd.NAME );
      facade.RemoveCommand( ActorReTraceCmd.NAME );
      facade.RemoveCommand( CancelTraceCmd.NAME );
      facade.RemoveCommand( UncontrollActorCmd.NAME );
      facade.RemoveCommand( ActorShiftCmd.NAME );
      facade.RemoveCommand( SprintCmd.NAME );
      facade.RemoveCommand( SprintWithPosCmd.NAME );
      facade.RemoveCommand( ActorDieCmd.NAME );
      facade.RemoveCommand( ActorReliveCmd.NAME );
      facade.RemoveCommand( StagnantCmd.NAME );
    }

  }
}