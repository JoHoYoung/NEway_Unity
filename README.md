<h1>NEway_Unity</h1>
A game of drawing lines to reach a destination without falling off<br>
The explosion of a bomb has a pattern. Try many times to clear
<h3>* this game have 2Modes </h3><br>
<h4><t>1. Chapter Mode</h4><br>
<h5>Has 5 chapters, Limited Drawable Ink</h5><br>
<h4><t>2. Infinity Mode</h4><br>
<h5>Infinity Drawable Ink, scoring according to play time<h5><br>
<br>
<h2>About U.I(User Interface)</h2><br>
* Chapter<br>
<img width="500" alt="chapter" src="https://user-images.githubusercontent.com/37579650/41142597-2cf08fc2-6b31-11e8-8300-10d0e43e63db.png">\
<br>
* Play
<img width="500" alt="ui_start" src="https://user-images.githubusercontent.com/37579650/41142599-2d167200-6b31-11e8-910d-354199b7bc92.png">
<br>
<br>

<h2>Play</h2><br>
<h4>Draw</h4>
<img width="500" alt="play" src="https://user-images.githubusercontent.com/37579650/41142606-2e028e10-6b31-11e8-9c57-96ba235582bf.png">
<br>
<h4>Wall</h4>
<img width="500" alt="wall" src="https://user-images.githubusercontent.com/37579650/41142613-2e7dcbb6-6b31-11e8-9b10-8b011c286cd1.png">
<br>
<h4>Hammer Item</h4>
<img width="500" alt="hitem" src="https://user-images.githubusercontent.com/37579650/41142614-2ea39fee-6b31-11e8-850f-78dd345778f1.png"><br>
<br>
<img width="500" alt="geth" src="https://user-images.githubusercontent.com/37579650/41142589-2c26d8a8-6b31-11e8-8e31-d97abbe0c9a4.png">
<br>
<h4>Ink Item</h4>
<img width="500" alt="ink" src="https://user-images.githubusercontent.com/37579650/41142590-2c53bcec-6b31-11e8-8bfc-2b4ebfb17d1a.png">
<br>
<h4>Fail</h4>
<img width="500" alt="fail" src="https://user-images.githubusercontent.com/37579650/41142594-2ca0163c-6b31-11e8-800a-4caab77a9851.png">
<br>
<br>
<h2>*Developing Notes</h2><br>
<h3>About Drawing Lines</h3><br>
<h5>Drawing lines and go ahead means make collider Accoring to Mouse(touch) Input<br>
Copying a certain size of the collider is problematic because the position of the mouse is not constant for each frame<br>
Even if the copy is successful according to the mouse input, the rotation value(Direction Vector) does not apply and appears in shapes of stairway<br>
To solve this, vectors had to be used using mouse inputs per frame. Get angle(Rotation value) using vertors, And apply
this to Quarternion value. <br> 
Though Many trial, get Scailing value make collider fit into change of mouse input.<br>
though this i can make smooth combination of edge colliders.<br>
<h4>Error Example</h4>
<img width="500" alt="shot" src="https://user-images.githubusercontent.com/37579650/41142615-2ecad3de-6b31-11e8-8b65-4e7751fe5ec1.png">
<br>
<h4>Codes to slove this error</h4>
<img width="500" alt="er1shot" src="https://user-images.githubusercontent.com/37579650/41142588-2c0047d8-6b31-11e8-813f-e3544ddb448d.png"><br>
<br>
<img width="500" alt="c" src="https://user-images.githubusercontent.com/37579650/41142592-2c7982b0-6b31-11e8-976a-dc4a3ce4a6d4.png"><br>
<br>

<h5>*Details in ppt..</h5>