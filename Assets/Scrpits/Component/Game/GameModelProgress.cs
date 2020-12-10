using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameModelProgress : BaseMonoBehaviour
{
    public Dictionary<string, List<Material>> mapMaterialForModel = new Dictionary<string, List<Material>>();
    public int dissolveAmountId;
    protected string m_DissolveAmount = "_DissolveAmount";

    public void SetData(UserModelDataBean userModelData, ModelInfoBean modelInfo)
    {
        if (modelInfo == null)
            return;
        if (userModelData == null)
            return;
        dissolveAmountId = Shader.PropertyToID(m_DissolveAmount);
        mapMaterialForModel.Clear();
        Texture textureDisolveGuide = Resources.Load("Texture/noise_1") as Texture;
        if (!CheckUtil.ListIsNull(modelInfo.listPartData))
        {
            for (int i = 0; i < modelInfo.listPartData.Count; i++)
            {
                ModelPartInfoBean partInfo = modelInfo.listPartData[i];
                Renderer itemRenderer = CptUtil.GetCptInChildrenByName<Renderer>(gameObject, partInfo.part_name);
                //获取所有的Material
                List<Material> listMaterial = new List<Material>();
                itemRenderer.GetMaterials(listMaterial);
                //获取用户进度
                UserModelPartDataBean userModelPartData = userModelData.GetUserPartDataById(partInfo.id);
                float pro = 0;
                if (userModelPartData != null)
                {
                    pro = userModelPartData.GetProgress(partInfo.max_level);
                }
                //重新设置所有的shader
                foreach (Material itemMaterial in listMaterial)
                {
                    Texture itemTexture = itemMaterial.GetTexture("_MainTex");
                    if (itemTexture)
                    {
                        itemMaterial.shader = Shader.Find("ASESampleShaders/Community/DissolveBurnWithFire");
                        itemMaterial.SetTexture("_Albedo", itemTexture);
                        itemMaterial.SetTexture("_Normal", itemTexture);
                        itemMaterial.SetTexture("_BurnRamp", itemTexture);
                        itemMaterial.SetFloat("_MaskClipValue", 0.5f);
                    }
                    else
                    {
                        Color color = itemMaterial.GetColor("_Color");
                        itemMaterial.shader = Shader.Find("ASESampleShaders/Community/DissolveBurn_01");
                        itemMaterial.SetFloat("_Cutoff", 0.5f);
                        itemMaterial.SetColor("_MainColor", color);
                    }
                    itemMaterial.SetTexture("_DisolveGuide", textureDisolveGuide);
                    itemMaterial.SetFloat(dissolveAmountId, 1 - pro);
                }
                if (!mapMaterialForModel.ContainsKey(partInfo.part_name))
                {
                    mapMaterialForModel.Add(partInfo.part_name, listMaterial);
                }
            }
        }
    }

    /// <summary>
    /// 设置对应部位进度
    /// </summary>
    /// <param name="partName"></param>
    /// <param name="pro"></param>
    public void SetProgress(string partName, float pro)
    {
        if (mapMaterialForModel.TryGetValue(partName, out List<Material> listMaterial))
        {
            for (int i = 0; i < listMaterial.Count; i++)
            {
                Material itemMaterial = listMaterial[i];
                itemMaterial.SetFloat(dissolveAmountId, 1 - pro);
            }
        }
    }

}