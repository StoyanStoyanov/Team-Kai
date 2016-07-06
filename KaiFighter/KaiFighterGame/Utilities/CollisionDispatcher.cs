namespace KaiFighterGame.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

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
                for (int j = i + 1; j < myObjectList.Count; j++)
                {

                    if (myObjectList[i].BoundingBox.Intersects(myObjectList[j].BoundingBox))
                    {
                        myObjectList[i].RespondToCollision(myObjectList[j]);
                        myObjectList[j].RespondToCollision(myObjectList[i]);
                    }
                }
            }
        }
    }
}