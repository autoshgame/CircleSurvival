using UnityEngine;

public class BotMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private BotFSMComponent botFSMComponent;
    Vector3 direction = new Vector3(0, 0, 0);
    private float reverseDir = 1;

    private bool canMove = false;
    public bool CanMove { get => canMove; set => canMove = value; }

    private bool isMoveOpposite = false;
    private float oppositeMoveTime = 1f;
    private bool isStartCountMoveOpposite;
    private float timeStartCountMoveOpposite;
    float randomRangeWhenDetectOpposite;

    private void Update()
    {
        if (canMove == false) return;

        if (botFSMComponent.enemyDetection.Target != null && botFSMComponent.enemyDetection.Target.gameObject.activeInHierarchy)
        {
            randomRangeWhenDetectOpposite = Random.Range(0f, 1.5f);
            if (Vector2.Distance(transform.position, botFSMComponent.enemyDetection.Target.position) > randomRangeWhenDetectOpposite && isMoveOpposite == false)
            {
                direction = (botFSMComponent.enemyDetection.Target.position - transform.position).normalized;
            }
            else
            {
                if (!isMoveOpposite)
                {
                    isMoveOpposite = true;
                }
                
                if (!isStartCountMoveOpposite)
                {
                    timeStartCountMoveOpposite = Time.realtimeSinceStartup;
                    isStartCountMoveOpposite = true;
                }

                if (Time.realtimeSinceStartup - timeStartCountMoveOpposite > oppositeMoveTime)
                {
                    isStartCountMoveOpposite = false;
                    isMoveOpposite = false;
                }

                direction = (-botFSMComponent.enemyDetection.Target.position + transform.position).normalized;
            }
        }
        else
        {
            isStartCountMoveOpposite = false;
            isMoveOpposite = false;

            botFSMComponent.enemyDetection.ScanPlayer();
            reverseDir = 1;
        }

        direction.x *= reverseDir;
        direction.y *= reverseDir;

        if (direction != Vector3.zero)
        {
            botFSMComponent.botRigidbody2D.velocity = moveSpeed * Time.deltaTime * direction;
        }
        else
        {
            botFSMComponent.botRigidbody2D.velocity = Vector2.zero;
        }
    }
}
