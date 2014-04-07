using UnityEngine;
using UnityEditor;

using Tang;

namespace TangScene
{
  public class CharacterCreateUtils
  {
    [MenuItem ("TangScene/Create Hero")]
    public static void CreateHero ()
    {
     
      if (Selection.objects != null) {
     
        foreach (Object obj in Selection.objects) {
         
          if (obj is GameObject) {

            GameObject gobj = obj as GameObject;

            SpriteAnimation spriteAnimation = gobj.GetComponent<SpriteAnimation> ();
            if (spriteAnimation != null) {

              GameObject hero = new GameObject ();

	      hero.AddComponent<ActorBhvr>();
             
             

            }
          }
        }
      }
    }
  }
}

