using UnityEngine;
using UnityEngine.Events;

public class radius_unityaction : MonoBehaviour
{
    private PlayerControllerPlatformer plr;
    
    [SerializeField]private float radius = 2;
    [SerializeField]private bool done;
    public UnityEvent Action;
    private void Start()
    {
        plr = FindObjectOfType<PlayerControllerPlatformer>();
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(plr.transform.position, transform.position)<radius)
        {
            if (!done)
            {
                Action.Invoke();
                done = true;
            }
        }
    }
}
