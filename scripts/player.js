class Player extends Phaser.Scene {

    player;

    constructor(config) {
        super('player');
    }

    preload() {
        this.load.image('playerImage', "assets/sprites/SPR_cookieWalkDown.gif");
    }

    create(data) {
        player = this.physics.add.image(400, 300, 'playerImage');
        player.setCollideWorldBounds(true);
    }

    // update(time, delta) {
    //     this.move();
    // }

    // move() {
    //     player.setVelocity(0);

    //     if (input.left.isDown)
    //     {
    //         player.setVelocityX(-500);
    //     }
    //     else if (input.right.isDown)
    //     {
    //         player.setVelocityX(500);
    //     }

    //     if (input.up.isDown)
    //     {
    //         player.setVelocityY(-500);
    //     }
    //     else if (input.down.isDown)
    //     {
    //         player.setVelocityY(500);
    //     }
    // }
}