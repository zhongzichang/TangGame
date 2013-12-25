using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.mediator;
using TangGame.Net;
using TangGame;

namespace nh.ui.main
{
public class MapButtonPanel : XBPanel
{
    public new const string NAME="MapButtonPanel";
    public UILabel currentMapName;
    public UILabel serverTime;
    public UIButton smallMapButton;
		private MapButtonPanelMediator mediator;
    void Start()
    {
//			PanelCache.MainPanelTable.Add(NAME,this);
			mediator = new MapButtonPanelMediator(this);
			Facade.Instance.RegisterMediator(mediator);
			HeroNew hero = ActorCache.GetLeadingHero();
			if (hero != null)
				this.UpdateShow(hero.mapName);
    }
		public void UpdateShow(string mapName)
		{

			currentMapName.text = mapName;
		}
}
}
