﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Razor.Language;

namespace Microsoft.AspNetCore.Razor.Language.Components
{
    internal static class ImplementsDirective
    {
        public static readonly DirectiveDescriptor Directive = DirectiveDescriptor.CreateDirective(
            "implements",
            DirectiveKind.SingleLine,
            builder =>
            {
                builder.AddTypeToken(ComponentResources.ImplementsDirective_TypeToken_Name, ComponentResources.ImplementsDirective_TypeToken_Description);
                builder.Usage = DirectiveUsage.FileScopedMultipleOccurring;
                builder.Description = ComponentResources.ImplementsDirective_Description;
            });

        public static void Register(RazorProjectEngineBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddDirective(Directive);
            builder.Features.Add(new ImplementsDirectivePass());
        }
    }
}