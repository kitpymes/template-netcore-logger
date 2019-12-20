// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Abstractions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /*
        Clase de extensión LoggerExtensions
        Contiene las extensiones del logeo de errores
    */

    /// <summary>
    /// Clase de extensión <c>LoggerExtensions</c>.
    /// Contiene las extensiones del logeo de errores.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para el logeo de errores.</para>
    /// </remarks>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Combina las opciones personalizadas <paramref name="customOptions"/> de una acción con las opciones por defecto <paramref name="defaultOptions"/>.
        /// </summary>
        /// <typeparam name="TOptions">Es de tipo class.</typeparam>
        /// <param name="customOptions">Opciones personalizadas.</param>
        /// <param name="defaultOptions">Opcionces por defecto.</param>
        /// <returns>
        /// Las opciones combinadas.
        /// </returns>
        [return: NotNull]
        public static TOptions ToConfigureOrDefault<TOptions>(this Action<TOptions> customOptions, TOptions? defaultOptions = null)
            where TOptions : class, new()
        {
            defaultOptions ??= new TOptions();

            customOptions?.Invoke(defaultOptions);

            return defaultOptions;
        }

        /// <summary>
        /// Convierte un número en string.
        /// </summary>
        /// <param name="number">El número a convertir en string.</param>
        /// <param name="formatProvider">El formato que se aplica a la conversión.</param>
        /// <returns>El número convertido en string.</returns>
        [return: NotNull]
        public static string ToStringFormat(this int number, IFormatProvider? formatProvider = null)
        {
            formatProvider ??= CultureInfo.CurrentCulture;

            return number.ToString(formatProvider);
        }
    }
}
