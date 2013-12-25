using UnityEngine;

namespace TangScene
{
	public class FpsBhvr : MonoBehaviour
	{
    
		private int fps = 0;
		private float fpsDeltaTime = 0;
		private int fpsCounter = 0;

		void Update ()
		{
			float newFpsDeltaTime = fpsDeltaTime + Time.deltaTime;
			if (newFpsDeltaTime >= 1F) {
				fps = fpsCounter;
				fpsDeltaTime = 0F;
				fpsCounter = 0;
			} else {
				fpsDeltaTime = newFpsDeltaTime;
				fpsCounter++;
			}
      
		}
    
		void OnGUI ()
		{
			GUI.Label (new Rect (Screen.width - 120, Screen.height - 100, 100, 60), 
		 " FPS:" + fps);

		}
	}
}