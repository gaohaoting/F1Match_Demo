using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRecorder : MonoBehaviour
{
    public List<TransformData> recordedTransforms = new List<TransformData>();
    public float recordInterval = 3f;
    private bool isRecording = false;

    public void StartRecording()
    {
        recordedTransforms.Clear();
        StartCoroutine(RecordRoutine());
    }

    public void StopRecording()
    {
        isRecording = false;
        StopAllCoroutines();
    }

    IEnumerator RecordRoutine()
    {
        isRecording = true;
        while (isRecording)
        {
            recordedTransforms.Add(new TransformData(transform));
            yield return new WaitForSeconds(recordInterval);
        }
    }
}