/*
*   The player game object class handles all player input and action.
*/
class Player extends Phaser.GameObjects.Sprite {

    constructor(scene, x, y)
    {
        super(scene, x, y);

        this.setPosition(x, y);

        Utility.asyncImageLoad(this, "player", "Assets/Tiles/SpawnPointTile.png");

        // add dynamic physics body
        this.scene.physics.add.existing(this, false);
        this.body.setCollideWorldBounds(true);

        this.scene.cameras.main.centerOn(x, y);
        this.scene.cameras.main.startFollow(this, true, 0.08, 0.08);
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
