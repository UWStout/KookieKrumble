/*
*   The scene class for Level 1
*/
class Level_1 extends TiledScene {

    constructor(config, nextLevel) {
        super('Level_1', Level_2);
    }

    preload() {
        this.load.image('levelTileMap', "assets/backgrounds/BG_testLevel.jpg");
    }

    create(data) {
        this.add.existing(new Player(this, 100, 100));
        let bg = this.add.image(0, 0, "levelTileMap");
        bg.depth = -3;
    }

    update(time, delta) {
    }

}
