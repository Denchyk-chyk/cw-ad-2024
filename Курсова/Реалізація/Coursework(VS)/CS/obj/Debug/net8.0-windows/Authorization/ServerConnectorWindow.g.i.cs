﻿#pragma checksum "..\..\..\..\Authorization\ServerConnectorWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48F548A2FB137F3664E0CD3909F729477A16DAFF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CS.General;
using CS.General.Form;
using CS.General.Form.Field;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CS.Authorization {
    
    
    /// <summary>
    /// ServerConnectorWindow
    /// </summary>
    public partial class ServerConnectorWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Authorization\ServerConnectorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding FillCommandBinding;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Authorization\ServerConnectorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CS.General.Form.Field.TextField Host;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Authorization\ServerConnectorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CS.General.Form.Field.TextField Name;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Authorization\ServerConnectorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CS.General.Form.Field.TextField Password;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Authorization\ServerConnectorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CS.General.Form.Field.TextField Database;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Authorization\ServerConnectorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CS.General.Form.FormButtons Buttons;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CS;component/authorization/serverconnectorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Authorization\ServerConnectorWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FillCommandBinding = ((System.Windows.Input.CommandBinding)(target));
            
            #line 12 "..\..\..\..\Authorization\ServerConnectorWindow.xaml"
            this.FillCommandBinding.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.FillCommandBinding_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Host = ((CS.General.Form.Field.TextField)(target));
            return;
            case 3:
            this.Name = ((CS.General.Form.Field.TextField)(target));
            return;
            case 4:
            this.Password = ((CS.General.Form.Field.TextField)(target));
            return;
            case 5:
            this.Database = ((CS.General.Form.Field.TextField)(target));
            return;
            case 6:
            this.Buttons = ((CS.General.Form.FormButtons)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

