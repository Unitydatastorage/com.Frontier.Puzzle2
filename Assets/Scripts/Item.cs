using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool cantChange;
    public bool open;
    Animator animator;
    public Game game;
    [SerializeField] Sprite[] colors;
    [SerializeField] private SpriteRenderer sprite;
    private int color;
    public int index;
    private bool first;
    public int Color { get { return color; } set {  color = value; sprite.sprite = colors[color];  } }
    // Start is called before the first frame update
    void Start()
    {
        first = true;
        //sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        open = true;
        cantChange = false;
        Invoke(nameof(tog), 1);
    }

    void tog()
    {
        toggle(false);
    }

    public void OnMouseUp()
    {   
        if(!first && !cantChange) toggle(true);
    }

    public void toggle(bool need)
    {
        open = !open;  
        animator.SetBool("Open",open);
        if (!first && need) {
            cantChange = true;
            Invoke("mes", 0.7f);
        }
        first = false;
    }

    void mes()
    {
        cantChange=false;
        game.toggleItem(index);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
