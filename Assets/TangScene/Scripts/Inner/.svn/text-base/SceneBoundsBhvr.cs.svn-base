using UnityEngine;


namespace TangScene
{
  
  public class SceneBoundsBhvr : MonoBehaviour
  {
    public Rect bounds;
    public float colliderThickness = 10.0F;
		
    // Sea Green For the Win!
    private Color sceneViewDisplayColor = new Color (0.20F, 0.74F, 0.27F, 0.50F);
		
		
    void OnDrawGizmos () {

      Gizmos.color = sceneViewDisplayColor;
      Vector3 lowerLeft = new Vector3 (bounds.xMin, 0F, -bounds.yMax);
      Vector3 upperLeft = new Vector3 (bounds.xMin, 0F, bounds.yMin);
      Vector3 lowerRight = new Vector3 (bounds.xMax, 0F, -bounds.yMax);
      Vector3 upperRight = new Vector3 (bounds.xMax, 0F, bounds.yMin);
			
      Gizmos.DrawLine (lowerLeft, upperLeft);
      Gizmos.DrawLine (upperLeft, upperRight);
      Gizmos.DrawLine (upperRight, lowerRight);
      Gizmos.DrawLine (lowerRight, lowerLeft);
    }
		
    void Start () {

      GameObject createdBoundaries = new GameObject ("Created Boundaries");
      createdBoundaries.transform.parent = transform;
      
      // left boundary
      GameObject leftBoundary = new GameObject ("Left Boundary");
      leftBoundary.transform.parent = createdBoundaries.transform;
      BoxCollider boxCollider = leftBoundary.AddComponent (typeof(BoxCollider)) as BoxCollider;
      boxCollider.size = new Vector3 (colliderThickness, colliderThickness, bounds.height + colliderThickness * 2.0F);
      boxCollider.center = new Vector3 (bounds.xMin - colliderThickness * 0.5F, 0.0F, -(bounds.y + bounds.height * 0.5F));
      
      // right boundary
      GameObject rightBoundary = new GameObject ("Right Boundary");
      rightBoundary.transform.parent = createdBoundaries.transform;
      boxCollider = rightBoundary.AddComponent (typeof(BoxCollider)) as BoxCollider;
      boxCollider.size = new Vector3 (colliderThickness, colliderThickness, bounds.height + colliderThickness * 2.0F);
      boxCollider.center = new Vector3 (bounds.xMax + colliderThickness * 0.5F, 0.0F, -(bounds.y + bounds.height * 0.5F));

      // top boundary
      GameObject topBoundary = new GameObject ("Top Boundary");
      topBoundary.transform.parent = createdBoundaries.transform;
      boxCollider = topBoundary.AddComponent (typeof(BoxCollider)) as BoxCollider;
      boxCollider.size = new Vector3 (bounds.width + colliderThickness * 2.0F, colliderThickness, colliderThickness);
      boxCollider.center = new Vector3 (bounds.x + bounds.width * 0.5F, 0.0F, -(bounds.yMin + colliderThickness * 0.5F));
      
      // bottom boundary
      GameObject bottomBoundary = new GameObject ("Bottom Boundary");
      bottomBoundary.transform.parent = createdBoundaries.transform;
      boxCollider = bottomBoundary.AddComponent (typeof(BoxCollider)) as BoxCollider;
      boxCollider.size = new Vector3 (bounds.width + colliderThickness * 2.0F, colliderThickness, colliderThickness);
      boxCollider.center = new Vector3 (bounds.x + bounds.width * 0.5F, 0.0F, -(bounds.yMax - colliderThickness * 0.5F));

    }

  }
}