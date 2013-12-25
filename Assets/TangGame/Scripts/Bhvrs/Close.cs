using UnityEngine;
using System.Collections;

namespace TangGame
{
  
  public class Close : MonoBehaviour
  {

    // Update is called once per frame
    void Update ()
    {
      if(Input.GetKeyUp(KeyCode.Backspace)||
	 Input.GetKeyUp(KeyCode.Escape))
	{
	  Application.Quit();
	}
    }
  }

}


