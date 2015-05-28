﻿using System.Collections.Generic;

namespace Core.Web.Localization.Types
{
    /// <summary>
    /// Used to import prompts from an external source.
    /// </summary>
    public interface ITypePromptImporter
    {
        /// <summary>
        /// Import prompts into the repository.
        /// </summary>
        /// <param name="prompts">Prompts to import</param>
        /// <remarks>All prompts should overwrite any existing prompts.</remarks>
        void Import(IEnumerable<TypePrompt> prompts);

    }
}
