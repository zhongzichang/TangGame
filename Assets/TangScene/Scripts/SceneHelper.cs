/**
 * scene helper
 *
 * Date: 2013/11/23
 * Author: zzc
 */

namespace TangScene
{
  public class SceneHelper
  {

    /// <summary>
    ///   获取当前场景的指定传送门
    /// </summary>
    public static Portal GetPortal(int portalId)
    {
      if( Game.sceneTable.ContainsKey( LevelBhvr.SceneId ) )
	{
	  Scene scene = Game.sceneTable[ LevelBhvr.SceneId ];
	  foreach( TsObject tsobj in scene.objs )
	    {
	      if( tsobj is Portal)
		{
		  Portal portal = tsobj as Portal;
		  if( portal.baseId == portalId )
		    return portal;
		}
	    }
	}
      return null;
    }
  }
}