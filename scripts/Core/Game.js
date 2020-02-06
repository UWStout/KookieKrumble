/*
*   This file defines the game and boots it into the initial scene.
*   This file also holds important global variables that all other
*   scripts can access.
*/

// Global variables

let config = {
    type: Phaser.AUTO,
    parent: 'phaser-example',
    physics: {
        default: 'arcade',
    },
    scene: {
        init: init
    }
};
let game = new Phaser.Game(config);

let input;


// Boot the game
function init() {
    input = this.input.keyboard.createCursorKeys();
    game.scene.add('Level_1', Level_1, true);
}
