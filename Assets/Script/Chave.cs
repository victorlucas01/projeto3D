using UnityEngine;

public class Chave : MonoBehaviour
{
    [SerializeField] private int numeroPorta;

    public int NumeroPorta()
    {
        return numeroPorta;
    }

    public void Pegarchave()
    {
        Destroy(gameObject);
    }
}
