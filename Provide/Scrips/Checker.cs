using UnityEngine;

public class Checker : MonoBehaviour
{
    // �n�ʂƐݒu���Ă��邩
    public bool IsGrounded { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            IsGrounded = false;
        }
    }
}
