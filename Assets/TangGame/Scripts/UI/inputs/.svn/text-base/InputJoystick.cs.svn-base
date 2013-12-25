using UnityEngine;
using System.Collections;

namespace TangGame
{
  /// <summary>
  /// Joystick event
  /// </summary>
  public class InputJoystick : MonoBehaviour
  {
    public EasyJoystick joystick;

 
    void OnEnable()
    {
      EasyJoystick.On_JoystickMove += On_JoystickMove;
    }

    void OnDisable()
    {
      UnsubscribeEvent();
    }

    void OnDestroy()
    {
      UnsubscribeEvent();
    }

    public void Move(Vector2 position)
    {
      Vector2 joystickCenter = new Vector2(position.x / VirtualScreen.xRatio, VirtualScreen.height - position.y / VirtualScreen.yRatio);
      joystick.JoyAnchor = EasyJoystick.JoystickAnchor.None;
      joystick.JoystickPositionOffset = joystickCenter;
      joystick.enable = true;
      transform.localPosition = position;
    }

    private void UnsubscribeEvent()
    {
      EasyJoystick.On_JoystickMove -= On_JoystickMove;
    }

    void On_JoystickMove(MovingJoystick move)
    {
      Vector3 moveDirection = new Vector3(move.joystickAxis.x, 0, move.joystickAxis.y);
      TangScene.TS.ActorMove(new TangScene.MoveBean(ActorCache.leadingActorId, moveDirection));
    }
  }
}