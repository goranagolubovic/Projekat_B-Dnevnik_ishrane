﻿#pragma checksum "..\..\..\views\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "339481E7DD99F4E7D0963ED9C7EAA886142AFD4A716787C9514F5DD70F5DFE86"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekat_B_Dnevnik_ishrane;
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


namespace Projekat_B_Dnevnik_ishrane {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loginButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserNameField;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordField;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock titleTextBlock;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock usernameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock passwordTextBlock;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock themeTextBlock;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock languageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock errorTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekat_B-Dnevnik_ishrane;component/views/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\views\MainWindow.xaml"
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
            this.loginButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\views\MainWindow.xaml"
            this.loginButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UserNameField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PasswordField = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.titleTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.usernameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.passwordTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 20 "..\..\..\views\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.CandyMode_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 21 "..\..\..\views\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.LightMode_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 22 "..\..\..\views\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.DarkMode_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 23 "..\..\..\views\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.chooseEnglish);
            
            #line default
            #line hidden
            return;
            case 11:
            this.themeTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.languageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.errorTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            
            #line 28 "..\..\..\views\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.chooseSerbian);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

