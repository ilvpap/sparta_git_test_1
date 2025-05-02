using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 6f;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    //private bool isFlip;

    //private const string ismove = "IsMove"; // const 컴파일타입상수? readonly 런타입상수?
    private readonly int isMoveHash = Animator.StringToHash("IsMove"); 
    // 문자열 Hash => 고유 ID (파라미터 ID 값을 불러와 isMoveHash에 저장을 한다.)

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // 컴포넌트 중 가져오는 거
        animator = GetComponentInChildren<Animator>(); // GetComponents < 배열 (전체 다 가져옴)
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // GetAxis , GetAxisRaw
    // 입력 값이 부드럽게 변화 (가속/감속 느낌) 캐릭터가 점점 빨라지거나 멈출 때 자연스러움, 즉각적인 반응을 원할 때 사용(바로 -1, 0, 1 값 변환)
    // 빙판길에서 미끄러질 때의 느낌, 도보에서 걷는 느낌 
    // Input : 입력 클래스 (안 보이는 클래스? 하나의 세트.../ 입력 관련해서 처리해주는 클래스)
    // InputManager , InputSystem (Unity6부터 사용하기 시작함)

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // 정해져 있음 (move 단위벡터) 
        float moveY = Input.GetAxisRaw("Vertical");

        //new Animator().SetBool() // == new string("")
        Vector2 move = new Vector2(moveX, moveY).normalized; // Vector : 방향, 힘
        animator.SetBool(isMoveHash, move != Vector2.zero); //Set trigger 안 움직일 때 런 애니메이션 재생 X 만드는 구문?
        rigidBody.velocity = move * speed;
        
        // -1 이면 true 아니면 false 
        if(moveX != 0)
        {
            spriteRenderer.flipX = moveX < 0;
        }

        //isFlip = moveX == -1 ? true : false ;
        //if(moveX != 0)
        //spriteRenderer.flipX = isFlip;
        // bool = 기본 값은 false.. 불리언자료형........조건식....
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("MinigameScene");
        }
    }
}
