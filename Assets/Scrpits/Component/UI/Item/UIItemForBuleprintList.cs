using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIItemForBuleprintList : BaseUIItem<UIGameMain>
{
    public Button ui_BtUnLock;
    public Text ui_TvName;

    public ModelInfoBean modelInfo;
    public void Start()
    {
        if (ui_BtUnLock)
            ui_BtUnLock.onClick.AddListener(OnClickForUnlock);
    }

    public void SetData(ModelInfoBean modelInfo)
    {
        this.modelInfo = modelInfo;
        SetName(modelInfo.name + "(" + modelInfo.unlock_money + ")");
    }

    /// <summary>
    /// 点击解锁
    /// </summary>
    public void OnClickForUnlock()
    {
        UserDataBean userData = uiComponent.handler_GameData.GetUserData();
        bool isPay = userData.PayMoney(modelInfo.unlock_money);
        if (isPay)
        {
            //添加解锁数据
            UserModelDataBean userModelData = userData.AddUnLockModel(modelInfo.id);
            //设置为当前显示
            userData.SetFirstUnlockModel(userModelData);
            //加载模型
            uiComponent.handler_GameModel.LoadModel(userModelData,null);
        }
        else
        {
            LogUtil.Log("支付失败，没有足够的金钱");
        }
    }

    public void SetName(string name)
    {
        if (ui_TvName)
        {
            ui_TvName.text = name;
        }
    }
}