class Level_1 extends Phaser.Scene {

    constructor(config) {
        super(config);
    }

    preload() {
        this.load.image('levelTileMap', "assets/backgrounds/BG_testLevel.jpg");
    }

    create(data) {
        this.add.image(data.x, data.y, 'levelTileMap');

        game.scene.add('player', Player, true, { x: 50, y: 50 });
    }

    update(time, delta) {
    }

}