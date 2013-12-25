/**
 * Created by emacs
 * Date: 2013/10/19
 * Author: zzc
 */
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangGame
{
	public class WelcomeFacadeBhvr : MonoBehaviour
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
			facade.RegisterMediator (new WelcomeMediator (gameObject));
		}

		private void RemoveMediators ()
		{
			facade.RemoveMediator (WelcomeMediator.NAME);
		}

	}
}