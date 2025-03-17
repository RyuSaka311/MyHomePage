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

    // ���t���[���Ă΂��
    private void Update()
    {
        Walk();
        Jump();
    }

    /// <summary>
    /// ����
    /// </summary>
    private void Walk()
    {
        // �����̓��͂��󂯎��
        var h = Input.GetAxisRaw("Horizontal");
        var velo = _rb2d.linearVelocity;

        // ���͂�����ꍇ
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
    /// �W�����v
    /// </summary>
    private void Jump()
    {
        var jump = Input.GetButtonDown("Jump");

        // �n��ɂ���
        if (_checker.IsGrounded) 
        {
            // �W�����v�L�[�������ꂽ��
            if (jump)
            {
                _rb2d.AddForceY(_jumpPower, ForceMode2D.Impulse);
            }
        }
    }

}
