using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float patrolDistance = 5f;

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);

        if (Mathf.Abs(transform.position.z - startPos.z) >= patrolDistance)
            direction *= -1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
