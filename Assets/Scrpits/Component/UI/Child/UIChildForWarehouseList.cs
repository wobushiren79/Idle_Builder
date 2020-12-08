using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIChildForWarehouseList : BaseUIChildComponent<UIGameMain>
{
    public ScrollGridVertical ui_List;
    public List<ModelPartInfoBean> listPartInfoData;
    public UserModelDataBean userModelData;

    private void Start()
    {
        ui_List.AddCellListener(OnCellForItem);
    }

    public override void Open()
    {
        base.Open();
        InitData();
    }

    public override void Close()
    {
        base.Close();
    }

    public void OnCellForItem(ScrollGridCell itemCell)
    {
        ModelPartInfoBean partInfo = listPartInfoData[itemCell.index];
        UIItemForWarehouseList itemCpt = itemCell.GetComponent<UIItemForWarehouseList>();
        itemCpt.SetData(partInfo, userModelData);
    }

    public void InitData()
    {
        UserDataBean userData = uiComponent.handler_GameData.GetUserData();
        userModelData = userData.GetFirstUnlockModel();
        if (userModelData == null)
        {
            ui_List.SetCellCount(0);
            ui_List.RefreshAllCells();
            return;
        }
           
        Action<ModelInfoBean> callBack = (data) =>
        {
            listPartInfoData = data.listPartData;
            ui_List.SetCellCount(listPartInfoData.Count);
            ui_List.RefreshAllCells();
        };
        uiComponent.handler_GameModel.GetModelInfoById(userModelData.modelId,callBack);
    }

}