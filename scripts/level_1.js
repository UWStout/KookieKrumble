class Level_1 extends Phaser.Scene {

    player;

    constructor(config) {
        super('level_1');
    }

    preload() {
        this.load.image('levelTileMap', "assets/backgrounds/BG_testLevel.jpg");
    }

    create(data) {
        this.add.image(data.x, data.y, 'levelTileMap');

        //  Set the camera and physics bounds to be the size of 4x4 bg images
        this.cameras.main.setBounds(0, 0, 1920 * 2, 1080 * 2);
        this.physics.world.setBounds(0, 0, 1920 * 2, 1080 * 2);

        player = this.scene.get('player');

        this.cameras.main.startFollow(player, true, 0.05, 0.05);
    }

    update(time, delta) {
    }

}