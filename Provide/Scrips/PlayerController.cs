using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _walkSpeed = 5f;

    [SerializeField]
    private float _jumpPower = 5f;

    private Checker _checker;
    private Rigidbody2D _rb2d;

    private void Start()
    {
        _checker = GetComponentInChildren<Checker>();

        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // 毎フレーム呼ばれる
    private void Update()
    {
        Walk();
        Jump();
    }

    /// <summary>
    /// 歩く
    /// </summary>
    private void Walk()
    {
        // 水平の入力を受け取る
        var h = Input.GetAxisRaw("Horizontal");
        var velo = _rb2d.linearVelocity;

        // 入力がある場合
        if (h != 0)
        {
            velo.x = h * _walkSpeed;
            _rb2d.linearVelocity = velo;
        }
        else
        {
            velo.x = 0;
            velo.y = _rb2d.linearVelocity.y;
        }

        _rb2d.linearVelocity = velo;
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    private void Jump()
    {
        var jump = Input.GetButtonDown("Jump");

        // 地上にいる
        if (_checker.IsGrounded) 
        {
            // ジャンプキーが押されたら
            if (jump)
            {
                _rb2d.AddForceY(_jumpPower, ForceMode2D.Impulse);
            }
        }
    }

}
