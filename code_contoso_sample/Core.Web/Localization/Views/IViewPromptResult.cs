using System.Collections.Generic;

namespace Core.Web.Localization.Views
{
    /// <summary>
    /// Query result
    /// </summary>
    public interface IViewPromptResult
    {
        /// <summary>
        /// Get matching items
        /// </summary>
        IEnumerable<ViewPrompt> Items { get; }

        /// <summary>
        /// Gets total count (useful when paging is used)
        /// </summary>
        int TotalCount { get; }
    }
}