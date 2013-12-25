///xbhuang
///小伙伴们，来点乐子吧！
using UnityEngine;
using System.Collections;
using TangScene;

public class KnockIntoAirBehaviour : MonoBehaviour {
	/// <summary>
	/// 攻击对象ID
	/// </summary>
	public long actorId;
	/// <summary>
	/// 被攻击对象ID
	/// </summary>
	public long targetId;
	/// <summary>
	/// 被击飞的方向
	/// </summary>
	public Vector3 direction;
	public const float DEFAULT_SPEED = 800F;
	public float speed = DEFAULT_SPEED;
	// Use this for initialization
	void Start () {
		
		//禁用掉导航脚本
		TS.GetActorGameObject(targetId).GetComponent<NavMeshAgent>().enabled = false;
		StartCoroutine(DestroyAfterAwhile(targetId,0.2f));
		Vector3 actorPosi = TS.GetActorGameObject(actorId).transform.localPosition;
		Vector3 targetPosi = TS.GetActorGameObject(targetId).transform.localPosition;
		//获取击飞的方向
		direction = GameUtils.GetDirection(actorPosi , targetPosi);
		if(float.IsNaN(direction.x)){
			direction = Vector3.zero;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( Time.deltaTime * speed * direction );
	}
	IEnumerator DestroyAfterAwhile(long id,float second){
		yield return new WaitForSeconds(second);
		TS.ActorExit(id);
	}
	
	
}
