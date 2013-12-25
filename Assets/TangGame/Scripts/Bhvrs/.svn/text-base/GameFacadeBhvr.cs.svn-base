/**
 * Created by emacs
 * Date: 2013/10/23
 * Author: xbhuang
 */

using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TangGame.View;


namespace TangGame
{
  public class GameFacadeBhvr : MonoBehaviour
  {

    IFacade facade;

    void Start()
    {
      facade = Facade.Instance;
      RegisterMediators();
    }

    void OnDestroy()
    {
      RemoveMediators();
    }

    

    private void RegisterMediators()
    {
      facade.RegisterMediator( new MainGameMediator(gameObject) );
    }

    private void RemoveMediators()
    {
      facade.RemoveMediator(MainGameMediator.NAME);
    }
    

  }
}