using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Corner
{
    public int centerIndex;          // waypoint index of corner apex
    public float baseCornerSpeed;    // base corner speed
}

public class CarManager : MonoBehaviour
{
    
    [Header("Path & Car Settings")]
    public DOTweenPath carPath;
    private Tween pathTween;
    private Transform car;
    public float maxSpeed = 40f;

    [Header("Corner")]
    public List<Corner> corners;
    [Range(0.5f, 1.5f)] public float cornerSpeedMultiplier = 0.5f;

    [Header("Launch Settings")]
    public float launchDuration = 10f;      // Time to reach max speed
    public float turn1TriggerDistance = 30f; // When to start corner speed logic


    void Start()
    {
        car = carPath.transform;
        pathTween = carPath.GetTween();

        if (pathTween != null)
        {
            pathTween.SetSpeedBased();
            pathTween.timeScale = 0f; // start from full stop
            StartCoroutine(LaunchThenAdjustSpeed());
            // StartCoroutine(AdjustSpeed());
        }
        
    }

    IEnumerator LaunchThenAdjustSpeed()
    {
        float elapsed = 0f;

        while (elapsed < launchDuration)
        {
            elapsed += Time.deltaTime;
            float scale = Mathf.Lerp(0f, 1f, elapsed / launchDuration);
            pathTween.timeScale = scale;
            yield return null;
        }

        pathTween.timeScale = 1f;

        // Wait until car is near Turn 1 apex
        if (corners.Count > 0 && corners[0].centerIndex < carPath.wps.Count)
        {
            Vector3 turn1Pos = carPath.wps[corners[0].centerIndex];
            while (Vector3.Distance(car.position, turn1Pos) > turn1TriggerDistance)
            {
                yield return null;
            }
        }

        StartCoroutine(AdjustSpeed());
    }

    IEnumerator AdjustSpeed()
    {
        while (true)
        {
            float speed = GetAdjustedSpeed();
            pathTween.timeScale = speed / maxSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    float GetAdjustedSpeed()
    {
        float closestDist = float.MaxValue;
        float cornerSpeed = maxSpeed;

        foreach (var corner in corners)
        {
            if (corner.centerIndex >= carPath.wps.Count) continue;
            Vector3 cornerPos = carPath.wps[corner.centerIndex];
            float dist = Vector3.Distance(car.position, cornerPos);

            if (dist < closestDist && dist < 60f) // only slow near corner
            {
                closestDist = dist;
                float t = Mathf.InverseLerp(60f, 0f, dist); // 30 → 0 = approach
                float minSpeed = corner.baseCornerSpeed * cornerSpeedMultiplier;
                cornerSpeed = Mathf.Lerp(maxSpeed, minSpeed, t);
            }
        }

        return cornerSpeed;
    }
}