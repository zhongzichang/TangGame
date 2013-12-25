using UnityEngine;
using System.Collections;
using nh.ui.cache;
using nh.ui.mediator;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace nh.ui.main
{
public class ExpPanel : XBPanel
{
    public new const string NAME="ExpPanel";
    public UISlider expProgressBar;
		public UILabel expLabel;
    private ExpPanelMediator mediator;

		private float targetValue;
		private float curValue;
		private bool isPlayAni = false;
		private bool ingorn = false;
    long lastExp;
    void Start()
    {
        mediator=new ExpPanelMediator(this);
        PanelCache.MainPanelTable.Add(NAME,mediator);
		Facade.Instance.RegisterMediator(mediator);
    }
		public void UpdateShow(long exp, long expMax)
		{
			float f = (float)exp / expMax;
			expLabel.text = exp + "/" + expMax;
//			Debug.LogError("要设置的值为 " + f);
			targetValue = f;
			curValue = this.expProgressBar.value;
			if (curValue != f)
			{
				isPlayAni = true;
				if (f < curValue)
					ingorn = true;
			}
		}
		void Update()
		{	
			if (isPlayAni)
			{
				curValue += 0.01f;
				if (curValue >= 1)
				{
					curValue = 0;
					ingorn = false;
				}
				/**如果当前值大于目标值，并且已经播放过一个超出的动画了，就可以实际判断到达位置了*/
				if (curValue >= targetValue && !ingorn)
				{
					curValue = targetValue;
					isPlayAni = false;
					this.expProgressBar.value = curValue;
					return;
				}
				this.expProgressBar.value = curValue;

			}
		}

}
}
