﻿#pragma checksum "..\..\ClkWidnow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5EB6DA0F45A0B833C655BDCFF7343AE3"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3625
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using StationManager;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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
    /// ClkWidnow
    /// </summary>
    public partial class ClkWidnow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\ClkWidnow.xaml"
        internal StationManager.ClkWidnow Window;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ClkWidnow.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ClkWidnow.xaml"
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ClkWidnow.xaml"
        internal StationManager.WpfTimeLine timeLine;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ClkWidnow.xaml"
        internal System.Windows.Controls.Label lblTruckNo;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ClkWidnow.xaml"
        internal System.Windows.Controls.Label lblPushTime;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ClkWidnow.xaml"
        internal System.Windows.Controls.Label lblStationName;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ClkWidnow.xaml"
        internal System.Windows.Controls.Label lblType;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ClkWidnow.xaml"
        internal System.Windows.Controls.Button btnPrint;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ClkWidnow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/StationManager;component/clkwidnow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ClkWidnow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window = ((StationManager.ClkWidnow)(target));
            
            #line 9 "..\..\ClkWidnow.xaml"
            this.Window.Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            
            #line 9 "..\..\ClkWidnow.xaml"
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
            this.timeLine = ((StationManager.WpfTimeLine)(target));
            return;
            case 5:
            this.lblTruckNo = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblPushTime = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblStationName = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblType = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.btnPrint = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\ClkWidnow.xaml"
            this.btnPrint.Click += new System.Windows.RoutedEventHandler(this.btnPrint_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\ClkWidnow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
