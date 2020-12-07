using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIChildForMainFunction : BaseUIChildComponent<UIGameMain>
{
    public Button ui_AddMoney;
    public Button ui_Warehouse;
    public Button ui_Blueprint;

    private void Start()
    {
        if (ui_AddMoney)
            ui_AddMoney.onClick.AddListener(OnClickForAddMoney);
        if (ui_Warehouse)
            ui_Warehouse.onClick.AddListener(OnClickForWarehouse);
        if (ui_Blueprint)
            ui_Blueprint.onClick.AddListener(OnClickForBlueprint);
    }

    /// <summary>
    /// 点击-增加金钱
    /// </summary>
    public void OnClickForAddMoney()
    {

    }

    /// <summary>
    /// 点击-仓库
    /// </summary>
    public void OnClickForWarehouse()
    {

    }

    /// <summary>
    /// 点击-蓝图
    /// </summary>
    public void OnClickForBlueprint()
    {

    }

}