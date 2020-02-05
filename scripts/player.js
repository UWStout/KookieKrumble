class Player extends Phaser.Scene {

    constructor(config) {
        super(config);
    }

    preload() {
        this.load.image('playerImage', "assets/sprites/SPR_cookieWalkDown.gif");
    }

    create(data) {
        this.add.image(data.x, data.y, 'playerImage');
    }

    update(time, delta) {
        player.setVelocity(0);

        if (input.left.isDown)
        {
            player.setVelocityX(-500);
        }
        else if (input.right.isDown)
        {
            player.setVelocityX(500);
        }
    
        if (input.up.isDown)
        {
            player.setVelocityY(-500);
        }
        else if (input.down.isDown)
        {
            player.setVelocityY(500);
        }
    }

}

function updatePlayer()
{
    player.setVelocity(0);

    if (input.left.isDown)
    {
        player.setVelocityX(-500);
    }
    else if (input.right.isDown)
    {
        player.setVelocityX(500);
    }

    if (input.up.isDown)
    {
        player.setVelocityY(-500);
    }
    else if (input.down.isDown)
    {
        player.setVelocityY(500);
    }
}