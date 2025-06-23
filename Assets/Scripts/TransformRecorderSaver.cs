using UnityEngine;
using System.IO;

public class TransformRecorderSaver : MonoBehaviour
{
    public TransformRecorder recorder; // 拖入你的 Recorder

    public void SaveToJson()
    {
        TransformDataListWrapper wrapper = new TransformDataListWrapper();
        wrapper.transforms = recorder.recordedTransforms;

        string json = JsonUtility.ToJson(wrapper, true);
        string path = Path.Combine(Application.persistentDataPath, "transform_record.json");

        File.WriteAllText(path, json);
        Debug.Log("Saved transform data to " + path);
    }
}