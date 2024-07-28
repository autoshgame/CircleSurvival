using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRotate : MonoBehaviour
{
    [SerializeField] private BaseWeapon rotateObject;
    [SerializeField] private Player actor;
    [SerializeField] private CapsuleCollider2D baseCollider;
    [SerializeField] private AudioSource audioSource;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagConstant.PLAYER))
        {
            //Check if exist player, if true make player dead
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != actor && player != null)
            {
                player.Dead();

                // Update weapon
                rotateObject.UpdateLevel();

                // Level up player
                actor.UpdateLevel();
            }
        } 
        else 
        {
            //Play sound when sword hit
            audioSource.PlayOneShot(SoundManager.Instance.SoundSO.props[SoundUtils.SWORD_HIT]);
            
            // Check if exsist another weapon
            rotateObject.DoRotate();

            if (actor.PlayerType == PlayerType.BOT)
            {
                Bot bot = (Bot)actor;
                if (bot.gameObject.activeInHierarchy)
                {
                    bot.ReverseDirection();
                }
            }
        }
    }

    public void SetColliderOffset(Vector2 offset)
    {
        baseCollider.offset = offset;
    }

    public void SetColliderSize(Vector2 size)
    {
        baseCollider.size = size;
    }
}
