/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/7/29
 * Time: 23:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;

namespace Tang
{
	/// <summary>
	/// Description of MeshOne.
	/// </summary>
	public class MeshOne
	{
		
		
		private static Vector3[] vertices = new Vector3[]{
			new Vector3(-0.5F,0F,0.5F),
			new Vector3(0.5F,0F,0.5F),
			new Vector3(0.5F,0F,-0.5F),
			new Vector3(-0.5F,0F,-0.5F)
		};
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

		public static Mesh NewMesh()
		{
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			mesh.uv = uv;
			mesh.normals = normals;
			return mesh;
		}
		
		
		public static void Fix(ref Mesh mesh){
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			mesh.uv = uv;
			mesh.normals = normals;
		}
	}
}
