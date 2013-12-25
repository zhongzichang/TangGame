/**
* Created by emacs
* Date: 2013/10/19
* Author: zzc
*/
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

using nh.ui.mediator;

namespace TangGame.Home
{
	public class HomeFacadeBhvr : MonoBehaviour
	{
		IFacade facade;

		void Start ()
		{
			facade = Facade.Instance;
			RegisterMediators ();
		}

		void OnDestroy ()
		{
			RemoveMediators ();
		}

		private void RegisterMediators ()
		{
			facade.RegisterMediator (new HomeMediator (gameObject));
		}

		private void RemoveMediators ()
		{
			facade.RemoveMediator (HomeMediator.NAME);
		}
	}
}