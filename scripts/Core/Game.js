/*
*   This file is the entry point of the game and boots the game into the initial scene.
*
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

function init() {
    input = this.input.keyboard.createCursorKeys();
    game.scene.add('Level_1', Level_1, true);
}
