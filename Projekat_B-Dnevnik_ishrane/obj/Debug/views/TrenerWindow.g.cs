﻿#pragma checksum "..\..\..\views\TrenerWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "31FFC3455F1549126AF099F39A29A4E3297147C3CFC7336CE3DD76D73057533C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekat_B_Dnevnik_ishrane.views;
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


namespace Projekat_B_Dnevnik_ishrane.views {
    
    
    /// <summary>
    /// TrenerWindow
    /// </summary>
    public partial class TrenerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 53 "..\..\..\views\TrenerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReviewDietPlanButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\views\TrenerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReviewExercisePlanButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\views\TrenerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CandidatesButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\views\TrenerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddMeasure;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\views\TrenerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekat_B-Dnevnik_ishrane;component/views/trenerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\views\TrenerWindow.xaml"
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
            this.ReviewDietPlanButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\views\TrenerWindow.xaml"
            this.ReviewDietPlanButton.Click += new System.Windows.RoutedEventHandler(this.ReviewDietPlanButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ReviewExercisePlanButton = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\views\TrenerWindow.xaml"
            this.ReviewExercisePlanButton.Click += new System.Windows.RoutedEventHandler(this.Exercise_Plan_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CandidatesButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\views\TrenerWindow.xaml"
            this.CandidatesButton.Click += new System.Windows.RoutedEventHandler(this.Candidate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddMeasure = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\views\TrenerWindow.xaml"
            this.AddMeasure.Click += new System.Windows.RoutedEventHandler(this.Measurement_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\views\TrenerWindow.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

