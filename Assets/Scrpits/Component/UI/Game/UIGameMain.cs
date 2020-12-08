using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class UIGameMain : BaseUIComponent 
{
    public UIChildForMainFunction ui_MainFunction;
    public UIChildForBlueprintList ui_BlueprintList;
    public UIChildForWarehouseList ui_WarehouseList;

    public Text ui_TvMoney;

    public GameDataHandler handler_GameData;
    public GameModelHandler handler_GameModel;

    private void Update()
    {
        UserDataBean userData = handler_GameData.GetUserData();
        SetMoney(userData.GetUserMoney());
    }

    /// <summary>
    /// 设置显示金钱
    /// </summary>
    /// <param name="money"></param>
    public void SetMoney(long money)
    {
        if (ui_TvMoney)
            ui_TvMoney.text = money + "";
    }

    /// <summary>
    /// 展示蓝图列表
    /// </summary>
    public void ShowBlueprintList(bool isShow)
    {
        if(isShow)
            ui_BlueprintList.Open();
        else
            ui_BlueprintList.Close();
    }

    /// <summary>
    /// 展示蓝图列表
    /// </summary>
    public void ShowWarehouseList(bool isShow)
    {
        if (isShow)
            ui_WarehouseList.Open();
        else
            ui_WarehouseList.Close();
    }

}