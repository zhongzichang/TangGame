/*
 * Created by emacs
 * Date: 2013/9/16
 * Author: zzc
 */

using UnityEngine;
using Tang;

namespace TangScene
{

  [RequireComponent(typeof(MeshRenderer))]
  public class LoadableMaterialBhvr : MonoBehaviour
  {

    private string matName = null;
    private MeshRenderer mr = null;

    public string MatName
    {
      get
	{
	  return matName;
	}
      set
	{
	  if( matName != value )
	    {
	      matName = value;
	      OnMaterialChange();
	    }
	}
    }

    private void OnMaterialChange()
    {
      if( matName != null )
	{
	  string filepath = Tang.ResourceUtils.GetAbFilePath( matName );
	  ResourceLoader.Enqueue( filepath, OnMaterialLoad, OnMaterialLoadFailure );
	}
    }

    private void OnMaterialLoad(WWW www)
    {
//      Debug.Log("OnMaterialLoad" + www.url);
//      Debug.Break();
      mr.material = www.assetBundle.mainAsset as Material;
    }

    private void OnMaterialLoadFailure(WWW www)
    {
      Debug.Log( "Failure to load WWW " + www.url );
    }

    void Start()
    {
      mr = GetComponent<MeshRenderer>();
      if( mr == null )
	{
	  mr = gameObject.AddComponent<MeshRenderer>();
	}
      mr.castShadows = false;
      mr.receiveShadows = false;

    }
  }
}
