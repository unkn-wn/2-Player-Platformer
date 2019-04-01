using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;
public class LevelControl : MonoBehaviour
{
    public int index;
    public string levelName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Loading Level with Scene Name
            SceneManager.LoadScene(levelName);

            //Restart lvl
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}