using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

public class parallax : MonoBehaviour
{
    private Image _image;
    private Material _paralMaterial;
    [SerializeField] private Material parallaxMaterial;
    [SerializeField] private float currentOffset;
    [SerializeField] private float offsetMul = 0.01f;
    void Start()
    {
        _image = GetComponent<Image>();
        _paralMaterial = new Material(parallaxMaterial);
        _image.material = _paralMaterial;
    }


    void Update()
    {
        currentOffset = Camera.main.transform.position.x;
        _paralMaterial.mainTextureOffset = new Vector2(Camera.main.transform.position.x*offsetMul, 0);
    }
}
