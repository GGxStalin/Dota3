using UnityEngine;

public class DotaCamera : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 50;
    [SerializeField] float zoomSpeed = 50;
    [SerializeField] float zoomUpLimit = 15;
    [SerializeField] float zoomDownLimit = 75;
    [SerializeField] LayerMask layerMask;

    Transform target;
    Vector3 offset;
    Ray ray;
    RaycastHit hit;
    float rayDistance = 100;



    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = target.position - transform.position;
    }

    private void Update()
    {
        JustFollowTarget();
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    transform.position = target.position - offset;
        //}

        //float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        //float distanceToGround;

        //ray = Camera.main.ScreenPointToRay(transform.forward * rayDistance);

        //if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        //{
        //    distanceToGround = Vector3.Distance(transform.position, hit.point);
        //}
        //else
        //{
        //    distanceToGround = 50; //костыль
        //}

        //if (scrollValue > 0 && distanceToGround > zoomUpLimit)
        //{
        //    transform.Translate(transform.forward * Time.deltaTime * zoomSpeed, Space.World);
        //}
        //if (scrollValue < 0 && distanceToGround < zoomDownLimit)
        //{
        //    transform.Translate(transform.forward * Time.deltaTime * zoomSpeed * -1, Space.World);
        //}

    }

    private void JustFollowTarget()
    {
        transform.position = target.position - offset;
    }

    //void LateUpdate()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

    //    if (mousePos.x > 0.9f)
    //    {
    //        transform.Translate(transform.right * Time.deltaTime * cameraSpeed, Space.World);
    //    }
    //    if (mousePos.x < 0.1f)
    //    {
    //        transform.Translate(transform.right * Time.deltaTime * cameraSpeed * -1, Space.World);
    //    }
    //    if (mousePos.y > 0.9f)
    //    {
    //        transform.Translate((transform.forward + transform.up) * Time.deltaTime * cameraSpeed, Space.World);
    //    }
    //    if (mousePos.y < 0.1f)
    //    {
    //        transform.Translate((transform.forward + transform.up) * Time.deltaTime * cameraSpeed * -1, Space.World);
    //    }

    //}


}