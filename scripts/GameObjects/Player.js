class Player extends Phaser.GameObjects.Sprite {

    constructor(scene, x, y)
    {
        super(scene, x, y);

        this.setPosition(x, y);

        asyncImageLoad(this, "player", "Assets/Sprites/FloorTileRepeatable.png");

        // add dynamic physics body
        this.scene.physics.add.existing(this, false);
        this.body.setCollideWorldBounds(true);

        this.scene.cameras.main.centerOn(x, y);
        this.scene.cameras.main.startFollow(this, true, 0.05, 0.05);
    }

    // Called once per frame
    preUpdate(time, delta)
    {
        super.preUpdate(time, delta);

        this.movePlayer();
    }

    movePlayer() {
        this.body.setVelocity(0);

        if (input.left.isDown)
        {
            this.body.setVelocityX(-500);
        }
        else if (input.right.isDown)
        {
            this.body.setVelocityX(500);
        }

        if (input.up.isDown)
        {
            this.body.setVelocityY(-500);
        }
        else if (input.down.isDown)
        {
            this.body.setVelocityY(500);
        }
    }

}
