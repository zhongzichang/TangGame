using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	private Vector3 originPosition;
	private Quaternion originRotation;
	private float shake_decay;
	private float shake_intensity;
	private float shake_factor;

	/// <summary>
	/// 调试时打开
	/// </summary>
//	void OnGUI (){
//		if (GUI.Button (new Rect (20,40,80,20), "Shake")){
//			Shake ();
//		}
//	}
	
	void Update (){
		if (shake_intensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * shake_factor,
				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * shake_factor,
				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * shake_factor,
				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * shake_factor);
			shake_intensity -= shake_decay;
		}
	}
	
	public void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
		shake_intensity = .005f;
		shake_decay = .002f;
		shake_factor = .2f;
	}
}