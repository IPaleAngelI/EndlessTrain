using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject camTarget;

    private Vector3 previousPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = new Vector3();

            cam.transform.Rotate(new Vector3(0, 1, 0), direction.y * 180, Space.World);

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
