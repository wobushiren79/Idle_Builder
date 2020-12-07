using UnityEditor;
using UnityEngine;

public class UserDataService : BaseDataStorageImpl<UserDataBean>
{
    private readonly string mSaveFileName;

    public UserDataService()
    {
        mSaveFileName = "UserData";
    }

    /// <summary>
    /// 查询游戏配置数据
    /// </summary>
    /// <returns></returns>
    public UserDataBean QueryData()
    {
        return BaseLoadData(mSaveFileName);
    }

    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="gameConfig"></param>
    public void UpdateData(UserDataBean userData)
    {
        BaseSaveData(mSaveFileName, userData);
    }
}