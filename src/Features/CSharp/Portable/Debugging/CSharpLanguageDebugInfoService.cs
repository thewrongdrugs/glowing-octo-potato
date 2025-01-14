﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Debugging;
using Microsoft.CodeAnalysis.Host.Mef;

namespace Microsoft.CodeAnalysis.CSharp.Debugging;

[ExportLanguageService(typeof(ILanguageDebugInfoService), LanguageNames.CSharp), Shared]
[method: ImportingConstructor]
[method: SuppressMessage("RoslynDiagnosticsReliability", "RS0033:Importing constructor should be [Obsolete]", Justification = "Used in test code: https://github.com/dotnet/roslyn/issues/42814")]
internal sealed partial class CSharpLanguageDebugInfoService() : ILanguageDebugInfoService
{
    public Task<DebugLocationInfo> GetLocationInfoAsync(Document document, int position, CancellationToken cancellationToken)
        => LocationInfoGetter.GetInfoAsync(document, position, cancellationToken);

    public Task<DebugDataTipInfo> GetDataTipInfoAsync(Document document, int position, bool includeKind, CancellationToken cancellationToken)
        => DataTipInfoGetter.GetInfoAsync(document, position, includeKind, cancellationToken);
}
