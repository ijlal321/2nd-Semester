using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;
using System.IO;
using System.Runtime.InteropServices;


namespace Game
{


    class Program
    {

        public class enemy1_OOP
        {
            public bool isEnemy1alive = true;
            public int enemy1Xsize = 3;
            public int enemy1Ysize = 2;

            public int enemy1X;
            public int enemy1Y;

            public string enemy1Face;

            public char[,] enemy1Array = { { '4', '5', '>' }, { '0', '0', ' ' } };
        }


        public class enemy2_OOP
        {
            public bool isEnemy2alive = true;
            public int enemy2Xsize = 2;
            public int enemy2Ysize = 3;

            public int enemy2X;
            public int enemy2Y;

            public string enemy2Face;

            public string[,] enemy2Array = { { "7", "2" }, { "2", "2" }, { "2", "1" } };
        }



        public class Player_OOP
        {
            public Player_OOP()
            {

            }

            public Player_OOP(int playerX, int playerY)
            {
                this.playerX = playerX;
                this.playerY = playerY;
            }
            public int respawnX = 25;          // player will respawn at this position
            public int respawnY = 25;          // player will respawn at this position

            public char[,] playerArray = { { 'a', 'b', 'c' }, { 'd', 'e', 'f' }, { 'g', 'h', 'i' } }; // totally customizeableplayer array

            public int playerX = 57;           // this will have player corrent position
            public int playerY = 48;           // this will have player corrent position
            public int playerXsize = 3;                // used for arrays, changeable
            public int playerYsize = 3;                // used for arrays, changeable
            public string playerFace = "right";                // stores what player is facing direction, constantly chaing  as game is played
            public int playerSpeed = 3;                    // how fast player will move, changes as level changes

            // Jumping and gravity 
            // jump attributes
            public int jumpsize = 5;                                // player will jump n - 1 bloacks
            public int tempJump = 0;                                // just a temp
            public bool currentJump = false;
            public bool jumpThisIteration = false;


            public bool isGun = false;         // so that player cannot shoot if he has not gun yet


            public string bulletShape = "#";                            // shape of bullet which will be launched

            public int playerMaxBulletAtATime = 2;                      // how many bullets can exist simultaneously
            public int playerBulletLength = 15;                         // how far bullet should go, unless stopped
            public int lengthAfterPlayer2ndBulletAllow = 7;           // just some calaulations
            public bool[] isPlayerBulletPresent = { false, false, false };               // to reuse same array
            public string[] playerBulletDirection = { "left", "left", "left" };    // directions based on face
            public int[] playerBulletX = { 0, 0, 0 };
            public int[] playerBulletY = { 0, 0, 0 };
            public int[] playerBulletDistanceCovered = { 0, 0, 0 };


            public void playerDeath(int x, int y)
            {
                Thread.Sleep(1000);
                erasePlayer();          // erase player from death spot, bccz needs to do this, bcz we are chaning coordinates, so it would be improssible to erase after altering them
                playerX = x;        // changing to default position for respawning
                playerY = y;
                decreaseScore();        // decrease svcore by increment variable
            }





            //   Player Firing  //
            public void playerFire()
            {

                if (isPlayerEligibleForFire("first") == Convert.ToBoolean(1))     // in case no fire has been shot
                {
                    isPlayerBulletPresent[0] = Convert.ToBoolean(1);       // say yes, there is indeed a fire
                    playerBulletDirection[0] = playerFace;          // set direction to move
                    if (playerBulletDirection[0] == "left")
                    {
                        playerBulletX[0] = playerX - 1;
                    }
                    else
                    {
                        playerBulletX[0] = playerX + playerXsize;
                    }
                    playerBulletY[0] = playerY + 1;
                    playerBulletDistanceCovered[0] = 0;
                }



                if (isPlayerEligibleForFire("next") == Convert.ToBoolean(1))    // in case of a fire has been shot
                {

                    for (int i = 0; i < playerMaxBulletAtATime; i++)
                    {
                        if (isPlayerBulletPresent[i] == Convert.ToBoolean(0))     // if bullet present, move according to face at that time
                        {
                            isPlayerBulletPresent[i] = Convert.ToBoolean(1);
                            playerBulletDirection[i] = playerFace;
                            if (i < 3)
                            {
                                if (playerBulletDirection[i] == "left")
                                {
                                    playerBulletX[i] = playerX - 1;
                                }
                                else
                                {
                                    playerBulletX[i] = playerX + playerXsize;
                                }
                                playerBulletY[i] = playerY + 1;
                                playerBulletDistanceCovered[i] = 0;
                                break;
                            }

                        }
                    }
                }
            }

            public bool isPlayerEligibleForFire(string order)
            {
                if (order == "first")      // return 1 if no bullet is fired by player
                {
                    for (int i = 0; i < playerMaxBulletAtATime; i++)
                    {
                        if (isPlayerBulletPresent[i] != Convert.ToBoolean(0))
                        {
                            return Convert.ToBoolean(0);
                        }
                    }
                    return Convert.ToBoolean(1);
                }
                else if (order == "next")        // returns 1 if some time has passed since player has shot last and now he can do a 2nd 🙄 
                {
                    int minDistance = playerBulletLength;  // setting how far bulet will go
                    for (int i = 0; i < playerMaxBulletAtATime; i++)
                    {
                        if (isPlayerBulletPresent[i] == Convert.ToBoolean(1))
                        {

                            int tempLength = playerBulletDistanceCovered[i];
                            if (tempLength < minDistance)
                            {
                                minDistance = tempLength;
                            }
                        }

                    }

                    if (minDistance > (lengthAfterPlayer2ndBulletAllow))           // this checks if there is a certains distance between last fired bullet and this 
                    {
                        return Convert.ToBoolean(1);
                    }
                    return Convert.ToBoolean(0);
                }
                return Convert.ToBoolean(0);
            }

