using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;


namespace BootstrapBlazorApp.Shared.Components
{
    public partial class Atd
    {
        [Inject]
        [NotNull]
        private IStringLocalizer<Atd> Localizer { get; set; }

        public Atd()
        {

        }
    }
}
