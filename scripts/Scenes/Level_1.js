class Level_1 extends TiledScene {

    constructor(config) {
        super('Level_1');
    }

    preload() {
        this.load.image('levelTileMap', "assets/backgrounds/BG_testLevel.jpg");
        //super.import();
    }

    create(data) {
        this.add.existing(new Player(this, 0, 0));
        let bg = this.add.image(0, 0, "levelTileMap");
        bg.depth = -3;
        //super.generateLevel();
    }

    update(time, delta) {
    }

}
