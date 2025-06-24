using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour

{
    [SerializeField] private int Vida = 100;
    [SerializeField] private int Mana = 100;
    [SerializeField] private Slider manaIndicador;
    [SerializeField] private Slider vidaIndicador;
    private bool estaVivo = true;
    private bool levarDano = true;
    private PlayerMoviment pMove;
    private bool podeRecarregarMana = true;

    
    void Start()
    {
        ProcuraReferencia();

        pMove = GetComponent<PlayerMoviment>();

    }
    void Update()
    {
        ProcuraReferencia();
        
    }
    private void ProcuraReferencia()
    {
        if (manaIndicador == null)
        {
            manaIndicador = GameObject.Find("Mana").GetComponent<Slider>();
            manaIndicador.maxValue = 100;
            manaIndicador.value = Mana;
        }

        if (vidaIndicador == null)
        {
            vidaIndicador = GameObject.Find("Vida").GetComponent<Slider>();
            vidaIndicador.maxValue = 100;
            vidaIndicador.value = Vida;
        }
        if (pMove == null)
        {
              pMove = GetComponent<PlayerMoviment>();
        } 

        
    }

    public bool EstaVivo()
    {
        return estaVivo;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fatal") && estaVivo && levarDano)
        {
            StartCoroutine(LevarDano(10));
        }
    }

    IEnumerator LevarDano(int dano)
    {
        levarDano = false;

        if (Vida > 0)
        {
            pMove.Hit(); // Chama o método Hit do PlayerMovement para executar a animação de dano
            Vida -= dano;
            vidaIndicador.value = Vida;
            VerificarVida();
            yield return new WaitForSeconds(0.5f);
            levarDano = true;
        }
    }

    private void VerificarVida()
    {
        if (Vida <= 0)
        {
            Vida = 0;
            estaVivo = false;
        }
    }

    public void UsarMana()
    {
        Mana -= 10;
        manaIndicador.value = Mana;
        if (podeRecarregarMana)
        {
            StartCoroutine("RecarregaMana");
        }
    }
    public void CargaMana(int carga)
    {
        Mana += carga;
        manaIndicador.value += Mana;
        if(Mana > 100)
        {
            Mana = 100;
            manaIndicador.value = Vida;
        }
    }
    public void CargaVida(int carga)
    {
        Mana += carga;
        manaIndicador.value += Vida;
        if (Mana > 100)
        {
            Mana = 100;
            manaIndicador.value = Vida;
        }
    }
    public int GetMana()
    {
        return Mana;
    }

    IEnumerable RecarregaMana()
    {
        podeRecarregarMana = false;
        while (Mana < 100)
        {
            Mana += 5;
            manaIndicador.value = Mana;
            yield return new WaitForSeconds(0.1f);
        }
        Mana = 100;
        podeRecarregarMana = true;
    }
}