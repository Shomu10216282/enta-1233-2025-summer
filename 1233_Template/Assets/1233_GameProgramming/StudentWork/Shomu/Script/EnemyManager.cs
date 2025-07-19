using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool areenemiesdead = true;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                areenemiesdead = false;
            }
        }

        if (areenemiesdead)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameWon();
            }
        }
    }
}
