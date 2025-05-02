using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 6f;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    //private bool isFlip;

    //private const string ismove = "IsMove"; // const ������Ÿ�Ի��? readonly ��Ÿ�Ի��?
    private readonly int isMoveHash = Animator.StringToHash("IsMove"); 
    // ���ڿ� Hash => ���� ID (�Ķ���� ID ���� �ҷ��� isMoveHash�� ������ �Ѵ�.)

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // ������Ʈ �� �������� ��
        animator = GetComponentInChildren<Animator>(); // GetComponents < �迭 (��ü �� ������)
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // GetAxis , GetAxisRaw
    // �Է� ���� �ε巴�� ��ȭ (����/���� ����) ĳ���Ͱ� ���� �������ų� ���� �� �ڿ�������, �ﰢ���� ������ ���� �� ���(�ٷ� -1, 0, 1 �� ��ȯ)
    // ���Ǳ濡�� �̲����� ���� ����, �������� �ȴ� ���� 
    // Input : �Է� Ŭ���� (�� ���̴� Ŭ����? �ϳ��� ��Ʈ.../ �Է� �����ؼ� ó�����ִ� Ŭ����)
    // InputManager , InputSystem (Unity6���� ����ϱ� ������)

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // ������ ���� (move ��������) 
        float moveY = Input.GetAxisRaw("Vertical");

        //new Animator().SetBool() // == new string("")
        Vector2 move = new Vector2(moveX, moveY).normalized; // Vector : ����, ��
        animator.SetBool(isMoveHash, move != Vector2.zero); //Set trigger �� ������ �� �� �ִϸ��̼� ��� X ����� ����?
        rigidBody.velocity = move * speed;
        
        // -1 �̸� true �ƴϸ� false 
        if(moveX != 0)
        {
            spriteRenderer.flipX = moveX < 0;
        }

        //isFlip = moveX == -1 ? true : false ;
        //if(moveX != 0)
        //spriteRenderer.flipX = isFlip;
        // bool = �⺻ ���� false.. �Ҹ����ڷ���........���ǽ�....
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("MinigameScene");
        }
    }
}
