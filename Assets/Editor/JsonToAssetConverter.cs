#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;

public class JsonToAssetConverter
{
    [MenuItem("Tools/Import TransformData JSON to Asset")]
    public static void ConvertJsonToAsset()
    {
        // 1. 选择 JSON 文件
        string jsonPath = EditorUtility.OpenFilePanel("Select JSON File", "", "json");
        if (string.IsNullOrEmpty(jsonPath)) return;

        // 2. 读取 JSON 内容
        string json = File.ReadAllText(jsonPath);
        TransformDataListWrapper wrapper = JsonUtility.FromJson<TransformDataListWrapper>(json);

        // 3. 创建 ScriptableObject 并赋值
        TransformReplayAsset asset = ScriptableObject.CreateInstance<TransformReplayAsset>();
        asset.transforms = wrapper.transforms;

        // 4. 保存为 .asset 文件
        string savePath = EditorUtility.SaveFilePanelInProject(
            "Save Asset",
            "TransformReplayData",
            "asset",
            "Save the ScriptableObject asset"
        );

        if (!string.IsNullOrEmpty(savePath))
        {
            AssetDatabase.CreateAsset(asset, savePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
            Debug.Log("TransformReplayAsset created at: " + savePath);
        }
    }
}
#endif