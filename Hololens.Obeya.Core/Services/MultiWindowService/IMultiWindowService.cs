namespace Hololens.Obeya.Core.Services.MultiWindowService
{
    using Enums;
    using System.Threading.Tasks;

    /// <summary>
    /// Contract definition for window management.
    /// </summary>
    public interface IMultiWindowService
    {
        /// <summary>
        /// Open the desired screen on a new window.
        /// </summary>
        /// <param name="screen">screen type to open.</param>
        /// <returns>true if opened, false otherwise.</returns>
        Task<bool> OpenNewWindowForScreen(ScreenTypes screen);

        /// <summary>
        /// Get app title for desired screen
        /// </summary>
        /// <param name="screen">screen type to open.</param>
        /// <returns>Title</returns>
        string GetPageTitleByScreen(ScreenTypes screen);
    }
}
