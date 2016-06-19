namespace KaiFighterGame.Utilities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Handles the collisions among between objects.
    /// </summary>
    public static class CollisionDispatcher
    {
        ///// <summary>
        ///// Checks if there are collision between the objects in the game.
        ///// If collisions are found, then the ResponceToCollision methods are called for the objects
        ///// which collide.
        ///// </summary>
        public static void HandleCollisions(List<StaticObject> staticObjects, List<DynamicObject> movingObjects)
        {
            HandleStaticWithMovingCollisions(staticObjects, movingObjects);
            HandleMovingWithMovingCollisions(movingObjects);
        }

        /// <summary>
        /// Checks for collisions between the static and the moving objects in the game.
        /// </summary>
        private static void HandleMovingWithMovingCollisions(List<DynamicObject> movingObjects)
        {
            // TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks for collisions between the moving objects in the game.
        /// </summary>
        private static void HandleStaticWithMovingCollisions(List<StaticObject> staticObjects, List<DynamicObject> movingObjects)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}