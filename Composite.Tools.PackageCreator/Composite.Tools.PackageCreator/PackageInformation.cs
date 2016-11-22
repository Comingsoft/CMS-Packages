﻿using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Composite.Tools.PackageCreator
{
    public sealed class PackageInformation
    {
        public Guid Id { get; set; }
        [NotNullValidator()]
        public string Name { get; set; }
        [NotNullValidator()]
        public string GroupName { get; set; }
        [NotNullValidator()]
        public string Author { get; set; }
        [NotNullValidator()]
        public string ReadMoreUrl { get; set; }
        [NotNullValidator()]
        public string Website { get; set; }
        [NotNullValidator()]
        public string Description { get; set; }
        [NotNullValidator()]
        public string TechnicalDetails { get; set; }
        [NotNullValidator()]
        public string Version { get; set; }
        public bool CanBeUninstalled { get; set; }
        public string SystemLockingType { get; set; }
        public bool FlushOnCompletion { get; set; }
        public bool OverwriteDataOnInstall { get; set; }
        public bool ReloadConsoleOnCompletion { get; set; }
        public Version MaxCompositeVersionSupported { get; set; }
        public Version MinCompositeVersionSupported { get; set; }
    }
}
