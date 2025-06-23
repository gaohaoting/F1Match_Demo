using UnityEngine;
using System.Collections;
public class insectFlight : MonoBehaviour
{
    [SerializeField] private float radius = 1.5f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jitterAmount = 0.5f;
    [SerializeField] private float updateInterval = 1f;
    public float landingDistance = 1f;
    public GameObject targetGO;
    private Vector3 origin;
    private Vector3 targetPosition;
    private float timer;
    private bool isLanding;
    private bool landFun;
    public Collider indexFinger;
    void Start()
    {
        origin = transform.position;
        SetRandomTarget();
        isLanding = false;
        landFun = true;
    }

    void Update()
    {   
        if (isLanding)
        {
            LandOnTarget();
            return;
        }

        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            SetRandomTarget();
            timer = 0;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        AddJitter();
        if (landFun)
        {
            CheckForLanding();
        }
        FaceZAxis();
        //OnTriggerEnter(indexFinger);
    }

    void SetRandomTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        targetPosition = origin + randomDirection;
    }

    void AddJitter()
    {
        if (!isLanding)
        {
                transform.position += new Vector3(
                Random.Range(-jitterAmount, jitterAmount),
                Random.Range(-jitterAmount, jitterAmount),
                Random.Range(-jitterAmount, jitterAmount)
            ) * Time.deltaTime;
        }
    }
    void CheckForLanding()
    {
        if (landFun)
        {
            if (targetGO == null) return;
            float distance = Vector3.Distance(transform.position, targetGO.transform.position);
            if (distance <= landingDistance)
            {
                isLanding = true;
            }
        }
    }

    void LandOnTarget()
    {
        if (landFun)
        {
            Vector3 surfacePosition = targetGO.transform.position;
            surfacePosition.y += targetGO.transform.localScale.y / 2;
            float insectHeight = transform.localScale.y / 2;
            Vector3 targetPosition = new Vector3(surfacePosition.x, surfacePosition.y + insectHeight, surfacePosition.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            FaceZAxis2();
            // if (Vector3.Distance(transform.position, surfacePosition) < 0.2f)
            // {
            //     isLanding = false;
            //     //landFun = false;
            //     //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            // }
        }
    }

    public void LandOff()
    {
        landFun = false;
        isLanding = false;
        SetRandomTarget();
        StartCoroutine(RecoverLand());
    }

    IEnumerator RecoverLand()
    {
        yield return new WaitForSeconds(8);
        landFun = true;
    }
    void FaceZAxis()
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
    void FaceZAxis2()
    {
        Vector3 direction = targetGO.transform.position - transform.position;
        direction.y = 0;
        if (direction.sqrMagnitude > 0.01f)
        {   
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == indexFinger)
        {
            LandOff();
        }
    }
}
