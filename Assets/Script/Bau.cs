using UnityEngine;

public class Bau : MonoBehaviour
{
    [SerializeField] private int numeroBau;
    [SerializeField] private bool BauT = false;
    [Header("Caso Trancado,Defina o Sprite de aviso")]
    [SerializeField] private Sprite spriteAvisoPorta;
    private Animator animator;
    private Avisos avisoPorta;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (BauT)
        {
            avisoPorta = GetComponent<Avisos>();
        }
    }
    public void AbrirBau(int nChave = 0)
    {
        if (nChave == 0 && !BauT)
        {
            animator.SetTrigger("abrir");
        }
        else if (nChave == numeroBau && BauT)
        {
            animator.SetTrigger("abrir");
            BauT = false;
            avisoPorta.DefineTroca(spriteAvisoPorta, "Bau Destrancado", Color.green);
        }
    }
    public bool BauTrancado()
    {
        return BauT;
    }
}
