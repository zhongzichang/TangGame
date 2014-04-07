/// <summary>
/// Create walkable grids wizard.
/// </summary>

using UnityEditor;
using UnityEngine;

namespace TangScene
{
  public class CreateGridsWizard: ScriptableWizard
  {
    // texture2D, 0.5F, 1F, Vector3.zero, 32, 16
    public int width = 0;
    public int height = 0;
    public int horizontalSubDivWidth = 32;
    public int verizontalSubDivHeight = 16;
    public float alphaCutoff = 0.1F;
    public bool renderer = false;
    public bool colliderWithTrigger = false;
    public int offsetx = 0;
    public int offsetz = 0;
		
    [MenuItem ("TangScene/Create Grid Object ...")]
    static void CreateWizard ()
    {
      ScriptableWizard.DisplayWizard<CreateGridsWizard> ("Create Grid Object", "Create");
    }
	
    void OnWizardCreate ()
    {
      foreach (Object obj in Selection.objects) {
				
	if (obj is Texture) {

	  Texture2D texture2D = obj as Texture2D;

	  float scale = width / texture2D.width;
	  int horizontalSubDivs = width / horizontalSubDivWidth;
	  int verizontalSubDivs = height / verizontalSubDivHeight;
	  
						
	  GameObject go = new GameObject();
	  go.name = texture2D.name + "-grids";
					
	  // mesh
	  Vector3 pivot3D = new Vector3(-offsetx/scale, offsetz/scale + texture2D.height, 0F);
	  Mesh mesh = Polyz.Texture2Grid ( texture2D, 
					   alphaCutoff, 
					   scale,
					   pivot3D, 
					   horizontalSubDivs, 
					   verizontalSubDivs );
					
	  // mesh filter
	  MeshFilter mf = go.AddComponent<MeshFilter>();
	  mf.sharedMesh = mesh;
					
	  if( colliderWithTrigger ) {
	    // mesh collider
	    MeshCollider mc = go.AddComponent<MeshCollider>();
	    mc.sharedMesh = mesh;
	    mc.isTrigger = true;
	  }
					
					
	  if( renderer ) {
	    // material
	    Material mat = new Material( Shader.Find("Transparent/Diffuse") );
	    mat.color = TextureHelper.SampleUnClearColor( texture2D );
	    // mesh renderer
	    MeshRenderer mr = go.AddComponent<MeshRenderer>();
	    mr.castShadows = false;
	    mr.receiveShadows = false;
	    mr.sharedMaterial = mat;
	  }
					
						
	}
      }
    }
	
    void OnWizardUpdate ()
    {
      helpString = "Please set parameters for grids mesh";
    }
				
  }
}