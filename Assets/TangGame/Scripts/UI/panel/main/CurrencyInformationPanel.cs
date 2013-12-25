using UnityEngine;
using System.Collections;
using nh.ui.cache;

namespace nh.ui.main
{
public class CurrencyInformationPanel : XBPanel
{
    public new const string NAME="CurrencyInformationPanel";
    public UILabel currency1;
    CurrencyInformationPanelMediator mediator;
    int lastMoneyUpDated=-1;
    void Start()
    {
        mediator=new CurrencyInformationPanelMediator(this);
        PanelCache.MainPanelTable.Add(NAME,mediator);
    }
    void Update()
    {
        this.MoenyUpDatedListener();
    }
    /// <summary>
    /// 货币更新监听
    /// </summary>
    private void MoenyUpDatedListener()
    {
        if(PlayerCache.player.MoenyUpDated(ref lastMoneyUpDated))
        {
            mediator.ReIngot();
        }
    }
    public void SetCurrency1Text(string currency,long num)
    {
        this.currency1.text="["+NGUITools.EncodeColor(Color.red)+"]"+currency+":"+num.ToString()+"[-]";
    }
}
}
