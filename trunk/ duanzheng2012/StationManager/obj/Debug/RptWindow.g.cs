﻿#pragma checksum "..\..\RptWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6995FD761E298133470831D41D329A5B"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
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


namespace StationManager {
    
    
    /// <summary>
    /// RptWindow
    /// </summary>
    public partial class RptWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\RptWindow.xaml"
        internal StationManager.RptWindow Window;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\RptWindow.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RptWindow.xaml"
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\RptWindow.xaml"
        internal System.Windows.Controls.ComboBox cbRptType;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\RptWindow.xaml"
        internal System.Windows.Forms.DateTimePicker dpDate;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\RptWindow.xaml"
        internal System.Windows.Controls.ListView lvYearRpt;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\RptWindow.xaml"
        internal System.Windows.Controls.ListView lvMonRpt;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\RptWindow.xaml"
        internal System.Windows.Controls.ListView lvDayRpy;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\RptWindow.xaml"
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StationManager;component/rptwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RptWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window = ((StationManager.RptWindow)(target));
            
            #line 11 "..\..\RptWindow.xaml"
            this.Window.Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            
            #line 11 "..\..\RptWindow.xaml"
            this.Window.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lblTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.cbRptType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\RptWindow.xaml"
            this.cbRptType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dpDate = ((System.Windows.Forms.DateTimePicker)(target));
            return;
            case 6:
            
            #line 32 "..\..\RptWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lvYearRpt = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.lvMonRpt = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.lvDayRpy = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\RptWindow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
