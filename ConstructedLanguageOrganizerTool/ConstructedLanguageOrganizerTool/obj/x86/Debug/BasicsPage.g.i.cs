﻿#pragma checksum "..\..\..\BasicsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2FF28E8FF5A1B18260E0DE76EC3693EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace ConstructedLanguageOrganizerTool {
    
    
    /// <summary>
    /// BasicsPage
    /// </summary>
    public partial class BasicsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\BasicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock conlangName;
        
        #line default
        #line hidden
        
        /// <summary>
        /// conlangNameValue Name Field
        /// </summary>
        
        #line 12 "..\..\..\BasicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBox conlangNameValue;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\BasicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock IPAName;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\BasicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IPAValues;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\BasicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock conlangLetters;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\BasicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox conlangLettersValue;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\BasicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock basicWordForm;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\BasicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox basicWordFormValue;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ConstructedLanguageOrganizerTool;component/basicspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BasicsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\..\BasicsPage.xaml"
            ((ConstructedLanguageOrganizerTool.BasicsPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.conlangName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.conlangNameValue = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.IPAName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.IPAValues = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.conlangLetters = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.conlangLettersValue = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.basicWordForm = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.basicWordFormValue = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
