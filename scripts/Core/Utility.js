/*
*   A file for global utility functions
*/

// Loads and adds a texture for visual GameObjects like Sprite, TileSprite, Image, etc.
//
// gameObject: The target to load an image for
// key: a name used to refer to the image
// path: the path the the image in the file system
function asyncImageLoad(gameObject, key, path) {
    let loader = gameObject.scene.load;
    loader.image(key, path);
    loader.once('complete', () => {
        gameObject.setTexture(key);
    }, gameObject);
    loader.start();
}
