using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class UserDataBean
{
    //总计金钱
    public long money;
    //已解锁模型
    public List<UserModelDataBean> listUnlockModel;

    /// <summary>
    /// 增加用户金钱
    /// </summary>
    /// <param name="addMoney"></param>
    /// <returns></returns>
    public long AddUserMoney(long addMoney)
    {
        money += addMoney;
        if (money < 0)
        {
            money = 0;
        }
        return money;
    }

    /// <summary>
    /// 增加已解锁模型
    /// </summary>
    /// <param name="modelId"></param>
    public bool AddUnLockModel(long modelId)
    {
        if (listUnlockModel == null)
            listUnlockModel = new List<UserModelDataBean>();
        bool hasData = CheckHasModel(modelId, out UserModelDataBean userModelData);
        if (hasData)
        {
            return false;
        }
        else
        {
            UserModelDataBean modelData = new UserModelDataBean(modelId);
            listUnlockModel.Add(modelData);
            return true;
        }
    }

    /// <summary>
    /// 检测是否有模型
    /// </summary>
    /// <param name="modelId"></param>
    /// <returns></returns>
    public bool CheckHasModel(long modelId,out UserModelDataBean userModelData)
    {
        userModelData = null;
        for (int i = 0; i < listUnlockModel.Count; i++)
        {
            UserModelDataBean itemModelData = listUnlockModel[i];
            if (modelId == itemModelData.modelId)
            {
                userModelData = itemModelData;
                return true;
            }
        }
        return false;
    }
}