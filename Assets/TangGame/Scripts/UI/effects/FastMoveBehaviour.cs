using UnityEngine;
using System.Collections;

namespace TangGame
{
	public class FastMoveBehaviour : MonoBehaviour {
		private float MIN_FASTMOVE_DISTANCE =  30f;
		private const float FASTMOVE_POSY = 140f;
		private int MAX_COUNT = 5;
		private Vector3 lastPosition;
		
		private Stack fastMoves = new Stack();
		
		void OnDisable(){
			while(fastMoves.Count > 0){
				RecycleFastMove();
			}
		}
		
		void Update () {
			Vector3 position = transform.localPosition;
			
			if(MIN_FASTMOVE_DISTANCE > Vector3.Distance(lastPosition, position)) return;	
			SpawnFastMove(this.gameObject);
			lastPosition = position;
		}
		
		void RecycleFastMove(){
			GameObject obj = fastMoves.Pop() as GameObject;
			if(obj){
				obj.SetActive(false);
				GameObject.Destroy(obj);
			}
		}
		
		void SpawnFastMove(GameObject actor){

			if(fastMoves.Count > MAX_COUNT){
				RecycleFastMove();
			}
			GameObject go = new GameObject("FastMove");
			FastMove fastMove = go.AddComponent<FastMove>();
			fastMove.actor = actor;
			go.transform.localPosition = transform.localPosition;
			go.transform.localScale = transform.localScale;
			fastMoves.Push(go);
		}

	}
}