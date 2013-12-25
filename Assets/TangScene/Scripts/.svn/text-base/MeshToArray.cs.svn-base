using System;
using UnityEngine;

namespace TangScene
{
  public class MeshToArray
  {
		
    public static  int[] TranslateByXZ(Mesh mesh){
      

      // triangles
      int[] triangles = mesh.triangles;
      // points
      int[] points = new int[triangles.Length / 3];
      float cellw = 0F;
      float cellh = 0F;
      int pointIndex = 0;
			
      for( int i=0; i<triangles.Length; i+=3 ){
				
	// the first point
	Vector3 v = mesh.vertices[ triangles[i] ];
				
	float minX = v.x;
	float maxX = v.x;
	float minZ = v.z;
	float maxZ = v.z;
			
	// the second point and the third point
	for( int j=1; j<3; j++ ){
					
	  v = mesh.vertices[ triangles[i+j] ];
					
	  if(v.x < minX) {
	    minX = v.x;
	  } else if(v.x > maxX) {
	    maxX = v.x;
	  }
					
	  if(v.z < minZ) {
	    minZ = v.z;
	  } else if(v.z > maxZ) {
	    maxZ = v.z;
	  }
					
	}
				
	int maxXCount = 0;
	for( int j=0; j<3; j++ ){
					
	  v = mesh.vertices[ triangles[i+j] ];
					
	  if( Mathf.Abs(maxX - v.x) < 1F ){
	    maxXCount++;
	  }
					
	}
				
	if ( maxXCount == 1 ){
					
	  // is right botom triangle
					
	  cellw = maxX - minX;
	  cellh = maxZ - minZ;
					
	  int x = Mathf.RoundToInt ( minX / cellw );
	  int y = - Mathf.RoundToInt ( maxZ / cellh );
					
	  points[pointIndex++] = x;
	  points[pointIndex++] = y;
					
	}
				
      }
			
      return points;
			
    }

    public static float[] TranslateByXZFloat(Mesh mesh){
			
      int[] triangles = mesh.triangles;
      float[] points = new float[triangles.Length / 3];
      float cellw = 0F;
      float cellh = 0F;
      int pointIndex = 0;
			
      for( int i=0; i<triangles.Length; i+=3 ){
				
	Vector3 v = mesh.vertices[ triangles[i] ];
				
	float minX = v.x;
	float maxX = v.x;
	float minZ = v.z;
	float maxZ = v.z;
				
	for( int j=1; j<3; j++ ){
					
	  v = mesh.vertices[ triangles[i+j] ];
					
	  if(v.x < minX) {
	    minX = v.x;
	  } else if(v.x > maxX) {
	    maxX = v.x;
	  }
					
	  if(v.z < minZ) {
	    minZ = v.z;
	  } else if(v.z > maxZ) {
	    maxZ = v.z;
	  }
					
	}
				
	int maxXCount = 0;
	for( int j=0; j<3; j++ ){
					
	  v = mesh.vertices[ triangles[i+j] ];
					
	  if( Mathf.Abs(maxX - v.x) < 0.1F ){
	    maxXCount++;
	  }
					
	}
				
	if ( maxXCount == 1 ){
					
	  // is left top triangle
					
	  cellw = maxX - minX;
	  cellh = maxZ - minZ;
					
	  float x = minX / cellw ;
	  float y = - ( maxZ / cellh );
					
	  points[pointIndex++] = x;
	  points[pointIndex++] = y;
					
	}
				
      }
			
      return points;
			
    }

		
  }
}

