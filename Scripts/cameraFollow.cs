using UnityEngine;
using UnityEngine.Rendering;

public class cameraFollow : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform target; 
    [SerializeField] private Camera cam;
    //[SerializeField] private float rotationSpeed;
    [SerializeField] private float direction;
    [SerializeField] private float zoomSpeed = 0.1f;
    private Vector3 previousPosition;

    private void Awake()
    {
        offset = transform.position - target.position;
    }


    private void LateUpdate()
    {
        cam.transform.position = target.position + offset;
        // если что, этот код нужен чтобы вращать камеру вокруг персонажа, я его закоментировал за ненадобностью
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.RotateAround(target.position, new Vector3(0, rotationSpeed * Time.deltaTime, 0), rotationSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{

        //    transform.RotateAround(target.position, new Vector3(0, rotationSpeed * Time.deltaTime, 0), -rotationSpeed * Time.deltaTime);
        //}
        offset = transform.position - target.position;
        if (cam.orthographic)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        }
        else
        {
            cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        }
    }
}
