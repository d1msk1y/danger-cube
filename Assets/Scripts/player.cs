using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public static player instance;
    public float jumpForce, speed, hardSpeed, degrees, degreesMinus, score, highScore, coinCount, totalCoinCount, timer, berserk;
    public InterAd showAdFunc;
    public AudioClip[] soundtracks;
    public ParticleSystem exlosion, coinExplosion,fire;
    public Transform playerPos;
    public bool up;
    public Text txtScore,highScoreTxt, highScoreTxtDie, txtScoreDie,totalCoins, berserkTxt, shieldTimerTxt;
    public GameObject coin, cubesSpawner, continueButton, pause, berserkAura,timeShield;
    public AudioSource soundTracksSource, enemySound, rocketSound;
    private Rigidbody2D rb;
    private Coins coinScript;
    private int randomSoundTracks;

    public Canvas bestScore;//Меню после проигрыша

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highScore = PlayerPrefs.GetFloat("SaveScore");
        }
        if (PlayerPrefs.HasKey("TotalCoins"))
        {
            totalCoinCount = PlayerPrefs.GetFloat("TotalCoins");
        }

        soundTracksSource.clip = soundtracks[Random.Range(0, soundtracks.Length)];
        randomSoundTracks = Random.Range(0, soundtracks.Length);
    }

    // Start is called before the first frame update
    void Start()
    {
        soundTracksSource.Play();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) || Input.touchCount > 0)//Поворт в полете
        {

            up = (true);
            if (up == true)
            {
                Jump();
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 40), 5 * Time.deltaTime);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) || Input.touchCount <= 0)//Поворт в полете
        {
            up = (false);
        }

        if (up == false)//Поворт в полете
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -40), 3 * Time.deltaTime);
        }

        instance.AddScore();//Подщёт очков
        txtScore.text = score.ToString("0");//вывод очков
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
            ResetHighScore();

        move();

        speed += hardSpeed * Time.deltaTime;//увеличение скорости
        if(speed >= 35)
        {
            hardSpeed = 0;
        }

        if (Input.GetKey(KeyCode.Mouse0) || Input.touchCount > 0)
        {
            rocketSound.mute = false;
            fire.enableEmission = true;
        }

        if (up == false)
        {
            rocketSound.mute = true;
            fire.enableEmission = false;
        }

        if (timer <= 0)
        {
            berserk = 0;
            berserkAura.SetActive(false);
            timeShield.SetActive(false);
        }

        timer -= 1 * Time.deltaTime;

        shieldTimerTxt.text = timer.ToString("0");
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    public void move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Die();
        }

        else if(collision.collider.tag == "cube")
        {
            berserkAura.SetActive(false);

            if (berserk < 1)
            {
                Die();
            }

            if (berserk > 0)
            {
                Destroy(collision.gameObject);
                Instantiate(exlosion, collision.transform.position, Quaternion.identity);
                speed -= 1;
                enemySound.Play();
                timer = 0;
            }
            berserk -= 1;
        }

        if (collision.collider.tag == "coin")
        {
            Instantiate(coinExplosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            timer = 15;
            berserk = 1;
            berserkAura.SetActive(true);
            timeShield.SetActive(true);
        }
    }

    public void Die()
    {
        Instantiate(exlosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        txtScore.gameObject.SetActive(false);
        bestScore.gameObject.SetActive(true);
        txtScoreDie.text = score.ToString("0");
        highScoreTxtDie.text = highScore.ToString("0");
        cubesSpawner.SetActive(false);
        AddTotalCoins();
        totalCoins.text = totalCoinCount.ToString("TOTAL COINS : 0");
        cubesSpawner.SetActive(false);

        if (score >= 15)
        {
            continueButton.SetActive(true);

        }

        pause.SetActive(false);
        timeShield.SetActive(false);
    }

    public void AddScore()
    {
        score += 1 * Time.deltaTime;

        HighScore();
    }

    public void HighScore()
    {
        if(score > highScore)
        {
            highScore = score;
        }

        PlayerPrefs.SetFloat("SaveScore", highScore);
    }

    public void AddTotalCoins()
    {
        PlayerPrefs.SetFloat("TotalCoins", totalCoinCount);
    }

    public void ResetScore()
    {
        score = 0;
    }

   public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScore");

        highScore = 0;
    }
}
