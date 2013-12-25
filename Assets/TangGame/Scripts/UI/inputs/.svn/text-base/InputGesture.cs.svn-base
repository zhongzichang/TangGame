using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;

namespace TangGame
{
	public class InputGesture : MonoBehaviour
	{
		public Waypoint waypointPrefab;
		public float duration = 1.0f;
		public InputJoystick joystick = null;
		private GameObject trail = null;
		private const int WAYPOINT_POSY = 10;

		private Hashtable reservedAreas = new Hashtable();

		void Start ()
		{
			ObjectPool.CreatePool (waypointPrefab);
		}

		void OnEnable ()
		{
			EasyTouch.On_SimpleTap += On_SimpleTap;
			EasyTouch.On_DoubleTap += On_DoubleTap;
			EasyTouch.On_SwipeStart += On_SwipeStart;
			EasyTouch.On_Swipe += On_Swipe;
			EasyTouch.On_SwipeEnd += On_SwipeEnd;
		}

		void OnDisable ()
		{
			UnsubscribeEvent ();
		}

		void OnDestroy ()
		{
			UnsubscribeEvent ();
		}

		private void UnsubscribeEvent ()
		{
			EasyTouch.On_SimpleTap -= On_SimpleTap;
			EasyTouch.On_SwipeStart -= On_SwipeStart;
			EasyTouch.On_Swipe -= On_Swipe;
			EasyTouch.On_SwipeEnd -= On_SwipeEnd;
		}

    public void AddReservedArea(string key, Rect area){
			reservedAreas[key] = area;
		}

    public void RemoveReservedArea(string key){
      reservedAreas.Remove(key);
    }

    private bool IsReservedArea(Vector2 position){
      foreach( string key in reservedAreas.Keys){
        Rect reservedArea = (Rect)reservedAreas[key];
        if(reservedArea.Contains(position)){
          return true;
        }
      }
      return false;
    }
		
		private void On_SwipeStart (Gesture gesture)
		{
			if (OnTapUICameraFireRay (gesture.position)) {
				return;
			}

			ActorCache.swipeActorIds.Clear ();
			ActorCache.swipeHeroIds.Clear ();
			ActorCache.swipeMonsterIds.Clear ();
			trail = InstantiateTouchTrail (gesture);
		}

		private void On_Swipe (Gesture gesture)
		{
			if (IsReservedArea (gesture.position)) {
				DestroyTouchTrail ();
				return;
			}
			MoveTouchTrail (gesture);
			
			Vector3 screenPos = gesture.position;
			if (Camera.main == null)
				return;

			Ray ray = Camera.main.ScreenPointToRay (screenPos);
			RaycastHit[] hits;
			hits = Physics.RaycastAll (ray);
			if (hits.Length != 0) {
				GameObject[] gameobjects = new GameObject[hits.Length];
				int index = 0;
				foreach (RaycastHit hit in hits) {
					gameobjects [index++] = hit.collider.gameObject;
					Tang.TouchHit touchHit = new Tang.TouchHit (gesture.fingerIndex, hit.point, gesture);
					hit.collider.gameObject.SendMessage ("OnTouch", touchHit);
				}
			}
		}

		private void On_SwipeEnd (Gesture gesture)
		{
			DestroyTouchTrail ();
			if (ActorCache.swipeHeroIds.Count > 0)
				SelectPlayerEffect.Instance.DoEffect ();
//			SelectPlayerEffect.players = ActorCache.swipeHeroIds;
		}

		private void On_DoubleTap (Gesture gesture)
		{
			if(IsReservedArea(gesture.position)){
				Debug.Log("Is not in work area.");
				return;
			}
			if (OnTapUICameraFireRay (gesture.position)) {
				return;
			}
			OnTapScenesCameraFireRay (gesture);
		}

		private void On_SimpleTap (Gesture gesture)
		{
			if(IsReservedArea(gesture.position)){
        InputManager.Instance.MoveJoystick(gesture.position);
				return;
			}
			if (OnTapUICameraFireRay (gesture.position)) {
				return;
			}
			OnTapScenesCameraFireRay (gesture);
		}

		private bool OnTapUICameraFireRay (Vector2 position)
		{
			if (UICamera.mainCamera == null)
				return false;
			Ray ray = UICamera.mainCamera.ScreenPointToRay (position);
			RaycastHit hit;
			if (!Physics.Raycast (ray, out hit))
				return false;
			//      Debug.Log("Hit UICamera.mainCamera: " + hit.transform.name);
			return true;
		}

		private void OnTapScenesCameraFireRay (Gesture gesture)
		{
			
			if (Camera.main == null)
				return;
			Ray ray = Camera.main.ScreenPointToRay (gesture.position);
			RaycastHit hit;
			if (!Physics.Raycast (ray, out hit))
				return;
			if (hit.transform == null)
				return;

			Tang.TouchHit touchHit = new Tang.TouchHit (gesture.fingerIndex, hit.point, gesture);
			hit.collider.gameObject.SendMessage ("OnTouch", touchHit);
		}

		public void CreateWayPoint (Vector3 point)
		{
			ObjectPool.Spawn (waypointPrefab, point + Vector3.up * WAYPOINT_POSY);
		}

		GameObject PickObject (Vector2 screenPos)
		{
			Ray ray = Camera.main.ScreenPointToRay (screenPos);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
				return hit.collider.gameObject;
			
			return null;
		}

		GameObject[] PickObjectAll (Vector2 screenPos)
		{
			Ray ray = Camera.main.ScreenPointToRay (screenPos);
			RaycastHit[] hits;
			hits = Physics.RaycastAll (ray);
			if (hits.Length == 0)
				return null;
			GameObject[] gameobjects = new GameObject[hits.Length];
			int index = 0;
			foreach (RaycastHit hit in hits) {
				gameobjects [index++] = hit.collider.gameObject;
			}
			return gameobjects;
		}

		private void NavTo (Vector3 hitPoint)
		{
			// TODO:
			TangScene.TS.ActorNavigate (new TangScene.MoveBean (TangGame.ActorCache.leadingActorId, hitPoint));
		}

		public GameObject InstantiateTouchTrail (Gesture gesture)
		{
			if (this.trail != null)
				return null;
			if (Camera.main == null)
				return null;
			Vector3 position = GetTouchToWordlPoint (gesture);
			return Instantiate (Resources.Load ("Prefabs/Inputs/Trail"), position, Quaternion.identity)as GameObject;
		}

		public void MoveTouchTrail (Gesture gesture)
		{
			if (this.trail == null)
				return;
			if (Camera.main == null)
				return;
			Vector3 position = GetTouchToWordlPoint (gesture);
			trail.transform.position = position;
			
		}

		public void DestroyTouchTrail ()
		{
			if (this.trail == null)
				return;
			if (Camera.main == null)
				return;
			Object.Destroy (trail.gameObject, 0.5f);
		}

		public Vector3 GetTouchToWordlPoint (Gesture gesture)
		{
			//    	return gesture.GetTouchToWordlPoint(400);  // 4000 is 1000-400
			return Camera.main.ScreenToWorldPoint (new Vector3 (gesture.position.x, gesture.position.y, 400));
		}
	}
}