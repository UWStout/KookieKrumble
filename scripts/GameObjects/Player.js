/*
*   The player game object class handles all player character input and state.
*/
class Player extends Phaser.GameObjects.Sprite {

    acceleration;
    inputDirection;

    constructor(scene, x, y)
    {
        super(scene, x, y);

        this.acceleration = 1500.0;
        this.inputDirection = new Phaser.Math.Vector2();
        this.setPosition(x, y);

        // Set the sprite
        Utility.asyncImageLoad(this, "player", "Assets/Tiles/SpawnPointTile.png");

        // add dynamic physics body
        this.scene.physics.add.existing(this, false);
        this.body.setCollideWorldBounds(true);
        this.body.setDrag(700);
        this.body.setAngularDrag(400);
        this.body.setMaxVelocity(300);

        // Setup player camera
        this.scene.cameras.main.centerOn(x, y);
        this.scene.cameras.main.startFollow(this, true, 0.1, 0.1);
    }

    // Called once per frame
    preUpdate(time, delta)
    {
        super.preUpdate(time, delta);

        // Update input
        this.inputDirection = this.getInputDirection();
        // Update acceleration
        let newAcceleration = this.inputDirection.scale(this.acceleration);
        this.body.setAcceleration(newAcceleration.x, newAcceleration.y);
    }

    // Returns the normalized input direction after combining all movement inputs
    getInputDirection() {
        let inputDirection = new Phaser.Math.Vector2(0, 0);

        if (input.up.isDown) {
            inputDirection.add(Phaser.Math.Vector2.UP);
        }
        if (input.down.isDown) {
            inputDirection.add(Phaser.Math.Vector2.DOWN);
        }
        if (input.right.isDown) {
            inputDirection.add(Phaser.Math.Vector2.RIGHT);
        }
        if (input.left.isDown) {
            inputDirection.add(Phaser.Math.Vector2.LEFT);
        }

        return inputDirection.normalize();
    }

}
