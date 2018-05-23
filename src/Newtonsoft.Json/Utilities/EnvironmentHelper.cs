using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Newtonsoft.Json.Utilities
{
    //Thanks to notour: https://github.com/Arkatufus/akka.net/pull/2

    /// <summary>
    /// Provide helpers to check the environment where the serializer is currently running
    /// </summary>
    internal static class EnvironmentHelper
    {
        #region Ctor

        /// <summary>
        /// Initializes the <see cref="EnvironmentHelper"/> class.
        /// </summary>
        static EnvironmentHelper()
        {
            RuntimeNetCoreVersion = GetNetCoreVersion();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the runtime net core version.
        /// </summary>
        /// <remarks>
        ///     If the RuntimeNetCoreVersion is null the system akka is running on a .net Classic environment
        /// </remarks>
        public static string RuntimeNetCoreVersion { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the net core version.
        /// </summary>
        private static string GetNetCoreVersion()
        {
            var assembly = typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly;
            var assemblyPath = assembly.CodeBase.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            int netCoreAppIndex = Array.IndexOf(assemblyPath, "Microsoft.NETCore.App");
            if (netCoreAppIndex > 0 && netCoreAppIndex < assemblyPath.Length - 2)
                return assemblyPath[netCoreAppIndex + 1];
            return null;
        }

        #endregion

    }
}
