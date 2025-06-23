using UnityEngine;

public class PenetrationSlowdown : MonoBehaviour
{
    public float K = 0.2f;  // 阻力系数
    public float n = 2.0f;  // 幂指数
    public float depth = 0f; // 当前穿透深度
    public Transform tissueTop; // 组织顶部参考点
    public Transform needleTip; // 穿刺物体的前端（比如针头）

    private Rigidbody rb;
    private bool isInsideTissue = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isInsideTissue)
        {
            // 计算插入深度
            depth = Mathf.Max(0f, tissueTop.position.y - needleTip.position.y);


            // 根据公式 v = K * D^(n/2) 计算最大速度
            float maxSpeed = K * Mathf.Pow(depth, n / 2f);
            Debug.Log("maxSpeed: " + maxSpeed);

            // 当前速度（竖直方向）
            Vector3 velocity = rb.velocity;
            if (velocity.y < -maxSpeed)
            {
                velocity.y = -maxSpeed; // 限制最大下降速度
                rb.velocity = velocity;
            }
        }
    }

    // 假设组织 B 有 Collider 且设置为触发器
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tissue"))
        {
            isInsideTissue = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tissue"))
        {
            isInsideTissue = false;
        }
    }
}