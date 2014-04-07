/// <summary>
/// Create walkable grids wizard.
/// </summary>

using UnityEditor;
using UnityEngine;

namespace TangScene
{
  public class CreateContourWizard: ScriptableWizard
  {
    // texture2D, 0.5F, 1F, Vector3.zero, 32, 16
    public int width = 0;
    public int height = 0;
    public int offsetx = 0;
    public int offsetz = 0;
    public float accuracy = 1F;
    public bool holes = true;
    public float alphaCutoff = 0.1F;
    public bool renderer = true;
    public bool colliderWithTrigger = false;
		
    [MenuItem ("TangScene/Create Contour Object ...")]
    static void CreateWizard ()
    {
      ScriptableWizard.DisplayWizard<CreateContourWizard> ("Create Contour Object", "Create");
    }
	
    void OnWizardCreate ()
    {



      foreach (Object obj in Selection.objects) {
				
	if (obj is Texture) {
	
	  Texture2D texture2D = obj as Texture2D;
	  float scalex = 1F * width / texture2D.width;
	  float scaley = 1F * height / texture2D.height;
	  float scale = 0;
	  bool isScaleEquals = false;
	  bool isUseScalex = false;
	  if( Mathf.Abs(scalex - scaley) < 0.1F )
	    {
	      isScaleEquals = true;
	      scale = scalex;
	    }
	  else
	    {
	      if(scalex > scaley)
		{
		  scale = scalex;
		  isUseScalex = true;
		}
	      else
		scale = scaley;	  
	    }

						
	  GameObject go = new GameObject();
	  go.name = "contour_" + texture2D.name;
					
	  // mesh
	  Vector3 pivot3D = new Vector3(-offsetx/scale, offsetz/scale + texture2D.height, 0F);
					
	  // mesh
	  Mesh mesh = Polyz.Texture2Contour( 
					    texture2D, 
					    alphaCutoff, 
					    accuracy, 
					    holes, 
					    scale, 
					    pivot3D);

	  if( !isScaleEquals )
	    {
	      Vector3[] vertices = mesh.vertices;
	      if(isUseScalex)
		{
		  for(int i=0; i< vertices.Length; i++)
		    vertices[i] += Vector3.back * vertices[i].z * (scalex - scaley);
		}
	      else
		{
		  for(int i=0; i< vertices.Length; i++)
		    vertices[i] += Vector3.right * vertices[i].x * (scaley - scalex);
	      
		}
	      mesh.vertices = vertices;
	    }
					
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
      helpString = "Please set parameters for contour mesh";
    }
				
  }
}