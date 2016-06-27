namespace KaiFighterGame.Utilities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Handles the collisions between objects.
    /// </summary>
    public static class CollisionDispatcher
    {
        /// <summary>
        /// This Method is invoked on every redraw of the Objects
        /// </summary>
        /// <param name="myObjectList"></param>

        public static void CheckCollision(List<GameObject> myObjectList)
        {
            var collidedList = new List<GameObject>();
            for (int i = 0; i < myObjectList.Count - 1; i++)
            {

                // The variable names will be chanched
                var ax1 = myObjectList[i].PositionX;
                var ax2 = myObjectList[i].PositionX + myObjectList[i].Width;
                var ax3 = ax1;
                var ax4 = ax2;

                var ay1 = myObjectList[i].PositionY;
                var ay2 = myObjectList[i].PositionY + myObjectList[i].Height;
                var ay3 = ay1;
                var ay4 = ay2;


                for (int j = i + 1; j < myObjectList.Count; j++)
                {
                    var bx1 = myObjectList[j].PositionX;
                    var bx2 = myObjectList[j].PositionX + myObjectList[i].Width;
                    var bx3 = ax1;
                    var bx4 = ax2;

                    var by1 = myObjectList[j].PositionY;
                    var by2 = myObjectList[j].PositionY + myObjectList[i].Height;
                    var by3 = ay1;
                    var by4 = ay2;

                    var hOverLap = true;
                    bool isColide = false;
                    if (ax1 < bx1 && ax2 < bx1)
                    {
                        hOverLap = false;
                    }

                    if (ax1 > bx2 && ax2 > bx2)
                    {
                        hOverLap = false;
                    }

                    var vOverLap = true;

                    if (ay1 < by1 && ay3 < ay1)
                    {
                        vOverLap = false;
                    }

                    if (ay1 > by3 && ay3 > by3)
                    {
                        vOverLap = false;
                    }

                    if (vOverLap && hOverLap)
                    {
                        isColide = true;
                        myObjectList[i].RespondToCollision(myObjectList[j]);
                        myObjectList[j].RespondToCollision(myObjectList[i]);
                    }
                }
            }
        }
    }
}