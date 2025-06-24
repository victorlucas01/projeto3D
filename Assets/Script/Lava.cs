using UnityEngine;

public class Lava : MonoBehaviour

{
    [SerializeField] private float speedY = 3.5f;
    [SerializeField] private float speedX = 3.5f;
    MeshRenderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset = new Vector2(
                                        speedX * Time.timeSinceLevelLoad,
                                        speedY * Time.timeSinceLevelLoad);
    }
}
