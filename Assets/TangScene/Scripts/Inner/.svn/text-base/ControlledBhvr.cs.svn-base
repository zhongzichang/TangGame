using UnityEngine;
using PureMVC.Patterns;
//using PureMVC.Interfaces;

namespace TangScene
{

  [RequireComponent(typeof(Navigable))]
  [RequireComponent(typeof(ActorBhvr))]
  [RequireComponent(typeof(Selectable))]
  public class ControlledBhvr : MonoBehaviour
  {
    private Navigable navigable;
    private ActorBhvr actorBhvr;
    private Selectable selectable;

    #region mono

    void Awake()
    {

      actorBhvr = GetComponent<ActorBhvr>();
      navigable = GetComponent<Navigable>();
      selectable = GetComponent<Selectable>();
      
    }

    void OnEnable()
    {

      // Cache.controlledActorId
      Cache.controlledActorId = actorBhvr.id;
      
      // set main camera scrolling target
      if( Camera.main != null )
      {
        CameraScrolling scrolling = Camera.main.GetComponent<CameraScrolling>();
        if( scrolling != null ) {
          scrolling.target = transform;
          scrolling.Reset();
        }
      }

      navigable.nextPositionChangeHandle = OnNextPositionChange;

      selectable.enabled = false;
      
    }

    void OnDisable()
    {
      if( navigable.nextPositionChangeHandle == OnNextPositionChange )
        navigable.nextPositionChangeHandle = null;

      selectable.enabled = true;

    }

    void OnNextPositionChange(Vector3 nextPosition)
    {
      Facade.Instance.SendNotification(NtftNames.LEADING_ACTOR_MOVE, nextPosition);
    }

    #endregion

  }
}