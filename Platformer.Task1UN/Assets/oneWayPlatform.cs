using UnityEngine;

public class oneWayPlatform : MonoBehaviour
{
    private Transform player;
    private BoxCollider2D myCollider;
    void Start()
    {
        player = FindObjectOfType<PlayerControllerPlatformer>().transform;
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + 0.01f < player.position.y)
        {
            myCollider.enabled = true;
        }
        else
        {
            myCollider.enabled = false;
        }
    }
}
