/**
 *
 * Created by emacs
 *
 * Date: 2013/9/26
 * Author: zzc
 */

namespace TangScene
{
  public class ResourceUtils
  {

    public static string GetSceneName(int sceneId)
    {
      return "scene_" + sceneId;
    }

    public static string GetSceneAssetBundleFilePath( int sceneId )
    {
      return Tang.ResourceUtils.GetAbFilePath( GetSceneName(sceneId) );
    }

    public static string GetSceneConfigFilePath( int sceneId )
    {
      return Tang.ResourceUtils.GetXmlFilePath("scene_" + sceneId);
    }
  }
}