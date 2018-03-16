﻿using System;
using Microsoft.AspNetCore.Authentication;
using Saml2.Authentication.Core.Authentication;
using Saml2.Authentication.Core.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Saml2Extensions
    {
        public static AuthenticationBuilder AddSaml(this AuthenticationBuilder builder)
          => builder.AddSaml(Saml2Defaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddSaml(this AuthenticationBuilder builder, Action<Saml2Options> configureOptions)
        => builder.AddSaml(Saml2Defaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddSaml(this AuthenticationBuilder builder, string authenticationScheme, Action<Saml2Options> configureOptions)
         => builder.AddSaml(authenticationScheme, Saml2Defaults.AuthenticationSchemeDisplayName, configureOptions);

        public static AuthenticationBuilder AddSaml(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<Saml2Options> configureOptions)
        => builder.AddScheme<Saml2Options, Saml2Handler>(authenticationScheme, displayName, configureOptions);
    }
}
