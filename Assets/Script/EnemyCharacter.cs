using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [SerializeField] Transform player;     // 플레이어 위치
    ScoreManager scoreManager;                // Reference to the score manager
    [SerializeField] GameOver gameOver;


    public UnityEngine.AI.NavMeshAgent agent;
    public float rotationSpeed = 5f; // 회전 속도

    [SerializeField] float health = 50f; // health

    public GameObject gameOverText;
    private Rigidbody rb;

    private void Start()
    {
        // Player 태그를 가진 오브젝트 찾기
        if (GameObject.FindGameObjectWithTag("Player") != null) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        scoreManager = ScoreManager.Instance;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No rigidbody");
        }
    }

    private void FixedUpdate()
    {
        // 플레이어를 향해 이동
        if (player != null && ScoreManager.Instance.isPlayerAlive)
        {
            agent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어와 충돌하면 게임 종료 처리
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with Player!");
            // Game Over 텍스트 활성화
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }

            // 플레이어 제거
            KillPlayer();
        }
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            scoreManager.AddScore(10);
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void KillPlayer()
    {
        scoreManager.Dead();
        Debug.Log("Player has been killed by the enemy!");
    }
}
