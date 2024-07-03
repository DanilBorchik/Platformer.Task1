using UnityEngine;

public class stepSound : MonoBehaviour
{
    [SerializeField] private AudioSource stepsound;
    public void stepYouMF()
    {
        stepsound.Play();
    }
}
