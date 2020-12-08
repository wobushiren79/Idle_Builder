using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIItemForWarehouseList : BaseUIItem<UIGameMain>
{
    public Button ui_BtUnLock;
    public Text ui_TvName;

    public ModelPartInfoBean modelPartInfo;
    public UserModelDataBean userModelData;
    public void Start()
    {
        if (ui_BtUnLock)
            ui_BtUnLock.onClick.AddListener(OnClickForUnlock);
    }

    public void SetData(ModelPartInfoBean modelPartInfo, UserModelDataBean userModelData)
    {
        this.modelPartInfo = modelPartInfo;
        this.userModelData = userModelData;
        SetName(modelPartInfo.name + "(" + modelPartInfo.unlock_money + "," + modelPartInfo.add_price + ")");
    }

    public void SetName(string name)
    {
        if (ui_TvName)
        {
            ui_TvName.text = name;
        }
    }


    /// <summary>
    /// 点击解锁
    /// </summary>
    public void OnClickForUnlock()
    {
        UserDataBean userData = uiComponent.handler_GameData.GetUserData();
        bool isPay = userData.PayMoney(modelPartInfo.unlock_money);
        if (isPay)
        {
            //添加解锁数据
            UserModelPartDataBean userModelPartData = userModelData.AddUnLockPart(modelPartInfo.id, modelPartInfo.add_price);
            //设置显示部件
        }
        else
        {
            LogUtil.Log("支付失败，没有足够的金钱");
        }
    }
}