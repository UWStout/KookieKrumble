# Repo for Kookie Krumble

## Warning

- Javascript is stupid and freaks out if you don't use `this` in front of class properties. If you're getting errors where a symbol isn't recognized then check if you forgot to reference the property via `this`.
- Watch out for improper usage of the `Vector2` class.
    - You **CAN NOT** pass a `Vector2` into the `body.setVelocity()` function. It's stupid as hell, but it will make the screen black out with no warnings. You need to pass x and y seperately.
    - Similarly doing reasonable and intuative things like multiplying a Vector2 and a scalar with `*` or adding two vectors with `+` will not work. You need to use methods for vector math (e.g. `scale()` and `add()`).
    - Generally if the game only shows a black screen check for issues with custom Phaser types like `Vector2`.
- Keep an eye on script order in `index.html`. Javascript gets finicky about not recognizing symbols when scripts are not added in the right order.
