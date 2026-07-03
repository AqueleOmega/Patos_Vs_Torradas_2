using UnityEngine;
using UnityEngine.InputSystem;

public class BodyStateManager : MonoBehaviour
{
    public Animator head;
    public Vector2 input;

    public void Direção(InputAction.CallbackContext contexto)
    {
        input = contexto.ReadValue<Vector2>();
    }

    // Aqui definimos o currentState, que espera um concrete state derivado do
    // PlayerBaseState, por isso ele é "verde"
    BodyBaseState currentState;

    public BodyStateIdle IdleState;

    // Aqui nós estamos instanciando os nossos states e chamando eles de ---State
    // (ex.: IdleState, MoverState). Eles correspondem aos states que criamos,
    // quanto mais criamos, mais states adicionamos aqui

    public DirBState DireitaState;

    public EsqBState EsquerdaState;

    public CimBState CimaState;

    public BaiBState BaixoState;
    
    // Aqui em baixo, os novos states do boss, agora desmembrado em 2.
    //public BossStatePrepAtaque PrepAtaqueState = new BossStatePrepAtaque();
    //public BossStateAtaque AtaqueState = new BossStateAtaque();
    /*
    Se por um acaso do destino, meu boss agora tem um ataque forte, 
    eu colocaria aqui:

    public BossStatePrepAtaqueForte AtqForteState = new BossStatePrepAtaqueForte();

    Aí eu criaria o script de ataque forte como os outros states e voilá, consegui
    adicionar funcionalidade ao meu jogo em 5 minutos.
    Esse é (um dos) grande motivos de utilizarmos essa solução, a facilidade 
    de iteração. Como falei na primeira aula, programar pensando na frente.
    */

    void Start()
    {
        IdleState = new BodyStateIdle(head, this);

        DireitaState = new DirBState(head, this);
        EsquerdaState = new EsqBState(head, this);
        CimaState = new CimBState(head, this);
        BaixoState = new BaiBState(head, this);


    // Ao iniciar nosso script, definimos o state do boss como Idle. 
    currentState = IdleState;


        // Depois de definir o state do boss como idle, rodamos a função "EnterState();
        // que ele herda do "template" (BossBaseState).
        currentState.EnterState(this);

    }

    // Esse código tem o Start, Update e outros do MonoBehaviour.
    void Update()
    {
        // Aqui nós rodamos aquilo que está no "UpdateState" de nossos diferentes
        // states todo frame
        currentState.UpdateState(this);

        //Debug.Log(currentState);
    }
    
    //Estamos trazendo o OnTriggerEnter da Unity para cá, e lançando para nossos
    // states. Cada um deles tem um comportamento na colisão, apresentado na 
    // função "public override void OnTriggerEnter(BossStateManager boss)"
    void OnTriggerEnter2D(Collider2D collider2D){
        currentState.OnTriggerEnter(this, collider2D);
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }

    public void SwitchState(BodyBaseState state){
        // Aqui, a Unity espera um state (BossBaseState state)
        // Definiremos então nosso currentState para o state recebido
        currentState = state;

        // Depois de definir isso, rodamos a lógica de enterState, iniciando
        // nosso novo state.
        state.EnterState(this);
    }
}
