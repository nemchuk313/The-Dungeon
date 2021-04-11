using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movespeed;//user vvodit skorost
    public float jumpheight;//user vvodit vysotu pryzhka
    private Rigidbody2D rb;// inizializacja personazha
    private Animator anim;//animacja
    private AudioSource audio;
    private Collider2D coll;//dla ground cheka
    
    public Transform groundCheck;// suda perenosim groundcheker
    public float groundCheckRadius;// radius proverki zemli groundchecka
    public LayerMask WoIG;//??? proverka layera
    private bool isGround;//priveriaet na zemle li my

    [SerializeField] private int coins = 0;
    [SerializeField] private Text CoinText;//W geroya wastawlaem misce dlia kilkosti coiniw

     



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,WoIG);

        //Peredvizhenie v levo/prawo

        if( Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);//povorachivaet  persa w lewo
            anim.SetBool("walk",true);
            

        }
        else
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);//povorachivaet  persa w prawo
            anim.SetBool("walk", true);

        }
        else
        {
            anim.SetBool("walk", false);
        }

        //pryzhki

        if( Input.GetKeyDown(KeyCode.Space) && isGround )//esli kosaemsia zemli
        {
            rb.velocity = new Vector2(rb.velocity.x , jumpheight);
            anim.SetBool("jump",true);
            
        }
        if(rb.velocity.y < 0.1f)
        {
            anim.SetBool("jump", false);
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coins += 1;
            audio.Play();
            CoinText.text = coins.ToString();//prisvainie UI aktualnoi ksti coinow((konwertacja do stringa))
        }
        else
        if (collision.gameObject.name == "DeathCollider")
        {
            coins = 0;
            CoinText.text = coins.ToString();
        }
        else
        if (collision.tag == "Finish1")
        {
            Application.LoadLevel("2level");
        }
        else
        if (collision.tag == "Finish2")
        {
            Application.LoadLevel("3level");
        }
        else
        if (collision.tag == "Finish3")
        {
            Application.LoadLevel("4level");
        }
        else
        if (collision.tag == "Finish5")
        {

        }
        else
        {

        }
    }

    
}
