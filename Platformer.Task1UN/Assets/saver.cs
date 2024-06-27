using UnityEngine;

public class saver : MonoBehaviour
{
    [SerializeField] private savedPosition pos;
    [SerializeField] private AudioSource saveSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.position != pos.position)
        {
            pos.position = transform.position;
            saveSound.Play();
        }
    }
}
