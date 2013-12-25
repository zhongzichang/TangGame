/**
 * Effect manager
 *
 * Author: Lite
 * 
 * Date: 2013/11/11
 * Edit: zzc
 * Desc: 整理代码
 */
using System;
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

namespace TangGame
{

	/// <summary>
	///   特效管理器
	/// </summary>
	public class EffectManager : MonoBehaviour
	{

		/// <summary>
		///   特效的默认生存时间
		/// </summary>
		public const float DEFAULT_LIFETIME = 1F;
		private static EffectManager _instance = null;

    
		/// <summary>
		///   EffectManager 实例
		/// </summary>
		public static EffectManager Instance {
			get {
				if (_instance != null) 
					return _instance;

				var obj = new GameObject ("_EffectManager");
				obj.transform.localPosition = Vector3.zero;
				_instance = obj.AddComponent<EffectManager> ();

				return _instance;
			}
		}
		
		
		/// <summary>
		/// 开启暴击镜头抖动特效
		/// </summary>
		public void EnableCameraShake ()
		{
			CameraShake cameraShake = Camera.main.GetComponent<CameraShake> ();
			if (cameraShake == null) {
				cameraShake = Camera.main.gameObject.AddComponent<CameraShake> ();
			}
			cameraShake.Shake ();
		}
		
		/// <summary>
		/// 开启或关闭一个对象的的残影特效
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="unable"></param>
		public void EnableFastMove (GameObject obj, bool endable)
		{
			if (enabled) {
				Show<FastMoveBehaviour> (obj, DEFAULT_LIFETIME);
			} else {
				Hide<FastMoveBehaviour> (obj);
			}
		}

		/// <summary>
		///   显示特效
		/// </summary>
		private void Show<TEffectMonoBehaviour> (GameObject obj, float delay)
      where TEffectMonoBehaviour : MonoBehaviour
		{
			TEffectMonoBehaviour effect = obj.GetComponent<TEffectMonoBehaviour> ();
			if (effect == null) {
				effect = obj.AddComponent<TEffectMonoBehaviour> ();
			}
			if (delay > 0) {
				StartCoroutine (DestroyEffectRoutine (effect, delay));
			}
		}

		/// <summary>
		///   延时销毁特效
		/// </summary>
		private IEnumerator DestroyEffectRoutine<TEffectMonoBehaviour> (TEffectMonoBehaviour effect, float delay)
      where TEffectMonoBehaviour : MonoBehaviour
		{
			yield return new WaitForSeconds (delay);
			RecycleEffect (effect);
		}

		/// <summary>
		///   隐藏特效
		/// </summary>
		private void Hide<TEffectMonoBehaviour> (GameObject obj) 
      where TEffectMonoBehaviour : MonoBehaviour
		{
			TEffectMonoBehaviour effect = obj.GetComponent<TEffectMonoBehaviour> ();
			RecycleEffect (effect);
			
		}
		

		/// <summary>
		///   销毁特效
		/// </summary>
		private void RecycleEffect (MonoBehaviour effect)
		{
			if (effect == null)
				return;

			effect.enabled = false;
			GameObject.Destroy (effect);
		}
	}
}
