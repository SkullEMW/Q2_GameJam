using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class InvaderManager : MonoBehaviour
{
    public InvaderMovment[] prefabs;

    public int rows = 5;

    public int columns = 6;

    public Sprite[] animationSprites;

    public float animationTime = 3.0f;

    private SpriteRenderer _spriteRenderer;

    private int _animationFrame;


    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 4.0f * (this.columns - 2);
            float height = 2.0f * (this.rows - 2);  
            Vector2 centering = new Vector2(-width /2 , -height/ 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 6.0f), 0.0f);


            for (int col = 0; col < this.columns; col++)
            {
             InvaderMovment invader = Instantiate(this.prefabs[row], this.transform);
             Vector3 position = rowPosition;
             position.x += col * 4.0f;
             invader.transform.localPosition = position;
          
            }
        
        }



        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }


    private void AnimateSprite()
    {
        _animationFrame++;

        //if (_animationFrame)  
            
    }
}
