using UnityEngine;
using System.Collections;

namespace TangGame
{
	public class FastMove : MonoBehaviour
	{
		public float duration = 0.5f;

		public GameObject actor;
		
		void Start(){
			StartCoroutine(FadePlayerRoutine());
		}

		void CreateMaterials (GameObject actor)
		{
			MeshFilter[] filters = actor.GetComponentsInChildren<MeshFilter> ();
			foreach (MeshFilter f in filters) {
				GameObject tmp = new GameObject ();
				tmp.name = f.name;
				tmp.transform.parent = transform;
				MeshFilter meshFilter = tmp.AddComponent<MeshFilter> ();
				tmp.AddComponent<MeshRenderer> ();
				meshFilter.transform.localPosition = f.renderer.transform.localPosition;
				meshFilter.transform.localScale = f.renderer.transform.localScale;
				meshFilter.mesh = f.mesh;
        Material material = new Material ( Shader.Find("Mobile/Tang/Transparent/UV_RGBA_Scale"));
        material.mainTexture = f.renderer.material.mainTexture;
        meshFilter.renderer.material = material;
			}
		}
		
		IEnumerator FadePlayerRoutine(){
			if (this.actor != null) {
				CreateMaterials (this.actor);
			}
			
			float start = Time.time;
			float elapsed = 0;
			while(elapsed < duration){
				float normalisedTime = Mathf.Clamp(elapsed / duration, 0, 1);
				FadePlayer(1-normalisedTime);
				yield return 0;
				elapsed = Time.time - start;
			}
			this.enabled = false;
		}
		
		private void FadePlayer(float alpha){
			MeshFilter[] filters = gameObject.GetComponentsInChildren<MeshFilter>();
			foreach (MeshFilter f in filters) {
        f.renderer.material.SetColor("_tangRGBA", new Vector4(1, 1, 1, alpha));
			}
		}
	}
}