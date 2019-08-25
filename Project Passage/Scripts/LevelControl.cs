using Godot;
using System;

public class LevelControl : Node2D
{
    bool gameOverState = false;
    Label gameOverLabel;
    Player player;


    public override void _Ready()
    {
        player = GetNode("Player") as Player;
        gameOverLabel = GetNode("GameText/GameOver") as Label;
        gameOverLabel.Hide();
        gameOverState = false;
    }

    public override void _Process(float delta){
        if (gameOverState && Input.IsActionJustPressed("Action")){
            GetTree().ChangeScene("res://Scenes/MainTest.tscn");
        }
    }

    void GameOver(){
        gameOverLabel.Show();
        gameOverState = true;
    }

}
