using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1000;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;
    public Image WinLoseBG;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (health <= 0)
        {
            //Debug.Log("Game Over!");
            WinLoseBG.gameObject.SetActive(true);
            WinLoseText.gameObject.SetActive(true);
            WinLoseText.text = "Game Over!";
            WinLoseText.color = Color.white;
            WinLoseBG.color = Color.red;
            StartCoroutine(LoadScene(3));
        }
    }
     void FixedUpdate()
    {
        if ( Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if ( Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if ( Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if ( Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("maze");
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            //Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
            //Debug.Log($"Health: {health}");
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            //Debug.Log("You win!");
            WinLoseBG.gameObject.SetActive(true);
            WinLoseText.gameObject.SetActive(true);
            WinLoseText.text = "Game Over!";
            WinLoseText.color = Color.black;
            WinLoseBG.color = Color.green;
            StartCoroutine(LoadScene(3));
        }
    }
}