            public void printPlayerBullet()
            {
                for (int i = 0; i < playerMaxBulletAtATime; i++)
                {
                    if (isPlayerBulletPresent[i] == Convert.ToBoolean(1))
                    {
                        Console.SetCursorPosition(playerBulletX[i], playerBulletY[i]);
                        Console.Write(bulletShape);
                    }
                }
            }

            public void movePlayerBullet()
            {
                for (int i = 0; i < playerMaxBulletAtATime; i++)
                {
                    if (isPlayerBulletPresent[i] == Convert.ToBoolean(1))
                    {
                        if (playerBulletDirection[i] == "left")
                        {
                            //   stop bullets and check for collision with enemy here
                            playerBulletX[i] -= 1;
                        }
                        else
                        {
                            //   stop bullets and check for collision with enemy here
                            playerBulletX[i] += 1;
                        }
                        playerBulletDistanceCovered[i] += 1;
                        if (playerBulletCollisionEnemy(playerBulletX[i], playerBulletY[i]) == Convert.ToBoolean(1))
                        {
                            increaseScore();
                            removePlayerBullet(i);
                        }
                        else if (getcharAtXy(playerBulletX[i], playerBulletY[i]) == wall)
                        {
                            removePlayerBullet(i);
                        }
                        else if (playerBulletDistanceCovered[i] == playerBulletLength)
                        {
                            removePlayerBullet(i);
                        }
                    }
                }

            }

            public void removePlayerBullet(int index)
            {
                isPlayerBulletPresent[index] = Convert.ToBoolean(0);
                playerBulletX[index] = 0;               // resetting array, i.e telling nre bullet there is space avail
                playerBulletY[index] = 0;
                playerBulletDistanceCovered[index] = 0;
            }

