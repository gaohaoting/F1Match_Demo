using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 5f;      // 移动速度
    public float LRmoveSpeeed = 2f;   // 左右移动速度
    public float lookSpeed = 2f;       // 鼠标灵敏度

    private float yaw = 0f;            // 水平旋转角度
    private float pitch = 0f;          // 垂直旋转角度
    private Vector3 moveDirection;     // 移动方向向量
    private bool isMouseLookActive = false; // 是否激活鼠标视角控制

    void Start()
    {
        // 初始化yaw值为当前物体的Y轴旋转角度，避免开始时意外旋转
        yaw = transform.eulerAngles.y;
        moveDirection = transform.forward; // 初始化移动方向为物体的前方
        
        // 锁定光标到游戏窗口中心并隐藏光标
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 更新鼠标右键状态
        isMouseLookActive = Input.GetMouseButton(1);
        
        HandleMovement();
        HandleMouseLook();
        
        // 按ESC键解锁光标
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A, D
        float vertical = Input.GetAxis("Vertical");     // W, S

        // 在本地坐标系中移动
        Vector3 moveVector = new Vector3(horizontal * LRmoveSpeeed, 0, vertical * moveSpeed);
        transform.Translate(moveVector * Time.deltaTime, Space.Self);
    }
    

    void HandleMouseLook()
    {
        // 只有按下鼠标右键时才控制视角
        if (isMouseLookActive) 
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;
            
            // 添加一个小阈值，忽略极小的鼠标移动
            if (Mathf.Abs(mouseX) > 0.001f || Mathf.Abs(mouseY) > 0.001f)
            {
                yaw += mouseX;
                //pitch -= mouseY;
                //pitch = Mathf.Clamp(pitch, -90f, 90f); // 限制上下转头幅度

                // 更新角色朝向
                transform.rotation = Quaternion.Euler(0f, yaw, 0f);
                
                // 更新移动方向向量
                moveDirection = transform.forward;
            }
        }
    }
}