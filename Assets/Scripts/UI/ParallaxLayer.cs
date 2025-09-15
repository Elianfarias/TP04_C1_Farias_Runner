using UnityEngine;

[ExecuteAlways]
public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;

    private float distance;
    Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void Update()
    {
        distance += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", Vector3.right * distance);
    }
}
