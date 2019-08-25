using Godot;
using System;

public class DamageBox : Area2D
{
    void OnBodyEntered(PhysicsBody2D body2D){
        if (body2D is Player){
            Hide();
            Player player = body2D as Player;
            player.LifeMath(-1);
        }
    }
}
