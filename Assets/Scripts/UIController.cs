using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController instance;

    public Image heart1,heart2,heart3;

    public Sprite heartFull, heartEmpty;

    public Text gemCountText;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        if(PlayerHealthController.instance.currentHealth == 3)
        {
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
            heart3.sprite = heartFull;
        }
        else if(PlayerHealthController.instance.currentHealth == 2)
        {
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
            heart3.sprite = heartEmpty;
        }
        else if(PlayerHealthController.instance.currentHealth == 1)
        {
            heart1.sprite = heartFull;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartEmpty;
        }
        else
        {
            heart1.sprite = heartEmpty;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartEmpty;
        }
    }

    public void UpdateGemCount()
    {
        gemCountText.text = LevelManager.instance.gemsCollected.ToString();
    }

}
