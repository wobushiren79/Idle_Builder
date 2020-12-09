using UnityEditor;
using UnityEngine;

public class GameModelCpt : BaseMonoBehaviour
{
    public GameModelControl gameModelControl;
    public GameModelProgress gameModelProgress;

    private void Awake()
    {
        gameModelControl = CptUtil.AddCpt<GameModelControl>(gameObject);
        gameModelProgress = CptUtil.AddCpt<GameModelProgress>(gameObject);
    }

    public void SetData(UserModelDataBean userModelData, ModelInfoBean modelInfo)
    {
        gameModelProgress.SetData(userModelData, modelInfo);
    }

    public void SetPartProgress(string partName,float pro)
    {
        gameModelProgress.SetProgress(partName, pro);
    }

}