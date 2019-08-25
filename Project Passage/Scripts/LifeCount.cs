using Godot;
using System;

public class LifeCount : Container
{
    Sprite heart1;
    Sprite heart2;
    Sprite heart3;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        heart1 = GetNode("Heart1") as Sprite;
        heart2 = GetNode("Heart2") as Sprite;
        heart3 = GetNode("Heart3") as Sprite;
    }

    public void DisplayHearts(int number){
        Sprite[] hearts = {heart1, heart2, heart3};
        for (int i = 0; i < 3; i++){
            if (number > 0){
                hearts[i].Show();
            }else{
                hearts[i].Hide();
            }
            number -= 1;
        }
    }
    
}
