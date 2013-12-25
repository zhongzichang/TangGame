using UnityEngine;
using System.Collections;


namespace TangScene
{

  [ RequireComponent( typeof(SpriteAnimate) ) ]
  public class HeightOffsetBhvr : MonoBehaviour {

    private Vector3 cameraLastPosition;
    private bool visible = false;
    private SpriteAnimate spriteAnimate = null;
    private float rate;


    private void OnBecameVisible()
    {
      if( !visible )
	{
	  visible = true;
	  cameraLastPosition = Camera.main.transform.localPosition;
	}
    }
    
    private void OnBecameInvisible()
    {
      visible = false;
    }

    // Use this for initialization
    void Start () {

      if( Camera.main == null )
	{
	  Debug.LogWarning("Camera.main is null.");
	}
      else
	{
	  
	  float cameraHeight = Camera.main.transform.localPosition.y;
	  float transformHeight = transform.localPosition.y;

	  if( transformHeight > cameraHeight )
	    {
	      enabled = false;
	    }
	  else
	    {
	      rate = cameraHeight / transformHeight;
	      spriteAnimate = GetComponent<SpriteAnimate>();
	      if(spriteAnimate != null)
		{
		  spriteAnimate.becameVisibleHandler += OnBecameVisible;
		  spriteAnimate.becameInvisibleHandler += OnBecameInvisible;
		}
	    }
	}
    }
	
    // Update is called once per frame
    void Update () {
      if( visible )
	{

	  Vector3 offset = (Camera.main.transform.localPosition - cameraLastPosition) / rate;
	  transform.localPosition -= new Vector3(offset.x, 0F, offset.z);
	  cameraLastPosition = Camera.main.transform.localPosition;
	}

    }


  }

}
