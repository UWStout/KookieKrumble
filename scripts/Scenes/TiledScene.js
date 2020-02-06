/*
*   The class that all level scene classes inherit from.
*   Handles deserializing the Tiled editor json files into
*   game objects in the scene.
*/
class TiledScene extends Phaser.Scene {

    player;
    nextLevel;

    constructor(config, nextLevel) {
        super(config);

        this.nextLevel = nextLevel;
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

    restartLevel(){
        // TODO: Camera fade? See: https://github.com/photonstorm/phaser3-examples/blob/master/public/src/scenes/restart%20a%20scene.js
        this.scene.restart();
    }

    switchToNextLevel() {
        // TODO: loading screen?
        game.scene.add(this.nextLevel.constructor.name, this.nextLevel, true);
        game.scene.remove(this.constructor.name);
    }

}
