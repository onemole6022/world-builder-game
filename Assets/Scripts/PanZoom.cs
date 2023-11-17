using UnityEngine;

public class PanZoom : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;
    Vector3 touchStart;
    [SerializeField] float zoomOutMin = 1;
    [SerializeField] float zoomOutMax = 8;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30.0f));
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f * zoomSpeed);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30.0f));
            //print("origin " + touchStart + "New Pos " + cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20.0f)));
            if (!GameManager.Instance.isUIDragging)
            {
                cam.transform.position += new Vector3(direction.x, 0, direction.z);

            }
            print(!GameManager.Instance.isUIDragging);
        }
        //zoom(Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetMouseButtonUp(0))
        {
            touchStart = Vector3.zero;
        }
    }

    void zoom(float increment)
    {
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - increment, zoomOutMin, zoomOutMax);
    }
}