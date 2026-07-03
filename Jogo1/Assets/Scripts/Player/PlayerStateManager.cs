using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    public Animator head;
    public Vector2 input;

    public void Direção(InputAction.CallbackContext contexto)
    {
        input = contexto.ReadValue<Vector2>();
    }

    // Aqui definimos o currentState, que espera um concrete state derivado do
    // PlayerBaseState, por isso ele é "verde"
    PlayerBaseState currentState;

    public PlayerStateIdle IdleState;

    // Aqui nós estamos instanciando os nossos states e chamando eles de ---State
    // (ex.: IdleState, MoverState). Eles correspondem aos states que criamos,
    // quanto mais criamos, mais states adicionamos aqui

    public DirPState DireitaState;

    public EsqPState EsquerdaState;

    public CimPState CimaState;

    public BaiPState BaixoState;

    public DiagDirPState diagDirState;

    public DiagEsqPState diagEsqState;

    public DiagDirYPState diagDirYState;

    public DiagEsqYPState diagEsqYState;

    
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
        IdleState = new PlayerStateIdle(head, this);

        DireitaState = new DirPState(head);
        EsquerdaState = new EsqPState(head);
        CimaState = new CimPState(head);
        BaixoState = new BaiPState(head);
        diagDirState = new DiagDirPState(head);
        diagEsqState = new DiagEsqPState(head);
        diagDirYState = new DiagDirYPState(head);
        diagEsqYState = new DiagEsqYPState(head);

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

    public void SwitchState(PlayerBaseState state){
        // Aqui, a Unity espera um state (BossBaseState state)
        // Definiremos então nosso currentState para o state recebido
        currentState = state;

        // Depois de definir isso, rodamos a lógica de enterState, iniciando
        // nosso novo state.
        state.EnterState(this);
    }
}
