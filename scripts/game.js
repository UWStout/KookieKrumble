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
    scene: [ Boot, Level_1 ]
};
let game = new Phaser.Game(config);
let input;

var Boot = new Phaser.Class({

    Extends: Phaser.Scene,

    initialize: function Boot()
    {
        Phaser.Scene.call(this, { key: 'boot' });
    },

    // Called before create, use to load assets
    preload: function ()
    {
    },

    // Use this to create game objects
    create: function ()
    {
        input = this.input.keyboard.createCursorKeys();

        // Load the initial level
        game.scene.add('level_1', Level_1, true);
    },

    // Called every frame
    update: function (time, delta)
    {
    }

});