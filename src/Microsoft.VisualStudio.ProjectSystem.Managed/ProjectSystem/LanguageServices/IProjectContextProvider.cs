﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.LanguageServices.ProjectSystem;

namespace Microsoft.VisualStudio.ProjectSystem.LanguageServices
{
    /// <summary>
    ///     Creates and handles releasing <see cref="IWorkspaceProjectContext"/> instances based on the 
    ///     current <see cref="UnconfiguredProject"/>.
    /// </summary>
    internal interface IProjectContextProvider
    {
        /// <summary>
        ///     Creates a <see cref="IWorkspaceProjectContext"/>.
        /// </summary>
        /// <returns>
        ///     The created <see cref="IWorkspaceProjectContext"/> or <see langword="null"/> if it could
        ///     not be created due to the project targeting an unrecognized language.
        /// </returns>
        /// <remarks>
        ///     When finished with the return <see cref="IWorkspaceProjectContext"/>, callers must call 
        ///     <see cref="ReleaseProjectContextAsync(IWorkspaceProjectContext)"/>.
        /// </remarks>
        Task<IWorkspaceProjectContext> CreateProjectContextAsync();

        /// <summary>
        ///     Releases a previously created <see cref="IWorkspaceProjectContext"/>.
        /// </summary>
        /// <param name="context">
        ///     The <see cref="IWorkspaceProjectContext"/> to release.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="context"/> was not created via <see cref="CreateProjectContextAsync"/> or 
        ///     has already been unregistered.
        /// </exception>
        Task ReleaseProjectContextAsync(IWorkspaceProjectContext context);
    }
}
