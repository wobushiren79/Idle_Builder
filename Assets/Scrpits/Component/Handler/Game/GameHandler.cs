using UnityEditor;
using UnityEngine;

public class GameHandler : BaseHandler<GameManager>
{
    public GameDataHandler handler_GameData;
    public GameModelHandler handler_GameModel;

    public UIManager manager_UI;

    private void Start()
    {
        InitData();
    }

    public void InitData()
    {
        //打开UI
        manager_UI.OpenUI(UIEnum.GameMain);
        //加载模型
        UserModelDataBean userModelData = handler_GameData.GetUserData().GetFirstUnlockModel();
        if (userModelData != null)
        {
            handler_GameModel.LoadModel(userModelData, null);
        }
        else
        {

        }
    }

}