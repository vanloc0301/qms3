﻿#pragma checksum "..\..\MsgWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A833FDEF86ACFC042E71E688E05B2263"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
    /// MsgWindow
    /// </summary>
    public partial class MsgWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\MsgWindow.xaml"
        internal StationManager.MsgWindow Window;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MsgWindow.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MsgWindow.xaml"
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MsgWindow.xaml"
        internal System.Windows.Controls.ListView lvData;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MsgWindow.xaml"
        internal System.Windows.Controls.Button btnDown;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\MsgWindow.xaml"
        internal System.Windows.Controls.Button btnUp;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MsgWindow.xaml"
        internal System.Windows.Controls.Button btnIsRead;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\MsgWindow.xaml"
        internal System.Windows.Controls.Label lblContent;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\MsgWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/StationManager;component/msgwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MsgWindow.xaml"
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
            this.Window = ((StationManager.MsgWindow)(target));
            
            #line 8 "..\..\MsgWindow.xaml"
            this.Window.Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            
            #line 8 "..\..\MsgWindow.xaml"
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
            this.lvData = ((System.Windows.Controls.ListView)(target));
            
            #line 18 "..\..\MsgWindow.xaml"
            this.lvData.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvData_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDown = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\MsgWindow.xaml"
            this.btnDown.Click += new System.Windows.RoutedEventHandler(this.btnDown_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnUp = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\MsgWindow.xaml"
            this.btnUp.Click += new System.Windows.RoutedEventHandler(this.btnUp_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnIsRead = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\MsgWindow.xaml"
            this.btnIsRead.Click += new System.Windows.RoutedEventHandler(this.btnIsRead_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblContent = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\MsgWindow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

