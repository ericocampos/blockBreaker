using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{

    public Sprite[] hitSprite;
    public static int breakableCount = 0;

    private int maxHits;
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;


    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }

    }

    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
