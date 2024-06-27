using UnityEngine;

public class saver : MonoBehaviour
{
    [SerializeField] private savedPosition pos;
    [SerializeField] private AudioSource saveSound;
    [SerializeField] private PlayerControllerPlatformer player;
    private void FixedUpdate()
    {
        if (transform.position != pos.position && Vector3.Distance(transform.position, player.transform.position) <2 )
        {
            pos.position = transform.position;
            saveSound.Play();
        }
    }
}
