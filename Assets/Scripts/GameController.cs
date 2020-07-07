using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject Chest;
    public GameObject player;
   // public Vector3 spawnValues;
    public float spawnWait;
    public int chestCount;
    public Text GameOverText;

    [HideInInspector]
    public bool gameOver;

    public CharacterMovement Moving;
    // Use this for initialization
    void Awake () {
        gameOver = false;
        GameOverText.text = "";
        StartCoroutine (SpawnChests());
        CharacterMovement Moving = GetComponent<CharacterMovement>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        
        if (CountingPoints.score == 5)
        {
            gameOver = true;
            StartCoroutine (GameOver());
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnChests()
    {
        if (gameOver==false)
        {
            for (int i = 0; i < chestCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-13, 13),
                    0, Random.Range(-13, 13));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Chest, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            


        }
    }
    
    IEnumerator GameOver()
    {
            GameOverText.text = "Gratulacje";
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        
    

}
