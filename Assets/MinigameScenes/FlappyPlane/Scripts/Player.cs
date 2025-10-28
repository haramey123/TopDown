using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        animator = GetComponentInChildren<Animator>(); // 자식 오브젝트에서 Animator 컴포넌트 가져오기
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isDead)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameManager.QuitGame();
            }

            if (deathCooldown <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.isDead = false;

                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;
        // 중력이 너무 약해서 추가로 넣어줌
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        if (isFlap)
        {
            velocity.y = flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp(_rigidbody.velocity.y * 10f, -90, 90); // 각도 제한
        float lerpAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, angle, Time.fixedDeltaTime * 5f); // 부드러운 회전
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (gameManager.isDead) return;

        animator.SetInteger("IsDie", 1); // 애니메이션 파라미터 설정
        gameManager.isDead = true;
        deathCooldown = 1f;
        gameManager.GameOver();
    }
}
