using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIChildForBlueprintList : BaseUIChildComponent<UIGameMain>
{
    public ScrollGridVertical ui_List;
    public List<ModelInfoBean> listModelData;

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
        ModelInfoBean modelInfo= listModelData[itemCell.index];
        UIItemForBuleprintList itemCpt= itemCell.GetComponent<UIItemForBuleprintList>();
        itemCpt.SetData(modelInfo);
    }

    public void InitData()
    {
        Action<List<ModelInfoBean>> callBack = (listData) =>
        {
            listModelData = listData;
            ui_List.SetCellCount(listModelData.Count);
        };
        uiComponent.handler_GameModel.GetAllModel(callBack);
    }
}