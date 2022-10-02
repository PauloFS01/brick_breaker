using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Sprite TileYellow;
    public SpriteRenderer brickRenderer;

    void Start()
    {
        brickRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Brick")
            brickRenderer.sprite = TileYellow;
    }
}
