using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TS = TangScene;

namespace TangGame
{
  public class GameInputMediator : Mediator
  {
    private delegate void Handle (INotification notification);

    private Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
    private List<string> interests = new List<string> ();

    public GameInputMediator () : base(NAME)
    {
      handleTable.Add (NotificationIDs.ID_DisableSceneClick, HandleDisableSceneClick);
      handleTable.Add (NotificationIDs.ID_EnableSceneClick, HandleEnableSceneClick);
      handleTable.Add (NotificationIDs.ID_InputAddReservedArea, HandleInputAddReservedArea);
      handleTable.Add (NotificationIDs.ID_InputRemoveReservedArea, HandleInputRemoveReservedArea);
    }

    /// <summary>
    /// 我感兴趣的消息
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests ()
    {
      if (interests.Count == 0) {
        interests.Add (TS.NtftNames.TOUCH_MAP);
        interests.Add (NotificationIDs.ID_DisableSceneClick);
        interests.Add (NotificationIDs.ID_EnableSceneClick);
        interests.Add (NotificationIDs.ID_InputAddReservedArea);
        interests.Add (NotificationIDs.ID_InputRemoveReservedArea);
      }

      return interests;
    }

    /// <summary>
    /// 处理通知
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification (INotification notification)
    {
      if (handleTable.ContainsKey (notification.Name)) {
        handleTable [notification.Name] (notification);
      }
    }

    private void HandleInputAddReservedArea (INotification notification)
    {
      if (notification == null)
        return;
      InputEventBean bean = (InputEventBean)notification.Body;
      InputManager.Instance.AddReservedArea (bean.eventName, bean.eventParam);
    }

    private void HandleInputRemoveReservedArea (INotification notification)
    {
      if (notification == null)
        return;
      InputEventBean bean = (InputEventBean)notification.Body;
      InputManager.Instance.RemoveReservedArea(bean.eventName);
    }

    private void HandleEnableSceneClick (INotification notification)
    {
      InputManager.Instance.EnableGesture (true);
      InputManager.Instance.EnableJoystick(true);
    }

    private void HandleDisableSceneClick (INotification notification)
    {
      InputManager.Instance.EnableGesture (false);
      InputManager.Instance.EnableJoystick(false);
    }

    private void HandleTouchMap (INotification notification)
    {
      Tang.TouchHit touchHit = notification.Body as Tang.TouchHit;
      Gesture gesture = touchHit.extraObject as Gesture;
      if (gesture.swipe.Equals (EasyTouch.SwipeType.None)) {
        InputManager.Instance.CreateWayPoint (touchHit.point);
      }
    }
  }
}