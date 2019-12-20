// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Abstractions
{
    /*
        Enumeración de LoggerInterval
        Contiene los intervalos de creación de los archivos del logeo de errores
    */

    /// <summary>
    /// Enumeración de <c>LoggerInterval</c>.
    /// Contiene los intervalos de creación de los archivos del logeo de errores.
    /// </summary>
    /// <remarks>
    /// <para>En esta enumeración se pueden agregar todos los intervalos de creación de archivos del logeo de errores.</para>
    /// </remarks>
    public enum LoggerInterval
    {
        /// <summary>
        /// El archivo de registro nunca cambiara; no se agregará información de período de tiempo a el nombre del archivo de registro.
        /// </summary>
        Infinite = 0,

        /// <summary>
        /// El archivo de registro cambiará todos los años. Los nombres de archivo tendrán el patrón yyyy anexados.
        /// </summary>
        Year = 1,

        /// <summary>
        /// El archivo de registro cambiará cada mes calendario. Los nombres de archivo tendrán el patrón yyyyMM anexados.
        /// </summary>
        Month = 2,

        /// <summary>
        /// El archivo de registro cambiará todos los días. Los nombres de archivo tendrán el patrón yyyyMMdd anexados.
        /// </summary>
        Day = 3,

        /// <summary>
        /// El archivo de registro cambiará cada hora. Los nombres de archivo tendrán el patrón yyyyMMddHH anexados.
        /// </summary>
        Hour = 4,

        /// <summary>
        /// El archivo de registro cambiará cada minuto. Los nombres de archivo tendrán el patrón yyyyMMddHHmm anexados.
        /// </summary>
        Minute = 5,
    }
}
