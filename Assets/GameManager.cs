using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public List<GameObject> blockColors;
    public static int health = 3;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    

    // Update is called once per frame
    void Update()
    {
        Block[] levelBlocks=GameObject.FindObjectsOfType<Block>();
        if(levelBlocks.Length == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (health == 0)
        {
            health = 3;
            SceneManager.LoadScene("GameOver");

        }
    }
}
