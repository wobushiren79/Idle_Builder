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
    public List<UserModelDataBean> listUnlockModel = new List<UserModelDataBean>();

    /// <summary>
    /// 支付金钱
    /// </summary>
    /// <param name="payMoney"></param>
    /// <returns></returns>
    public bool PayMoney(long payMoney)
    {
        long tempMoney = money - payMoney;
        if (tempMoney < 0)
        {
            return false;
        }
        else
        {
            money -= payMoney;
            return true;
        }
    }

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
    /// 获取用户金钱
    /// </summary>
    /// <returns></returns>
    public long GetUserMoney()
    {
        return money;
    }

    /// <summary>
    /// 增加已解锁模型
    /// </summary>
    /// <param name="modelId"></param>
    public UserModelDataBean AddUnLockModel(long modelId)
    {
        if (listUnlockModel == null)
            listUnlockModel = new List<UserModelDataBean>();
        bool hasData = CheckHasModel(modelId, out UserModelDataBean userModelData);
        if (hasData)
        {
            return userModelData;
        }
        else
        {
            UserModelDataBean modelData = new UserModelDataBean(modelId);
            listUnlockModel.Add(modelData);
            return modelData;
        }
    }

    /// <summary>
    /// 检测是否有模型
    /// </summary>
    /// <param name="modelId"></param>
    /// <returns></returns>
    public bool CheckHasModel(long modelId, out UserModelDataBean userModelData)
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

    /// <summary>
    /// 获取第一个解锁的模型
    /// </summary>
    /// <returns></returns>
    public UserModelDataBean GetFirstUnlockModel()
    {
        if (CheckUtil.ListIsNull(listUnlockModel))
        {
            return null;
        }
        else
        {
            return listUnlockModel[0];
        }
    }

    /// <summary>
    /// 设置显示模型
    /// </summary>
    /// <param name="userModelData"></param>
    public void SetFirstUnlockModel(UserModelDataBean userModelData)
    {
        if (listUnlockModel == null)
            listUnlockModel = new List<UserModelDataBean>();
        if (listUnlockModel.Contains(userModelData))
        {
            listUnlockModel.Remove(userModelData);
        }
        listUnlockModel.Insert(0, userModelData);
    }
}