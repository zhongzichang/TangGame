using UnityEngine;
using System.Collections;

namespace TangGame
{
	public class InputManager : MonoBehaviour {

		private static InputManager _instance = null;
		private InputGesture inputGesture;
    private InputJoystick inputJoystick;

    private string joystickKey = "joystickArea";
		private Rect joystickArea = new Rect(64, 64, 256, 192); // joystick working area
    private Rect virtualScreenArea;

		public static InputManager Instance {
			get {
				if (_instance != null) 
					return _instance;

				GameObject obj = GameObject.Instantiate(Resources.Load("Prefabs/InputManager")) as GameObject;
				obj.name = "_InputManager";
				_instance = obj.AddComponent<InputManager> ();
				_instance.OnInit();	
        return _instance;
			}
		}

		//     Debug please uncomment OnGUI
//		void OnGUI(){
//			GUILayout.BeginArea (new Rect (200,0,200,60)); 
//
//			if (GUILayout.Button("InputGesture")){
//				InputManager.Instance.GestureEnabled = !InputManager.Instance.GestureEnabled;
//			}
//			if (GUILayout.Button("InputJoystick")){
//				InputManager.Instance.JoystickEnabled = !InputManager.Instance.JoystickEnabled;
//			}
//
//			GUILayout.EndArea (); 
//		}

		public void EnableGesture(bool enabled) {
      if(enabled){
        inputGesture.gameObject.SetActive(true);
      }else{
        inputGesture.gameObject.SetActive(false);
      }
		}

    public void EnableJoystick(bool enabled) {
      if(enabled){
        inputGesture.AddReservedArea(joystickKey, virtualScreenArea);
        inputJoystick.gameObject.SetActive(true);
      }else{
        inputGesture.RemoveReservedArea(joystickKey);
        inputJoystick.gameObject.SetActive(false);
      }
    }

		public void CreateWayPoint(Vector2 position){
      if(! inputGesture.gameObject.activeSelf) return;
			inputGesture.CreateWayPoint(position);
		}

    public void AddReservedArea(string key, Rect obj){
      inputGesture.AddReservedArea(key, obj);
    }
    
    public void RemoveReservedArea(string key){
      inputGesture.RemoveReservedArea(key);
    }

    public void MoveJoystick(Vector2 position){
      inputJoystick.Move(position);
    }

		private void OnInit(){
			inputGesture = _instance.GetComponentInChildren<InputGesture>();
			inputJoystick = _instance.GetComponentInChildren<InputJoystick>();

      virtualScreenArea = new Rect(joystickArea.x*VirtualScreen.xRatio, joystickArea.y*VirtualScreen.yRatio,
                                   joystickArea.width*VirtualScreen.xRatio, joystickArea.height*VirtualScreen.yRatio);

		}

	}
}
