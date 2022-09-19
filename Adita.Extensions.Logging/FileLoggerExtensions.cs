//MIT License

//Copyright (c) 2022 Adita

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using Adita.Extensions.Logging.Models.Options;
using Adita.Extensions.Logging.Services.LoggerProviders;
using Adita.Extensions.Logging.Services.Loggers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Adita.Extensions.Logging
{
    /// <summary>
    /// Represents a <see cref="FileLogger"/> service extensions.
    /// </summary>
    public static class FileLoggerExtensions
    {
        /// <summary>
        /// Adds <see cref="FileLogger"/> to service collection.
        /// </summary>
        /// <param name="builder">An <see cref="ILoggingBuilder"/></param>.
        /// <returns>An <see cref="ILoggingBuilder"/> that has <see cref="FileLogger"/>.</returns>
        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder)
        {
            builder.AddConfiguration();
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, FileLoggerProvider>());

            LoggerProviderOptions.RegisterProviderOptions<FileLoggerOptions, FileLoggerProvider>(builder.Services);
            return builder;
        }
        /// <summary>
        /// Adds <see cref="FileLogger"/> to service collection.
        /// </summary>
        /// <param name="builder">An <see cref="ILoggingBuilder"/></param>
        /// <param name="configure">An <see cref="Action{T}"/> of <see cref="FileLoggerOptions"/> to configure the options.</param>.
        /// <returns>An <see cref="ILoggingBuilder"/> that has <see cref="FileLogger"/>.</returns>
        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, Action<FileLoggerOptions> configure)
        {
            builder.AddFileLogger();
            builder.Services.Configure(configure);
            return builder;
        }
    }
}
