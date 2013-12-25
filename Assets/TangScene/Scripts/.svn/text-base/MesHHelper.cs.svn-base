using UnityEngine;

namespace TangScene
{
	
  /// <summary>
  /// Mesh helper. Create and fix mesh.
  /// </summary>
  public class MeshHelper
  {
    private static Vector2[] uv = new Vector2[]{
      new Vector2(0,1),
      new Vector2(1,1),
      new Vector2(1,0),
      new Vector2(0,0)
    };
    private static Vector3[] normals = new Vector3[]{
      Vector3.up,
      Vector3.up,
      Vector3.up,
      Vector3.up
    };
    private static int[] triangles = { 0,1,2,0,2,3 };

    /// <summary>
    /// Creates the rect base xz.
    /// </summary>
    /// <returns>
    /// The rect base xz.
    /// </returns>
    /// <param name='x'>
    /// X. leftTopCorner.x
    /// </param>
    /// <param name='z'>
    /// Z. leftTopCorner.z
    /// </param>
    /// <param name='width'>
    /// Width.
    /// </param>
    /// <param name='height'>
    /// Height.
    /// </param>
    public static Mesh CreateRectBaseXz(int x, int z, int width, int height ){

      Mesh mesh = new Mesh();
			
      Vector3[] vertices = new Vector3[4];
      vertices[0] = new Vector3( (float)x, 0F, (float)z );
      vertices[1] = new Vector3( (float)(x + width), 0F, (float) z );
      vertices[2] = new Vector3( (float)(x + width), 0F, (float) (z - height) );
      vertices[3] = new Vector3( (float)x, 0F, (float) (z - height) );

      mesh.vertices = vertices;
      mesh.triangles = triangles;
      mesh.uv = uv;
      mesh.normals = normals;

      return mesh;
    }
  }
}

