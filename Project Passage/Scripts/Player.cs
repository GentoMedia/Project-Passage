using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export]
    int speed = 1;
    Vector2 direction;

    public int MaxLife = 3;
    public int Life = 3;
    public bool damageFlash;

    AnimatedSprite animator;

    [Signal]
    delegate void LifeChange(int life);
    [Signal]
    delegate void GameOver();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        EmitSignal("LifeChange", Life);
        animator = GetNode("AnimatedSprite") as AnimatedSprite;
        damageFlash = false;
    }

    public override void _Process(float delta){
        if (damageFlash){
            Visible = !Visible;
        }
    }

    public override void _PhysicsProcess(float delta){
        direction = new Vector2();
        
        //Keyboard Input
        
        if (Input.IsActionPressed("Forward")){
            direction.y -= 1;
            animator.SetAnimation("MoveUp");
        }
        if (Input.IsActionPressed("Right")){
            direction.x += 1;
            animator.SetAnimation("MoveSide");
            animator.SetFlipH(false);
        }
        if (Input.IsActionPressed("Left")){
            direction.x -= 1;
            animator.SetAnimation("MoveSide");
            animator.SetFlipH(true);
        }
        if (Input.IsActionPressed("Backward")){
            direction.y += 1;
            animator.SetAnimation("MoveDown");
        }

        if(direction != new Vector2()){
            animator.Play();
        }else{
            animator.Stop();
        }
        direction.Normalized();

        //Process Movement
        MoveAndSlide(direction*speed);

    }

    public void LifeMath(int amount){
        Life += amount;
        if (Life > MaxLife){
            Life = MaxLife;
        }
        EmitSignal("LifeChange", Life);

        if(Life <= 0){
            GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
            QueueFree();
            EmitSignal("GameOver");
        }
    }

}
