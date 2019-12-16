using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Drop : MonoBehaviour
{

    public float speed;
    private bool hit;

    private Vector2 bounds;

    private static int score = 0;
    private Text scoreText;  
    

    private void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        scoreText = GameObject.Find("scores").GetComponent<Text>();

        ParticleSystem ps = GameObject.Find("particle").GetComponent<ParticleSystem>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(-transform.position.y > bounds.y)
        {
            Destroy(this.gameObject);            
            //SceneManager.LoadScene("GameOver");
        }      
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hit) {
            hit = true;
            transform.Translate(Vector3.zero);
            gameObject.AddComponent<Move>().speed = 4;
            score++;

            
            scoreText.text = score + "";
            Debug.Log("score : " + score);
        }
    }

}
