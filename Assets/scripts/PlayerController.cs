using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    


    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public GameObject player;

    private Rigidbody rb;
    private int count;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetAllText();

        winText.text = "";
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetAllText();
        }


        else if (other.gameObject.CompareTag("BadPickUp"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetAllText();
        }

        if (count == 12)
        {
            transform.position = new Vector3(28.0f, player.transform.position.y, 8.0f);
            winText.text = "";
        }
    }

    void SetAllText()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();

        if (count >= 24)
        {
            winText.text = "You finished with a score of: " + score.ToString();        
        }

        
    }
}

 

