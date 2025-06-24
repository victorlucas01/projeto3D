using UnityEngine;

public class MachadoJogado : MonoBehaviour
{
    [SerializeField] private int dano;
    [SerializeField] private GameObject destroyMachadoPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(destroyMachadoPrefab, gameObject.transform.position, gameObject.transform.rotation);
        GetComponent<ParticleSystem>().Stop();
        Destroy (this.gameObject);
    }

    

}
