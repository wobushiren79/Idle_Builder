using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDataHandler : BaseHandler<GameDataManager>
{
    
    public enum NotifyForGameData
    {

    }

    protected override void Awake()
    {
        base.Awake();
        manager.InitUserData();
    }

    private void Start()
    {
        StartCoroutine(CoroutineForGameDataChange());
    }


    public long AddUserMoney(long money)
    {
        return manager.GetUserData().AddUserMoney(money);
    }

    /// <summary>
    /// 获取用户数据
    /// </summary>
    /// <returns></returns>
    public UserDataBean GetUserData()
    {
        return manager.GetUserData();
    }

    public IEnumerator CoroutineForGameDataChange()
    {
        while (gameObject)
        {
            yield return new WaitForSeconds(1);
            UserDataBean userData = GetUserData();
            if (!CheckUtil.ListIsNull(userData.listUnlockModel))
            {
                for (int i = 0; i < userData.listUnlockModel.Count; i++)
                {
                    UserModelDataBean itemModelData = userData.listUnlockModel[i];
                    if (!CheckUtil.ListIsNull(itemModelData.listUnlockPart))
                    {
                        for (int f = 0; f < itemModelData.listUnlockPart.Count; f++)
                        {
                            UserModelPartDataBean itemModelPartData = itemModelData.listUnlockPart[f];
                            userData.AddUserMoney(itemModelPartData.addPrice);
                        }
                    }
                }
            }
        }
    }

}
