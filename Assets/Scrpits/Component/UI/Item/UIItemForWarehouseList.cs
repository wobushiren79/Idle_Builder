using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIItemForWarehouseList : BaseUIItem<UIGameMain>
{
    public Button ui_BtUnLock;
    public Button ui_BtLevel;
    public Text ui_TvName;

    public ModelPartInfoBean modelPartInfo;
    public UserModelDataBean userModelData;
    public void Start()
    {
        if (ui_BtUnLock)
            ui_BtUnLock.onClick.AddListener(OnClickForUnlock);
        if (ui_BtLevel)
            ui_BtLevel.onClick.AddListener(OnClickForLevel);
    }

    public void SetData(ModelPartInfoBean modelPartInfo, UserModelDataBean userModelData)
    {
        this.modelPartInfo = modelPartInfo;
        this.userModelData = userModelData;
        SetName(modelPartInfo.name);
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
            UserModelPartDataBean userModelPartData = userModelData.AddUnLockPart(modelPartInfo.id, modelPartInfo.GetAddPrice(0));
            //设置显示部件

        }
        else
        {
            LogUtil.Log("解锁失败，没有足够的金钱");
        }
    }

    /// <summary>
    /// 点击-升级
    /// </summary>
    public void OnClickForLevel()
    {
        UserDataBean userData = uiComponent.handler_GameData.GetUserData();
        UserModelPartDataBean userModelPartData = userModelData.GetUserPartDataById(modelPartInfo.id);
        if (userModelPartData == null)
            return;
        long levelMoney = modelPartInfo.GetLevelUpMoney(userModelPartData.level);
        bool isPay = userData.PayMoney(levelMoney);

        if (isPay)
        {
            //升级
            int level = userModelPartData.LevelUp(1);
            //计算收益
            long addPrice = modelPartInfo.GetAddPrice(level);
            //增加收益
            userModelPartData.SetAddPrice(addPrice);
            //设置舰船显示进度
            uiComponent.handler_GameModel.SetPartProgress(modelPartInfo.part_name, userModelPartData.GetProgress(modelPartInfo.max_level));
        }
        else
        {
            LogUtil.Log("升级失败，没有足够的金钱");
        }
    }
}