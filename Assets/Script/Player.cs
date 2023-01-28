using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public AudioSource appleSoundEffect;
    public AudioSource bigcoinSoundEffect;
    public AudioSource smallcoinSoundEffect;
    public AudioSource DieSound;
    Rigidbody2D rb;
    Vector2 velocity;
    bool haveBubble;
    bool killEnemy = false;
    public static bool delBubble;
    private bool dieAnimaktion = false;
    public Animator animator;
    public GameObject bubble;
    float movementSpeed = 75f;
    float movement = 0f;
    float startPosition;
    float jumpForce = 50f;
    float sec;
    int count ;

    void Start()
    {
        haveBubble = Check_Bubble.check;
        Debug.Log("111"+haveBubble);
        delBubble = false;
        startPosition = PlayerPrefs.GetFloat("startPosition");
        rb = GetComponent<Rigidbody2D>();
        Vector2 position = rb.position;
        position.x = startPosition;
        rb.position = position;
        bubble.transform.position = transform.position;
        
    }
    //左右移動
    void Update()
    {
        if (haveBubble&&count==0)
        {
            Debug.Log("Testing" + TotalMoney.totalMoney);
            Debug.Log("bubble:"+haveBubble);
            TotalMoney.totalMoney -= 100;
            count++;

        }
        if (rb.velocity.y <= 0)
            killEnemy = false;
        //bubble.transform.position = transform.position;

        if (haveBubble&&!delBubble)
        {
            bubble.SetActive(true);
            bubble.transform.position = transform.position;
        }
        else
        {
            bubble.SetActive(false);
        }

        // phone gyroscope
        movement = Input.acceleration.x * movementSpeed;
        // movement = Input.GetAxis("Horizontal") * movementSpeed;//水平方向移動

        if (transform.position.x <= -13.5)
        {
            float nowPosition = transform.position.y;
            Vector2 rightSide = new Vector2(16f, nowPosition);
            transform.position = rightSide;
        }
        else if (transform.position.x >= 18)
        {
            float nowPosition = transform.position.y;
            Vector2 leftSide = new Vector2(-11f, nowPosition);
            transform.position = leftSide;
        }

        /* 死掉的判斷 */
        if (rb.velocity.y >= 0f)
        {
            sec = 0;
        }
        else if (rb.velocity.y < 0f)
        {
            sec += Time.deltaTime;
            if (sec > 1)
            {
                dieAnimaktion = true;
                animator.SetBool("Die", dieAnimaktion);
                DieSound.Play();
                dieAnimaktion = false;
            }
            if (sec > 3)
            {
                SceneManager.LoadScene(2);
            }
        }
        
    }
    
    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
    
    //撞到錢錢.蘋果.敵人
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            bigcoinSoundEffect.Play();
            Destroy(collision.gameObject);
            Money_Add.localMoney += 1;
        }

        if (collision.gameObject.tag == "SmallCoin")
        {
            smallcoinSoundEffect.Play();
            Destroy(collision.gameObject);
            Money_Add.localMoney += 1;
        }

        if (collision.gameObject.tag == "Apple")
        {
            appleSoundEffect.Play();
            Destroy(collision.gameObject);
            killEnemy = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (haveBubble)
            {
                delBubble = true;
                Destroy(collision.gameObject);
                haveBubble = false;
            }
            else
            {
                if (killEnemy == true)
                    Destroy(collision.gameObject);
                else
                {
                    Collider2D item = rb.GetComponent<Collider2D>();
                    Destroy(item);

                    velocity = rb.velocity;
                    velocity.y = 0f;
                    rb.velocity = velocity;

                    dieAnimaktion = true;
                    animator.SetBool("Die", dieAnimaktion);
                    DieSound.Play();
                    dieAnimaktion = false;
                }
            }
            
        }

    }

}
