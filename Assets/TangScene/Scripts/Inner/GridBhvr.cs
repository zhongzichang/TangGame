/*
 * Created by emacs
 * Date: 2013/9/12
 * Author: zzc
 */
using UnityEngine;
using TangUtils;

namespace TangScene
{
	[ExecuteInEditMode]
  public class GridBhvr : MonoBehaviour
	{

		public delegate void GridChange (Point grid);

		public GridChange gridChangeHandler;
		public Point grid;
    
		void Start ()
		{
			grid = Grid.FromPosition (transform.localPosition);
		}

		void Update ()
		{
			Point current = Grid.FromPosition (transform.localPosition);
			if (!grid.Equals (current)) {

				grid = current;

				if (gridChangeHandler != null)
					gridChangeHandler (grid);

			}
		}
		void OnGUI ()
		{
			GUI.Label (new Rect (Screen.width - 120, Screen.height - 200, 100, 60), 
		 " x:" + grid.x + " y:"+ grid.y);

		}

	}
}