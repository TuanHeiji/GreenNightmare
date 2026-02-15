using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float distance = 2f;
    private Vector3 startPos;
    private bool movingRight = true;
    public int enemyHP = 3;
    private SpriteRenderer sprite;
   

    void Start()
    {
        startPos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;
        if(movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if(transform.position.x >= rightBound)
            {
                movingRight = false;
                Flip();
            }
        }

        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("LayerBullet"))
        {
            
            enemyHP--;
            
            StartCoroutine(HitFlash());
            if (enemyHP == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator HitFlash()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    


}
