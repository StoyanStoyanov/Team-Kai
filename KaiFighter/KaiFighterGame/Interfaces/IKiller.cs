namespace KaiFighterGame.Interfaces
{
    /// <summary>
    /// All unit who can damage other units must implement this interface.
    /// </summary>
    public interface IKiller
    {
        /// <summary>
        /// Determines how much damage can the object deal.
        /// </summary>
        double Damage { get; set; }
    }
}