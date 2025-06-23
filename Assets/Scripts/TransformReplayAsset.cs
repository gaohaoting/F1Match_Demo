using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TransformReplayData", menuName = "Replay/Transform Data Asset")]
public class TransformReplayAsset : ScriptableObject
{
    public List<TransformData> transforms;
}