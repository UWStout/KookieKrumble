/*
*   The class that all levels inherit from.
*   Handles unserializing the Tiled json files into game objects.
*/
class TiledScene extends Phaser.Scene {

    player;

    constructor(config) {
        super(config);
    }

    create(data) {
    }

    update(time, delta) {
    }

    import(data) {
        // Import Tiled data to instance
        //...
    }

    generateLevel() {
        // Generate the level using imported Tiled data
        //...

        //  Set the camera and physics bounds
        game.cameras.main.setBounds(0, 0, 1920 * 2, 1080 * 2);
        game.physics.world.setBounds(0, 0, 1920 * 2, 1080 * 2);
    }

}
