using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    // Start is called before the first frame update
    ScoreManager scoreManager;
    [SerializeField]
    Player player;
    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fish")
        {
            Debug.Log("hit");

            if (other.gameObject.GetComponent<Fish>().canEat)
            {
                scoreManager.IncreasePoints(other.gameObject.GetComponent<Fish>().points);
            }
            else
            {
                player.Sickness();
            }
            
            other.gameObject.GetComponent<Fish>().Consumed();
        }
    }
}
