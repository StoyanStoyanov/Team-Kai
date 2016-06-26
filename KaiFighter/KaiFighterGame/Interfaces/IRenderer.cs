namespace KaiFighterGame.Interfaces
{
    /// <summary>
    /// All types of renderers must implement this interface.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Enqueues and object in the rendering queue.
        /// </summary>
        /// <param name="obj">The object to be enqueued</param>
        void EnqueueForRendering(IRenderable obj);

        /// <summary>
        /// Renders all objects.
        /// </summary>
        void RenderAllObjects();

        /// <summary>
        /// Clears the rendering queue.
        /// </summary>
        void ClearQueue();
    }
}