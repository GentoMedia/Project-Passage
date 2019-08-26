using Godot;
using System;

public class GameEnd : Node2D
{
    Label controlLabel;
    int blinkTimer = 6;
    int upDownCount = -1;

    public override void _Ready(){
        controlLabel = GetNode("Controls") as Label;
    }

    public override void _Process(float delta){
        if (blinkTimer == 6){
            controlLabel.Visible = true;
            upDownCount = -1;
        }
        if (blinkTimer == 0){
            controlLabel.Visible = false;
            upDownCount = 1;
        }
        blinkTimer += upDownCount;

        if (Input.IsActionJustPressed("ui_cancel")){
            GetTree().Quit();
        }
        if (Input.IsActionJustPressed("Action")){
            GetTree().ChangeScene("res://Scenes/MainMenu.tscn");
        }
    }
}
