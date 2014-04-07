using UnityEngine;
using UnityEditor;
using System.Collections;

namespace TangScene {
	
  public class CreateStageWizard : ScriptableWizard {
	
    public int offsetx = 0;
    public int offsetz = 0;
    public int width;
    public int height;
			
    [MenuItem ("TangScene/Create Stage Object ...")]
    static void CreateWizard ()
    {
      ScriptableWizard.DisplayWizard<CreateStageWizard> ("Create Stage Object", "Create" );
    }
	
    void OnWizardCreate ()
    {
      if( Selection.activeObject != null ){
				
	Object obj = Selection.activeObject;
	if( obj is Texture ){
					
	  Texture texture = obj as Texture;

	  string matName = "stage_"+texture.name;
	  string matPath = "Assets/TangScene-Resources/Materials/"+matName+".mat";
	  Material mat;
	  UnityEngine.Object matObj = AssetDatabase.LoadAssetAtPath(matPath, typeof(Material));
	  if( matObj != null )
	    {
	      mat = matObj as Material;
	    }
	  else
	    {
	      mat = new Material( Shader.Find("Mobile/Diffuse") );    
	      mat.name = texture.name;
	      mat.mainTexture = texture;
	      AssetDatabase.CreateAsset(mat, matPath);
	    }
	  mat.name = matName;
					
	  GameObject gobj = new GameObject();
	  gobj.name = matName;

	  // mesh
	  Mesh mesh = MeshHelper.CreateRectBaseXz(offsetx, -offsetz, width, height);
					
	  // mesh filter
	  MeshFilter mf = gobj.AddComponent<MeshFilter>();
	  mf.sharedMesh = mesh;

	  // collider
	  MeshCollider collider = gobj.AddComponent<MeshCollider>();
	  collider.sharedMesh = mesh;
					
	  // mesh renderer
	  MeshRenderer mr = gobj.AddComponent<MeshRenderer>();
	  mr.sharedMaterial = mat;
	  mr.castShadows = false;
	  mr.receiveShadows = false;

	  // stage behaviour
	  StageBhvr bhvr = gobj.AddComponent<StageBhvr>();
	  bhvr.x = offsetx;
	  bhvr.y = offsetz;
	  bhvr.width = width;
	  bhvr.height = height;
	  bhvr.materialName = mat.name;

	}
      }
    }
	
    void OnWizardUpdate ()
    {
      helpString = "Please set parameters for map";
    }
  }
}