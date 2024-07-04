using UnityEngine;

public class smoothCameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float sensitivity;
    public float camerasize;
    void Start()
    {
        camerasize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp
            (transform.position, objectToFollow.transform.position + offset + 
                  new Vector3(0, Input.GetAxis("Vertical")*sensitivity), speed*Time.fixedDeltaTime);
        Camera.main.orthographicSize = Mathf.Abs(Input.GetAxis("Vertical"))+camerasize;
    }
}