            public void erasePlayerBullet()
            {
                for (int i = 0; i < playerMaxBulletAtATime; i++)
                {
                    if (isPlayerBulletPresent[i] == Convert.ToBoolean(1))
                    {
                        Console.SetCursorPosition(playerBulletX[i], playerBulletY[i]);
                        for (int j = 0; j < bulletShape.Length; j++)
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }


            // player gravity and player jump
            public void Playerjump()
            {
                if (tempJump > 0)           // checking if jump already pressed
                {
                    tempJump -= 1;
                    if (tempJump == 0)       // enabling gravity again
                    {
                        currentJump = false;
                    }
                    // int currentTemp = int.Parse(detectPlayerCollision("up"));
                    int currentTemp = Convert.ToInt32(detectPlayerCollision("up"));
                    if ((currentTemp != 1))   // go up only if no wall above
                    {
                        playerY -= 1;
                    }
                }
            }

            public void playerGravity()
            {
                if (detectPlayerCollision("down") != Convert.ToBoolean(1) && currentJump == false)      // if not already jumping and no wall below, then apply gravity
                {
                    playerY += 1;
                    // printPlayer();
                }
            }



            // player collisions with walls
            public bool detectPlayerCollision(string direction)
            {
                if (direction == "left")            // dpends on directions 
                {
                    for (int i = 0; i < playerYsize; i++)
                    {
                        if (isNextCharWall(playerX - 1, playerY + i) == Convert.ToBoolean(1))       //  if wall in front, cant move farward,change course will ya 
                        {
                            return Convert.ToBoolean(1);
                        }
                    }
                    return Convert.ToBoolean(0);
                }

                else if (direction == "right")
                {
                    for (int i = 0; i < playerYsize; i++)
                    {
                        if (isNextCharWall(playerX + playerXsize, playerY + i) == Convert.ToBoolean(1))      //  if wall in front, cant move farward,change course will ya 
                        {
                            return Convert.ToBoolean(1);           // 1 means cannot go forward 
                        }
                    }
                    return Convert.ToBoolean(0);
                }

                else if (direction == "up")         // checking if we can go up, i.e which jumping 
                {
                    for (int i = 0; i < playerXsize; i++)
                    {
                        if (isNextCharWall(playerX + i, playerY - 1) == Convert.ToBoolean(1))
                        {
                            return Convert.ToBoolean(1);
                        }
                    }
                    return Convert.ToBoolean(0);     // remember me ?
                }

                if (direction == "down")            // checking if there is floor belw is 
                {
                    for (int i = 0; i < playerXsize; i++)
                    {
                        if (isNextCharWall(playerX + i, playerY + playerYsize) == Convert.ToBoolean(1))
                        {
                            return Convert.ToBoolean(1);
                        }
                    }
                    return Convert.ToBoolean(0);
                }
                return Convert.ToBoolean(0);

            }

            public bool isNextCharWall(int x, int y)           // basic simple functionality for if thetr e is a wall in giuven position 
            {
                if (getcharAtXy(x, y) == '*')
                {
                    return Convert.ToBoolean(1);
                }
                return Convert.ToBoolean(0);
            }



            // player functionality
            public void movePlayer(string direction)
            {
                erasePlayer();
                if (direction == "left")        // move player left if nothing on left
                {
                    if (detectPlayerCollision("left") != Convert.ToBoolean(1))     // check here if wall in fronyt
                    {
                        playerFace = "left";
                        playerX -= 1;
                    }
                }
                if (direction == "right")
                {
                    if (detectPlayerCollision("right") != Convert.ToBoolean(1))     // check here if wall in fronyt
                    {
                        playerFace = "right";
                        playerX += 1;
                    }
                }
                if (direction == "up")
                {
                    if (detectPlayerCollision("down") == Convert.ToBoolean(1) && currentJump == false)       // player on ground ( experimental player not already jumping, worked good, keeping it)
                    {
                        tempJump = jumpsize;
                        currentJump = true;
                    }
                }
                if (direction == "down")                 // fasll player if no floor bbelow
                {
                    if (detectPlayerCollision("down") != Convert.ToBoolean(1))
                    {
                        playerY += 1;
                    }
                }
            }



            // printing faculity
            public void printPlayer()
            {
                if (playerFace == "right")
                {
                    for (int i = 0; i < playerXsize; i++)
                    {
                        Console.SetCursorPosition(playerX, playerY + i);
                        for (int j = 0; j < playerYsize; j++)
                        {
                            Console.Write(playerArray[i, j]);
                        }
                    }
                }
                else if (playerFace == "left")
                {
                    for (int i = 0; i < playerXsize; i++)
                    {
                        Console.SetCursorPosition(playerX, playerY + i);
                        for (int j = playerYsize - 1; j >= 0; j--)
                        {
                            Console.Write(playerArray[i, j]);
                        }
                    }
                }


                Console.SetCursorPosition(playerX, playerY);  // returning to original position, to top left
            }

            public void erasePlayer()
            {
                for (int i = 0; i < playerYsize; i++)
                {
                    Console.SetCursorPosition(playerX, playerY + i);
                    Console.Write("   ");
                }
            }

        }


        // Player Attributes
        public static char wall = '*';            // what wall will liik like


        public static char[,] maze12dArray = {
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',},
        { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*',}
        };


        // Boss Attributes
        public static char[,] bossArray = { { 'b', 'b', 'b', 'b' }, { 'b', 'b', 'b', 'b' }, { 'b', 'b', 'b', 'b' }, { 'b', 'b', 'b', 'b' } };        // totally customizeable player array
        public static int bossXSize = 4;          // used for arrays, changeable
        public static int bossYSize = 4;          // used for arrays, changeable
        public static int bossX = 50;             // this will have boss corrent position
        public static int bossY = 50;             // this will have boss corrent position
        public static int lvl2BossCondition = 0;                  // this is used to keep track of how much lvl 2 oss animation has ben done
        public static int lvl2BossIteration = 0;                  // this is used to keep track of how much lvl 2 oss animation has ben done
        public static bool showlev2Boss = true;                  // this is used to keep track of how much lvl 2 oss animation has ben done
        public static bool showlev1Boss = false;                  // this is used to keep track of how much lvl 2 oss animation has ben done
        public static bool islvl1BossShown = false;                  // this is used to keep track of how much lvl 2 oss animation has ben done





        // public static char[,] enemy1Array = { { '4', '5', '>' }, { '0', '0', ' ' } };

        
        // public static int nrEmeny1 = 4;                                  // total nr of enemies
        /*
        public static bool[] isEnemy1alive = { true, true, true, true };                 // self explanatory
        */
        //public static int enemy1Xsize = 3;
        // public static int enemy1Ysize = 2;
        /*
        public static int[] enemy1X = { 49, 66, 49, 66 };                 // x axis of different enemies
        public static int[] enemy1Y = { 38, 38, 46, 46 };                 // y axis of different emeies
        public static string[] enemy1Face = { "left", "right", "left", "right" };     // in which direction they are facing right now
        */




        public static string enemyBulletShape = "+";              // shape of bullet which will be launched

        public static int enemy1BulletDistance = 13;              // how far enemy bullet will go
        public static int[] isEnemyBulletPresent = new int[25];               // keeps track of live and dead bullets, 1 for alive
        public static int[] emenyBulletX = new int[20];                      // keeps bullet information
        public static int[] emenyBulletY = new int[20];                       // keeps bullet information
        public static int[] enemyBulletXMovement = new int[20];           // keeps bullet information
        public static int[] enemyBulletYMovement = new int[20];           // keeps bullet information

        public static int[] enemyBulletLength = new int[20];                  // keeps bullet information




      //  public static string[,] enemy2Array = { { "7", "2" }, { "2", "2" }, { "2", "1" } };       // enemy2 shape, completely vchangeable by 1 click


//        public static int nrEmeny2 = 4;                                  // total nr of enemies
  //      public static int[] isEnemy2alive = { 1, 1, 0, 0 };                 // self explanatory
    //    public static int enemy2Xsize = 2;
      //  public static int enemy2Ysize = 3;
//        public static int[] enemy2X = { 50, 57, 0, 0 };                 // x axis of different enemies
  //      public static int[] enemy2Y = { 49, 26, 0, 0 };                 // y axis of different emeies
    //    public static string[] enemy2Face = { "left", "right", "left", "right" };     // in which direction they are facing right now


        public static int currentScore = 0;
        public static int scoreDecrement = 800;               // on player death, score to be deducted
        public static int scoreIncrement = 1000;              // on enemy death, score to be added


        public static int currentLevel = 1;           // // keeps track of what level player is on

        static List<enemy1_OOP> enemy1_list = new List<enemy1_OOP>();
        static List<enemy2_OOP> enemy2_list = new List<enemy2_OOP>();




        public static void Main(string[] args)
        {
            Console.ReadKey();
            initialize_enemy_1();
            initialize_enemy_2();
            startLevel1();
        }

        public static void initialize_enemy_1()
        {
        int nrEmeny1 = 4;                               
        bool[] isEnemy1alive = { true, true, true, true };      
        int[] enemy1X = { 49, 66, 49, 66 };                
        int[] enemy1Y = { 38, 38, 46, 46 };                 
        string[] enemy1Face = { "left", "right", "left", "right" };

            for (int i = 0; i < nrEmeny1; i++)
            {
                enemy1_OOP e1 = new enemy1_OOP();

                e1.isEnemy1alive = isEnemy1alive[i];

                e1.enemy1X = enemy1X[i];
                e1.enemy1Y = enemy1Y[i];

                e1.enemy1Face = enemy1Face[i];

                enemy1_list.Add(e1);
            }
        }

        public static void initialize_enemy_2()
        {
            int nrEmeny2 = 4;
            int[] isEnemy2alive = { 1, 1, 0, 0 }; ;
            int[] enemy2X = { 50, 57, 0, 0 };
            int[] enemy2Y = { 49, 26, 0, 0 };
            string[] enemy2Face = { "left", "right", "left", "right" };

            for (int i = 0; i < nrEmeny2; i++)
            {
                enemy2_OOP e2 = new enemy2_OOP();

                e2.isEnemy2alive = Convert.ToBoolean(isEnemy2alive[i]);

                e2.enemy2X = enemy2X[i];
                e2.enemy2Y = enemy2Y[i];

                e2.enemy2Face = enemy2Face[i];

                enemy2_list.Add(e2);
            }
        }

        public static void startLevel1()           // explained in lvl 2 and in above main when declaring
        {
            Player_OOP player = new Player_OOP();
            printMaze1();
            player.printPlayer();
            if (player.isGun == false)
            {
                printGun();
            }/*
            if (currentGameMode == "load")
            {
                loadAllData("load");
                currentGameMode = "newGame";
            }
            else
            {
                loadAllData("newGame");
            }*/

            int i = 0;
            while (true)
            {
                printScore();
                if (player.isGun == false)
                {
                    isOnGun(player);
                }

                if (i % player.playerSpeed == 0)
                {/*
                    if (Keyboard.IsKeyPressed(Key.Escape))
                    {
                        PauseMenuWithOptions();
                    }*/
                    if (Keyboard.IsKeyPressed(Key.LeftArrow))
                    {
                        player.movePlayer("left");
                    }
                    if (Keyboard.IsKeyPressed(Key.RightArrow))
                    {
                        player.movePlayer("right");
                    }
                    if (Keyboard.IsKeyPressed(Key.UpArrow))
                    {
                        player.movePlayer("up");
                    }
                    if (Keyboard.IsKeyPressed(Key.Space) && player.isGun == true)
                    {
                        if (getcharAtXy(player.playerX - 1, player.playerY + 1) != '*' && getcharAtXy(player.playerX + player.playerXsize, player.playerY + 1) != '*')
                            player.playerFire();
                    }
                    player.erasePlayer();
                    player.Playerjump();
                    player.playerGravity();
                    player.printPlayer();


                    // lev1BossMove();     // just for testing

                    if (showlev1Boss == true)
                    {
                        lev1BossMove();
                    }
                    else if (enemy1_list[0].isEnemy1alive == Convert.ToBoolean(0) && enemy1_list[1].isEnemy1alive == Convert.ToBoolean(0) && enemy1_list[2].isEnemy1alive == Convert.ToBoolean(0) && enemy1_list[3].isEnemy1alive == Convert.ToBoolean(0) &&  enemy2_list[0].isEnemy2alive == Convert.ToBoolean(0) && enemy2_list[1].isEnemy2alive == Convert.ToBoolean(0) && enemy2_list[2].isEnemy2alive == Convert.ToBoolean(0) && enemy2_list[3].isEnemy2alive == Convert.ToBoolean(0))
                    {
                        if (islvl1BossShown == false)
                            showlev1Boss = true;
                    }

                }

                if (i % 2 == 0)
                {
                    player.erasePlayerBullet();
                    player.movePlayerBullet();
                    player.printPlayerBullet();

                    eraseEnemyBullet();
                    moveEnemyBullet(player);
                    printEnemyBullet();

                    eraseEnemy2();
                    moveEnemy2();
                    printEnemy2();
                }

                if (i % 5 == 0)
                {
                    eraseEnemy1();
                    moveEnemy1();
                    printEnemy1();

                }

                if (enemyCollisionPlayer(player) == Convert.ToBoolean(1))
                {
                    player.playerDeath(player.respawnX, player.respawnY);
                }

                if (player.playerY > 32 && player.playerX > 103)
                {
                    break;
                }

                Thread.Sleep(20);
                i += 1;
                if (i == 100001)
                {
                    i = 1;
                }
            }
            Console.ReadKey();
            Console.Clear();
        }



        public static void lev1BossMove()           // explained in lvl 2 and in above main when declaring
        {

            bossX = 105;
            bossY = 32;
            for (int i = 0; i < 5; i++)
            {
                bossX -= 2;
                printBoss();
                Thread.Sleep(500);
                eraseBoss();
            }
            printBoss();
            Thread.Sleep(1000);
            eraseBoss();
            for (int i = 0; i < 5; i++)
            {
                bossX += 2;
                printBoss();
                Console.SetCursorPosition(bossX, bossY + 4);
                Console.Write("*****");
                Thread.Sleep(500);
                eraseBoss();
            }
            // Console.SetCursorPosition(103, 36);
            // Console.Write( "****";
            showlev1Boss = false;
            islvl1BossShown = true;
        }





        // ==============================//
        public static void moveEnemy2()
        {
            for (int i = 0; i < enemy2_list.Count; i++)
            {
                if (enemy2_list[i].isEnemy2alive == Convert.ToBoolean(1))      // checking if enemy alive, then move
                {
                    int enemyIndex = i;
                    if (collisionsEnemy2(enemyIndex, enemy2_list[enemyIndex].enemy2Face) == 1)     // if wall in front, vchange dircxtion of moviung 
                    {
                        if (enemy2_list[enemyIndex].enemy2Face == "left")
                        {
                            enemy2_list[enemyIndex].enemy2Face = "right";
                            // enemy2Fire(enemyIndex);
                        }
                        else
                        {
                            enemy2_list[enemyIndex].enemy2Face = "left";
                            // enemy1Fire(enemyIndex);
                        }
                    }
                    else        // if clear in fromnt, move
                    {
                        if (enemy2_list[enemyIndex].enemy2Face == "right")
                        {
                            enemy2_list[enemyIndex].enemy2X += 1;
                        }
                        else if (enemy2_list[enemyIndex].enemy2Face == "left")
                        {
                            enemy2_list[enemyIndex].enemy2X -= 1;
                        }
                    }

                }

            }

        }

        public static int collisionsEnemy2(int enemyNumber, string direction)
        {
            if (direction == "left")        // if enemy direction is left, then checks on left
            {
                for (int i = 0; i < enemy2_list[0].enemy2Ysize + 1; i++)         // if in front of enemy is wall, return 1
                {
                    if (i == enemy2_list[0].enemy2Ysize)
                    {
                        if (getcharAtXy(enemy2_list[enemyNumber].enemy2X - 1, enemy2_list[enemyNumber].enemy2Y + i) != '*')
                        {
                            return 1;
                        }
                    }
                    else if (getcharAtXy(enemy2_list[enemyNumber].enemy2X - 1, enemy2_list[enemyNumber].enemy2Y + i) == '*')
                    {
                        return 1;
                    }
                }
                return 0;
            }

            else if (direction == "right")          // if enemy direction is on right, check on right then, not on nleft, it will cause a bug otherwise
            {
                for (int i = 0; i < enemy2_list[0].enemy2Ysize + 1; i++)
                {
                    if (i == enemy2_list[0].enemy2Ysize)
                    {
                        if (getcharAtXy(enemy2_list[enemyNumber].enemy2X + enemy2_list[0].enemy2Xsize, enemy2_list[enemyNumber].enemy2Y + i) != '*')
                        {
                            return 1;
                        }
                    }
                    else if (getcharAtXy(enemy2_list[enemyNumber].enemy2X + enemy2_list[0].enemy2Xsize, enemy2_list[enemyNumber].enemy2Y + i) == '*')
                    {
                        return 1;
                    }
                }
                return 0;
            }
            return 0;

        }


        public static void printEnemy2()
        {
            for (int k = 0; k < enemy2_list.Count; k++)
            {
                if (enemy2_list[k].isEnemy2alive == Convert.ToBoolean(1))      // pring only if alive
                {
                    if (enemy2_list[k].enemy2Face == "right")           // print according to face direwction
                    {
                        for (int i = 0; i < enemy2_list[k].enemy2Ysize; i++)
                        {
                            Console.SetCursorPosition(enemy2_list[k].enemy2X, enemy2_list[k].enemy2Y + i);
                            for (int j = 0; j < enemy2_list[k].enemy2Xsize; j++)
                            {
                                if (i == 1 && j == 1)
                                {
                                    Console.Write("/");
                                }
                                else if (i == 2 && j == 1)
                                {
                                    Console.Write("{");
                                }
                                else
                                {
                                    char tempCharacter = char.Parse(enemy2_list[k].enemy2Array[i, j]);
                                    Console.Write(tempCharacter);
                                }

                            }
                        }
                    }
                    else if (enemy2_list[k].enemy2Face == "left")           // print according to face direwction
                    {
                        for (int i = 0; i < enemy2_list[k].enemy2Ysize; i++)
                        {
                            Console.SetCursorPosition(enemy2_list[k].enemy2X, enemy2_list[k].enemy2Y + i);
                            for (int j = enemy2_list[k].enemy2Xsize - 1; j >= 0; j--)
                            {
                                char tempCharacter = char.Parse(enemy2_list[k].enemy2Array[i, j]);
                                Console.Write(tempCharacter);
                            }
                        }
                    }
                }
            }

        }

        public static void eraseEnemy2()
        {
            for (int i = 0; i < enemy2_list.Count; i++)
            {
                if (enemy2_list[i].isEnemy2alive == Convert.ToBoolean(1))
                {
                    Console.SetCursorPosition(enemy2_list[i].enemy2X, enemy2_list[i].enemy2Y);
                    Console.Write("  ");
                    Console.SetCursorPosition(enemy2_list[i].enemy2X, enemy2_list[i].enemy2Y + 1);
                    Console.Write("  ");
                    Console.SetCursorPosition(enemy2_list[i].enemy2X, enemy2_list[i].enemy2Y + 2);
                    Console.Write("  ");
                }
            }
        }



        //===============================//

        // enemy 1 fire  
        public static void enemy1Fire(int enemyIndex)
        {
            for (int i = 0; i < 19; i++)    // 20 bcz we have space for 20 arrays, ehich is already enough
            {
                if (emenyBulletX[i] == 0 && emenyBulletY[i] == 0)
                {
                    isEnemyBulletPresent[i] = 1;
                    if (enemy1_list[enemyIndex].enemy1Face == "right")     
                    {
                        emenyBulletX[i] = enemy1_list[enemyIndex].enemy1X + enemy1_list[enemyIndex].enemy1Xsize;
                        emenyBulletY[i] = enemy1_list[enemyIndex].enemy1Y;
                        enemyBulletXMovement[i] = 1;
                        // enemy1X[enemyIndex] -=1;
                    }
                    else
                    {
                        emenyBulletX[i] = enemy1_list[enemyIndex].enemy1X - 1;
                        emenyBulletY[i] = enemy1_list[enemyIndex].enemy1Y;
                        enemyBulletXMovement[i] = -1;
                    }
                    enemyBulletYMovement[i] = 0;
                    enemyBulletLength[i] = enemy1BulletDistance;
                    break;
                }
            }
        }

        public static void moveEnemyBullet(Player_OOP player)
        {
            for (int i = 0; i < 21; i++)
            {
                if (isEnemyBulletPresent[i] == 1)
                {
                    emenyBulletX[i] += enemyBulletXMovement[i];     // moves bullet in a direction , specified when shoot, bcz obviously it wont go in snake, its straight line
                    emenyBulletX[i] += enemyBulletYMovement[i];     // no y used in this version., intuition was that so we can shot diagonal
                    if (enemyBulletCollisionPlayer(emenyBulletX[i], emenyBulletY[i], player) == Convert.ToBoolean(1))
                    {
                        removeEnemyBullet(i);
                        player.playerDeath(player.respawnX, player.respawnY);
                    }
                    else if (getcharAtXy(emenyBulletX[i], emenyBulletY[i]) == wall)        // if collide wall, delete
                    {
                        removeEnemyBullet(i);
                    }
                    else
                    {
                        enemyBulletLength[i] -= 1;
                        if (enemyBulletLength[i] == 0)
                        {
                            removeEnemyBullet(i);
                        }
                    }
                }
            }
        }

        public static void removeEnemyBullet(int i)
        {
            isEnemyBulletPresent[i] = 0;
            emenyBulletX[i] = 0;
            emenyBulletY[i] = 0;
            enemyBulletXMovement[i] = 0;
            enemyBulletYMovement[i] = 0;

        }

        public static void printEnemyBullet()
        {
            for (int i = 0; i < 21; i++)
            {
                if (isEnemyBulletPresent[i] == 1)
                {
                    Console.SetCursorPosition(emenyBulletX[i], emenyBulletY[i]);

                    Console.Write(enemyBulletShape);
                }
            }
        }

        public static void eraseEnemyBullet()
        {
            for (int i = 0; i < 21; i++)
            {
                if (isEnemyBulletPresent[i] == 1)
                {
                    Console.SetCursorPosition(emenyBulletX[i], emenyBulletY[i]);
                    for (int j = 0; j < enemyBulletShape.Length; j++)
                    {
                        Console.Write(" ");
                    }
                }
            }
        }


        // collisions section
        public static bool enemyBulletCollisionPlayer(int x, int y, Player_OOP player)
        {
            if ((x >= player.playerX && x <= (player.playerX + player.playerXsize - 1)) && (y >= player.playerY && y <= (player.playerY + player.playerYsize - 1)))
            {
                return Convert.ToBoolean(1);
            }
            return Convert.ToBoolean(0);
        }

        public static bool playerBulletCollisionEnemy(int x, int y)
        {
            char temp = getcharAtXy(x, y);
            for (int i = 0; i < enemy1_list.Count; i++)
            {
                if ((x >= enemy1_list[i].enemy1X && x <= (enemy1_list[i].enemy1X + enemy1_list[i].enemy1Xsize - 1)) && (y >= enemy1_list[i].enemy1Y && y <= (enemy1_list[i].enemy1Y + enemy1_list[i].enemy1Ysize - 1)))
                {
                    eraseEnemy1();
                    enemy1_list[i].enemy1X = 0;
                    enemy1_list[i].enemy1Y = 0;
                    enemy1_list[i].isEnemy1alive = Convert.ToBoolean(0);
                    printEnemy1();
                    return Convert.ToBoolean(1);
                }
            }
            for (int i = 0; i < enemy2_list.Count; i++)
            {
                if ((x >= enemy2_list[i].enemy2X && x <= (enemy2_list[i].enemy2X + enemy2_list[i].enemy2Xsize - 1)) && (y >= enemy2_list[i].enemy2Y && y <= (enemy2_list[i].enemy2Y + enemy2_list[i].enemy2Ysize - 1)))
                {
                    eraseEnemy2();
                    enemy2_list[i].enemy2X = 0;
                    enemy2_list[i].enemy2Y = 0;
                    enemy2_list[i].isEnemy2alive = Convert.ToBoolean(0);
                    printEnemy2();
                    return Convert.ToBoolean(1);
                }
            }
            return Convert.ToBoolean(0);

        }

        public static bool enemyCollisionPlayer(Player_OOP player)
        {
            for (int i = 0; i < enemy1_list.Count; i++)
            {
                int enemyx = enemy1_list[i].enemy1X;
                int enemyy = enemy1_list[i].enemy1Y;

                for (int j = 0; j < enemy1_list[i].enemy1Xsize; j++)       // cehcking if axis of enemy 1 matches withp player
                {
                    for (int k = 0; k < player.playerXsize; k++)
                    {
                        if ((enemyx + j == player.playerX + k) && (enemyy == player.playerY + (player.playerYsize - 1)))
                        {
                            return Convert.ToBoolean(1);
                        }
                        if ((enemyx + j == player.playerX + k) && ((enemyy + (enemy1_list[i].enemy1Ysize - 1)) == player.playerY))
                        {
                            return Convert.ToBoolean(1);
                        }
                    }
                }
                for (int j = 0; j < enemy1_list[i].enemy1Ysize; j++)       // cehcking if axis of enemy 1 matches withp player
                {
                    for (int k = 0; k < player.playerYsize; k++)
                    {
                        if ((enemyx == player.playerX + (player.playerXsize - 1)) && (enemyy + j == player.playerY + k))
                        {
                            return Convert.ToBoolean(1);
                        }

                        if ((enemyx + (enemy1_list[i].enemy1Xsize - 1) == player.playerX) && (enemyy + j == player.playerY + k))
                        {
                            return Convert.ToBoolean(1);
                        }
                    }
                }
            }

            for (int i = 0; i < enemy2_list.Count; i++)// cehcking if axis of enemy 2 matches withp player
            {
                int enemyx = enemy2_list[i].enemy2X;
                int enemyy = enemy2_list[i].enemy2Y;

                for (int j = 0; j < enemy2_list[i].enemy2Xsize; j++)
                {
                    for (int k = 0; k < player.playerXsize; k++)
                    {
                        if ((enemyx + j == player.playerX + k) && (enemyy == player.playerY + (player.playerYsize - 1)))
                        {
                            return Convert.ToBoolean(1);
                        }
                        if ((enemyx + j == player.playerX + k) && ((enemyy + (enemy2_list[i].enemy2Ysize - 1)) == player.playerY))
                        {
                            return Convert.ToBoolean(1);
                        }
                    }
                }
                for (int j = 0; j < enemy2_list[i].enemy2Ysize; j++)// cehcking if axis of enemy 1 matches withp player
                {
                    for (int k = 0; k < player.playerYsize; k++)
                    {
                        if ((enemyx == player.playerX + (player.playerXsize - 1)) && (enemyy + j == player.playerY + k))
                        {
                            return Convert.ToBoolean(1);
                        }

                        if ((enemyx + (enemy2_list[i].enemy2Xsize - 1) == player.playerX) && (enemyy + j == player.playerY + k))
                        {
                            return Convert.ToBoolean(1);
                        }
                    }
                }
            }
            return Convert.ToBoolean(0);
        }

        public static int collisionsEnemy1(int enemyNumber, string direction)// cehcking if axis of enemy 1 matches withp player
        {
            if (direction == "left")
            {
                for (int i = 0; i < enemy1_list[0].enemy1Ysize + 1; i++)
                {
                    if (i == enemy1_list[0].enemy1Ysize)
                    {
                        if (getcharAtXy(enemy1_list[enemyNumber].enemy1X - 1, enemy1_list[enemyNumber].enemy1Y + i) != '*')
                        {
                            return 1;
                        }
                    }
                    else if (getcharAtXy(enemy1_list[enemyNumber].enemy1X - 1, enemy1_list[enemyNumber].enemy1Y + i) == '*')
                    {
                        return 1;
                    }
                }
                return 0;
            }

            else if (direction == "right")
            {
                for (int i = 0; i < enemy1_list[0].enemy1Ysize + 1; i++)
                {
                    if (i == enemy1_list[0].enemy1Ysize)
                    {
                        if (getcharAtXy(enemy1_list[enemyNumber].enemy1X + enemy1_list[0].enemy1Xsize, enemy1_list[enemyNumber].enemy1Y + i) != '*')
                        {
                            return 1;
                        }
                    }
                    else if (getcharAtXy(enemy1_list[enemyNumber].enemy1X + enemy1_list[0].enemy1Xsize, enemy1_list[enemyNumber].enemy1Y + i) == '*')
                    {
                        return 1;
                    }
                }
                return 0;
            }
            return 0;

        }


        // enemy options //



        public static void moveEnemy1()
        {
            for (int i = 0; i < enemy1_list.Count; i++)
            {
                if (enemy1_list[i].isEnemy1alive == Convert.ToBoolean(1))  // move only if alive
                {
                    int enemyIndex = i;
                    if (collisionsEnemy1(enemyIndex, enemy1_list[enemyIndex].enemy1Face) == 1)     // if wall in fornt, then change dirctions
                    {
                        if (enemy1_list[enemyIndex].enemy1Face == "left")
                        {
                            enemy1_list[enemyIndex].enemy1Face = "right";
                            enemy1Fire(enemyIndex);
                        }
                        else
                        {
                            enemy1_list[enemyIndex].enemy1Face = "left";      // if wall in fornt, then change dirctions
                            enemy1Fire(enemyIndex);
                        }
                    }
                    else            // if clear in front, then just omve forward
                    {
                        if (enemy1_list[enemyIndex].enemy1Face == "right")
                        {
                            enemy1_list[enemyIndex].enemy1X += 1;
                        }
                        else if (enemy1_list[enemyIndex].enemy1Face == "left")
                        {
                            enemy1_list[enemyIndex].enemy1X -= 1;
                        }
                    }

                }

            }

        }

        public static void printEnemy1()
        {
            for (int k = 0; k < enemy1_list.Count; k++)  // looping all enemies in array
            {
                if (enemy1_list[k].isEnemy1alive == Convert.ToBoolean(1))
                {
                    if (currentLevel == 3 && k == 3)  // we have special tratment for 3 in lvl 3, i.e fliying fdouble shooter
                    {
                        for (int i = 0; i < enemy1_list[k].enemy1Ysize; i++)
                        {
                            Console.SetCursorPosition(enemy1_list[k].enemy1X, enemy1_list[k].enemy1Y + i);
                            for (int j = 0; j < enemy1_list[k].enemy1Xsize; j++)
                            {
                                Console.Write(enemy1_list[k].enemy1Array[i, j]);
                            }
                        }
                    }
                    else if (enemy1_list[k].enemy1Face == "right")      // print according to face firection 
                    {
                        for (int i = 0; i < enemy1_list[k].enemy1Ysize; i++)
                        {
                            Console.SetCursorPosition(enemy1_list[k].enemy1X, enemy1_list[k].enemy1Y + i);
                            for (int j = 0; j < enemy1_list[k].enemy1Xsize; j++)
                            {
                                Console.Write(enemy1_list[k].enemy1Array[i, j]);
                            }
                        }
                    }
                    else if (enemy1_list[k].enemy1Face == "left")
                    {
                        for (int i = 0; i < enemy1_list[k].enemy1Ysize; i++)
                        {
                            Console.SetCursorPosition(enemy1_list[k].enemy1X, enemy1_list[k].enemy1Y + i);
                            for (int j = enemy1_list[k].enemy1Xsize - 1; j >= 0; j--)
                            {
                                if (i == 0 && j == 2)
                                {
                                    Console.Write("<");
                                }
                                else
                                {
                                    Console.Write(enemy1_list[k].enemy1Array[i, j]);
                                }
                            }
                        }
                    }
                }
            }

        }

        public static void eraseEnemy1()
        {
            for (int i = 0; i < enemy1_list.Count; i++)
            {
                if (enemy1_list[i].isEnemy1alive == Convert.ToBoolean(1))
                {
                    Console.SetCursorPosition(enemy1_list[i].enemy1X, enemy1_list[i].enemy1Y);
                    Console.Write("   ");
                    Console.SetCursorPosition(enemy1_list[i].enemy1X, enemy1_list[i].enemy1Y + 1);
                    Console.Write("   ");
                }
            }
        }





        public static void printMaze1()
        {
            Console.SetCursorPosition(0, 15);
            for (int i = 0; i < 38; i++)
            {
                for (int j = 0; j < 103; j++)
                {
                    Console.Write(maze12dArray[i, j]);
                }
                Console.WriteLine();
            }
        }



        public static void printBoss()
        {

            Console.SetCursorPosition(bossX, bossY);
            Console.Write("BOSS");
            Console.SetCursorPosition(bossX, bossY + 1);
            Console.Write("BOSS");
            Console.SetCursorPosition(bossX, bossY + 2);
            Console.Write("BOSS");
            Console.SetCursorPosition(bossX, bossY + 3);
            Console.Write("BOSS");
        }
        public static void eraseBoss()
        {
            Console.SetCursorPosition(bossX, bossY);
            Console.Write("    ");
            Console.SetCursorPosition(bossX, bossY + 1);
            Console.Write("    ");
            Console.SetCursorPosition(bossX, bossY + 2);
            Console.Write("    ");
            Console.SetCursorPosition(bossX, bossY + 3);
            Console.Write("    ");
        }







        public static void printGun()
        {
            Console.SetCursorPosition(57, 23);
            Console.Write("Gun");
            Console.SetCursorPosition(57, 24);
            Console.Write("Gun");
        }
        public static void eraseGun()
        {
            Console.SetCursorPosition(57, 23);
            Console.Write("   ");
            Console.SetCursorPosition(57, 24);
            Console.Write("   ");
        }

        public static int isOnGun(Player_OOP player)
        {
            if (player.playerX == 57 || player.playerX == 58 || player.playerX == 59 || player.playerX + 2 == 57 || player.playerX + 2 == 58 || player.playerX + 2 == 59)
            {
                if (player.playerY == 23 || player.playerY == 22 || player.playerY == 21)
                {
                    eraseGun();
                    player.isGun = true;
                    return 1;

                }
            }
            return 0;
        }

        public static void increaseScore()
        {
            currentScore += scoreIncrement;
        }
        public static void decreaseScore()
        {
            currentScore -= scoreDecrement;
        }
        public static void printScore()
        {
            Console.SetCursorPosition(50, 18);
            Console.Write("             ");
            Console.SetCursorPosition(50, 18);
            Console.Write("SCORE: {0}", currentScore);
        }

        // =======================================================//






        private const int STD_OUTPUT_HANDLE = -11;

        public static char getcharAtXy(int x1, int y1)
        {
            Int16 x = (Int16)x1;
            Int16 y = (Int16)y1;
            uint length = 1;
            var characters = new StringBuilder(1);
            uint numberOfCharactersRead;

            if (ReadConsoleOutputCharacter(GetStdHandle(STD_OUTPUT_HANDLE), characters, length, new Coord(x, y), out numberOfCharactersRead))
                //return char.Parse(characters.ToString());
                return (characters.ToString())[0];

            throw new InvalidOperationException("Could not get chars");
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadConsoleOutputCharacter(IntPtr hConsoleOutput, [Out] StringBuilder lpCharacter, uint length, Coord bufferCoord, out uint lpNumberOfCharactersRead);

        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
            public short X;
            public short Y;

            public Coord(short x, short y)
            {
                X = x;
                Y = y;
            }
        }


        // ======================================================= //










    }
}
