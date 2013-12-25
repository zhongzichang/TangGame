using UnityEngine;
using System.Collections;

namespace TangScene
{
	[ExecuteInEditMode]
	public class Map : MonoBehaviour
	{
		
		public int width;
		public int height;
		public Texture texture;
		
		private MeshFilter mf = null;
		private MeshRenderer mr = null;
	
		// Use this for initialization
		void Start ()
		{
			
			if (width != 0 && height != 0) {
				
				mf = gameObject.GetComponent<MeshFilter> ();
				if (mf == null) {					
					mf = gameObject.AddComponent<MeshFilter> ();
					Mesh mesh = Tang.MeshOne.NewMesh ();
#if UNITY_EDITOR
					mf.sharedMesh = mesh;
#else
					mf.mesh = mesh;
#endif
				}
				mr = gameObject.GetComponent<MeshRenderer>();
				if(mr == null){
					mr = gameObject.AddComponent<MeshRenderer> ();
				}
				mr.castShadows = false;
				mr.receiveShadows = false;
				Material mat = new Material(Shader.Find("Diffuse"));
				mat.mainTexture = texture;
#if UNITY_EDITOR
				mr.sharedMaterial = mat;
#else
				mr.material = mat;
#endif
				transform.localScale = new Vector3( (float) width, 1F, (float) height );
			}
			
			
			transform.hideFlags = HideFlags.NotEditable;
			if(mr != null)
				mr.hideFlags = HideFlags.HideInInspector;
			if(mf != null)
				mf.hideFlags = HideFlags.HideInInspector;
			
			transform.localPosition = new Vector3(width/2,0F,height/2);
			
		
		}
		
	}
}