using UnityEngine;

public class TestDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damageInterface = collision.gameObject.GetComponent<IDamageable>();
        damageInterface?.TakeDamage(1.2f);
    }
}
