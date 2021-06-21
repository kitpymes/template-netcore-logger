// -----------------------------------------------------------------------
// <copyright file="SerilogSqlServerSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger.Serilog
{
    using Kitpymes.Core.Logger.Abstractions;

    /*
        Clase de configuración SerilogSqlServerSettings
        Contiene la configuración del logeo de errores de SqlServer
    */

    /// <summary>
    /// Clase de configuración <c>SerilogSqlServerSettings</c>.
    /// Contiene la configuración del logeo de errores de SqlServer.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las configuraciones para el logeo de errores de SqlServer.</para>
    /// </remarks>
    public class SerilogSqlServerSettings
    {
        /// <summary>
        /// Si el logeo de errores de la base de datos esta habiliato.
        /// </summary>
        public const bool DefaultEnabled = false;

        /// <summary>
        /// Nombre del esquema de la tabla donde se guardaran los errores.
        /// </summary>
        public const string DefaultSchemaName = "dbo";

        /// <summary>
        /// Nombre de la de la tabla donde se guardaran los errores.
        /// </summary>
        public const string DefaultTableName = "Log";

        /// <summary>
        /// Nivel mínimo de error habilidato por defecto.
        /// </summary>
        public const LoggerLevel DefaultMinimumLevel = LoggerLevel.Error;

        /// <summary>
        /// Si se debe crear la DB.
        /// </summary>
        public const bool DefaultAutoCreateDB = false;

        private bool enabled = DefaultEnabled;

        private string schemaName = DefaultSchemaName;

        private string tableName = DefaultTableName;

        private string minimumLevel = DefaultMinimumLevel.ToString();

        private bool autoCreateDB = DefaultAutoCreateDB;

        /// <summary>
        /// Obtiene o establece si el logeo de errores de la base de datos esta habiliato.
        /// </summary>
        public bool? Enabled
        {
            get => this.enabled;
            set
            {
                if (value.HasValue)
                {
                    this.enabled = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la conexión de la base de datos donde se guardaran los errores.
        /// </summary>
        public string? ConnectionString { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del esquema de la tabla donde se guardaran los errores.
        /// </summary>
        public string? SchemaName
        {
            get => this.schemaName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.schemaName = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre de la tabla donde se guardaran los errores.
        /// </summary>
        public string? TableName
        {
            get => this.tableName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.tableName = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nivel mínimo de error.
        /// </summary>
        public string? MinimumLevel
        {
            get => this.minimumLevel;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.minimumLevel = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece si el logeo de errores de la base de datos esta habiliato.
        /// </summary>
        public bool? AutoCreateDB
        {
            get => this.autoCreateDB;
            set
            {
                if (value.HasValue)
                {
                    this.autoCreateDB = value.Value;
                }
            }
        }
    }
}
