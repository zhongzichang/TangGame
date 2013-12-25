/*
 * Created by emacs
 * Date: 2013/9/13
 * Author: zzc
 */
using System.IO;
using System.Collections;
using UnityEngine;
using PureMVC.Patterns;
using TangGame.Xml;
using Tang;
using TangUtils;

namespace TangScene
{
  public class LevelBhvr : MonoBehaviour
  {

    public static LevelStatus status = LevelStatus.RUN;
    public static AssetBundle sceneAssetBundle
    {
      get;
      private set;
    }
    private static int sceneId = 0;


    #region Properties

    public static int SceneId
    {
      get
      {
        return sceneId;
      }
      set
      {
        if( sceneId != value && status == LevelStatus.RUN )
        {
          sceneId = value;
          status = LevelStatus.NEXT;
          Cache.Clear();
        }
      }
    }

    #endregion

    #region Private Method

    private void LoadNewLevel()
    {

      if( Game.sceneTable.ContainsKey( sceneId ) )
      {
        LoadSceneAssetBundle();
      }
      else
      {
        LoadSceneGameFile();
      }
    }

    // load scene asset bundle
    private void LoadSceneAssetBundle()
    {
      string filepath = ResourceUtils.GetSceneAssetBundleFilePath( sceneId );
      ResourceLoader.Enqueue( filepath, OnSceneAssetBundleFileLoaded, OnLoadFailure );
    }
    

    // load scene config file
    public void LoadSceneGameFile()
    {
      string filepath = ResourceUtils.GetSceneConfigFilePath( sceneId );
      ResourceLoader.Enqueue( filepath, OnSceneGameFileLoaded, OnLoadFailure );
    }

    // callback on scene config file loaded
    private void OnSceneGameFileLoaded(WWW www)
    {
      if( Game.debug )
        Debug.Log("OnSceneGameFileLoaded with sceneId " + sceneId + ".");

      TextReader textReader = new StringReader(TextUtil.GetTextWithoutBOM(www.bytes));
      Scene scene = XmlRootHelper.LoadXml<Scene>(textReader);
      Game.sceneTable.Add(scene.id, scene);
      LoadSceneAssetBundle();
    }
    
    private void OnLoadFailure(WWW www)
    {
      Debug.Log("failure load WWW " + www.url);
    }

    // callback on scene asset bundle laoded
    private void OnSceneAssetBundleFileLoaded(WWW www)
    {
      if( Game.debug )
        Debug.Log("OnSceneAssetBundleFileLoaded with sceneId " + sceneId + ".");
      sceneAssetBundle = www.assetBundle;

      status = LevelStatus.LOADED;

    }

    // init scene with scene config
    private IEnumerator InitScene()
    {

      string sceneName = ResourceUtils.GetSceneName(sceneId);

      AsyncOperation async = Application.LoadLevelAsync(sceneName);
      yield return async;
      
      Game.factory.BuildScene(Game.sceneTable[sceneId]);

      status = LevelStatus.READY;

    }

    #endregion


    #region Mono Method

    void Start()
    {
      status = LevelStatus.RUN;
    }

    void Update()
    {
      if( LevelStatus.NEXT == status )
      {
        PureMVC.Patterns.Facade.Instance.SendNotification(TangGame.NtftNames.TG_LOADING_START, SceneId);
        Facade.Instance.SendNotification(NtftNames.SCENE_LOAD_START, SceneId );

        // ready load new level
        status = LevelStatus.START;
        LoadNewLevel();

      }
      else if( LevelStatus.LOADED == status )
      {

        status = LevelStatus.INIT;
        StartCoroutine( InitScene() );
        
      }
      else if( LevelStatus.READY == status && ResourceLoader.UncompletedCount == 0 )
      {

        status = LevelStatus.RUN;
        Facade.Instance.SendNotification(NtftNames.SCENE_LOAD_COMPLETED , SceneId);

      }
      
    }

    #endregion

  }
}