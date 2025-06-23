using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformReplayer : MonoBehaviour
{
    public TransformReplayAsset replayAsset; // 拖入 ScriptableObject
    public float interval = 3f;              // 每段动画时长
    public AnimationCurve easingCurve = AnimationCurve.Linear(0, 0, 1, 1); // 插值曲线

    public void StartReplay()
    {
        if (replayAsset == null || replayAsset.transforms.Count < 2) return;
        StartCoroutine(SmoothReplayRoutine());
    }

    IEnumerator SmoothReplayRoutine()
    {
        List<TransformData> dataList = replayAsset.transforms;

        for (int i = 0; i < dataList.Count - 1; i++)
        {
            TransformData start = dataList[i];
            TransformData end = dataList[i + 1];

            float elapsed = 0f;
            while (elapsed < interval)
            {
                float t = elapsed / interval;
                t = easingCurve.Evaluate(t); // 可选：使用缓动曲线

                // 插值计算位置、旋转、缩放
                transform.position = Vector3.Lerp(start.position, end.position, t);
                transform.rotation = Quaternion.Slerp(start.rotation, end.rotation, t);
                transform.localScale = Vector3.Lerp(start.scale, end.scale, t);

                elapsed += Time.deltaTime;
                yield return null;
            }

            // 确保最后一帧对齐
            end.ApplyTo(transform);
        }
    }
}