using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public float JumpForce;
    private bool Grounded;
    private bool Goal;
    public bool GameOver;
    public GameObject GameOverText;
    public GameObject ClearText;
    public GameObject RetryButton;
    public GameObject NextStageButton;
    public GameObject BackToTitleButton;
    private int residue; //残基
    private GameObject Residue;
    private Text res_tex;
    private GameObject timecounter;
    private TimeCount TC;
    private AudioSource audioSource;
    public AudioClip DamageSE;
    public AudioClip goalSE;
    public AudioClip JumpSE;
    public AudioClip GroundSE;

    // Start is called before the first frame update
    void Start()
    {
        Goal = false;
        GameOver = false;
        residue = 3;
        timecounter = GameObject.Find("timecounter");
        TC = timecounter.GetComponent<TimeCount>();
        Residue = GameObject.Find("residue");
        res_tex = Residue.GetComponent<Text>();
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //残基表示
        res_tex.text = ("Residue : " + residue);

        if(Grounded == true) {
            //摩擦
            if (rb.velocity.x > 0)
            {
                rb.AddForce(-1f, 0, 0);
            }
            else
            {
                rb.AddForce(1f, 0, 0);
            }
            if (rb.velocity.z > 0)
            {
                rb.AddForce(0, 0, -1f);
            }
            else
            {
                rb.AddForce(0, 0, 1f);
            }

            if (TC.End == false)
            {
                //十字キーでplayer操作
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.AddForce(0, 0, 5);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.AddForce(0, 0, -5);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.AddForce(5, 0, 0);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.AddForce(-5, 0, 0);
                }
            }
        }

        //ステージから落ちた時の挙動
        if (transform.position.y < -10)
        {
            audioSource.PlayOneShot(DamageSE);
            rb.velocity = Vector3.zero; //速度を0にする
            transform.position = new Vector3(0, 1, -36);
            residue--;
        }
        //残基0の時
        if (residue == 0)
        {
            GameOverText.SetActive(true);
            RetryButton.SetActive(true);
            BackToTitleButton.SetActive(true);
            TC.End = true;
            GameOver = true;
        }
        if(TC.End == true && Goal == false)
        {
            GameOver = true;
        }
        //ゲームオーバーになった時
        if (GameOver == true)
        {
            GameOverText.SetActive(true);
            RetryButton.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(DamageSE);
            transform.position = new Vector3(0, 1, -36);
            residue--;
        }
        if(collision.gameObject.tag == "Jump")
        {
            audioSource.PlayOneShot(JumpSE);
            rb.AddForce(0, JumpForce, 0);
        }
        if (collision.gameObject.tag == "Ground")
        {
            audioSource.PlayOneShot(GroundSE);
            Grounded = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            if (GameOver == false)
            {
                rb.velocity = Vector3.zero;
                audioSource.PlayOneShot(goalSE);
                ClearText.SetActive(true);
                RetryButton.SetActive(true);
                BackToTitleButton.SetActive(true);
                if (SceneManager.GetActiveScene().name != "Stage3")
                {
                    NextStageButton.SetActive(true);
                }
                Goal = true;
                TC.End = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Grounded = false;
        }
    }
}
