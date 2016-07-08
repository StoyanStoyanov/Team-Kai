namespace KaiFighterGame.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// All objects which can produce other objects must implement this interface.
    /// </summary>
    public interface IProducable<T>
    {
        /// <summary>
        /// Returns the objects which are produced by the object.
        /// </summary>
        IEnumerable<T> ProduceObjects();
    }
}