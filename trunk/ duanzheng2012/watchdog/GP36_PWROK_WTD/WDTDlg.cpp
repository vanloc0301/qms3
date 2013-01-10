// WDTDlg.cpp : implementation file
//

#include "stdafx.h"
#include "WDT.h"
#include "WDTDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//////////////////////////////////////////////////////////////////////////////
typedef unsigned long  U32;
typedef unsigned short U16;
typedef unsigned char  U08;


long  _stdcall IMCLoadDriver(long);
long  _stdcall IMCRemoveDrvier(long);  
long  _stdcall IoWrite8(WORD,BYTE);
BYTE  _stdcall IoRead8(WORD);
bool  _stdcall FlatMemRead(DWORD,PDWORD);
bool  _stdcall FlatMemWrite(DWORD,DWORD);
DWORD _stdcall PciCfgRead32(WORD D_BUS,WORD D_DEV,WORD D_FUN,WORD D_REG);
DWORD _stdcall PciCfgWrite32(WORD D_BUS,WORD D_DEV,WORD D_FUN,WORD D_REG,DWORD D_VAL);


#define   Superio_Config_Port    0x2E
#define   Superio_REG_LDN        0x07
#define   Superio_DATA_Port      (Superio_Config_Port+1)


//function for SIO 
void Superio_Enter_Config()
{
	IoWrite8(Superio_Config_Port,0x87);
	IoWrite8(Superio_Config_Port,0x01);
	IoWrite8(Superio_Config_Port,0x55);
	IoWrite8(Superio_Config_Port,0x55);
	Sleep(100);
	IoWrite8(Superio_Config_Port,0x22);
	IoWrite8(Superio_DATA_Port,0x80);
}
void Superio_Exit_Config()
{
	IoWrite8(Superio_Config_Port,0x02);
	IoWrite8(Superio_DATA_Port,0x02);
}

void Superio_Set_Reg(BYTE bLDN, BYTE bReg, BYTE bValue)
{
	Superio_Enter_Config();
	IoWrite8(Superio_Config_Port,Superio_REG_LDN);  //Set LDN
	IoWrite8(Superio_DATA_Port,bLDN);
	IoWrite8(Superio_Config_Port,bReg);
	IoWrite8(Superio_DATA_Port,bValue);
	Superio_Exit_Config();
}

BYTE Superio_Get_Reg(BYTE bLDN, BYTE bReg)
{
	BYTE bValue;
	Superio_Enter_Config();
	IoWrite8(Superio_Config_Port,Superio_REG_LDN);  //Set LDN
	IoWrite8(Superio_DATA_Port,bLDN);
	IoWrite8(Superio_Config_Port,bReg);
	bValue=IoRead8(Superio_DATA_Port);
	Superio_Exit_Config();
	return bValue;
}

//void Superio_Set_Logic_Dev(BYTE bLDN)
//{
//	IoWrite8(Superio_Config_Port,Superio_REG_LDN);  //Set LDN
//	IoWrite8(Superio_DATA_Port,bLDN);
//}

void SetupWDT(U16 TimeValue)
{
	Superio_Enter_Config();
	Superio_Set_Reg(0x7,0xf1,0x44); //
	Superio_Set_Reg(0x7,0xf4,0x1e); //8782 power_ok被com口占用，只能通过GPIO36转复位信号
	Superio_Set_Reg(0x7,0x71,0x00); //WDT Timer 1 Enable
	Superio_Set_Reg(0x7,0x72,0x90); //Time-out value select: second  output:PWROK(Pulse)
	Superio_Set_Reg(0x7,0x73,(TimeValue&0xFF));
	Superio_Set_Reg(0x7,0x74,(TimeValue>>8));    //MSB
	Superio_Exit_Config();
}

void ResetWDT(U16 TimeValue)
{
	Superio_Enter_Config();
	Superio_Set_Reg(0x7,0x73,(TimeValue&0xFF));
	Superio_Set_Reg(0x7,0x74,(TimeValue>>8));    //MSB
	Superio_Exit_Config();
}

//void CWDTDlg::OnButton1() 
//{
//	// 启用看门狗
//	WORD TimeValue;
//	char temp[255];
//	GetDlgItemText(IDC_EDIT1,temp,255);
//	TimeValue=atoi(temp);
//    SetupWDT(TimeValue);
//	SetTimer(1,3000,NULL);
//	GetDlgItem(IDC_BUTTON1)->EnableWindow(false);
//}

void CWDTDlg::OnButton2() 
{
	// 禁用看门狗
	GetDlgItem(IDC_BUTTON1)->EnableWindow(true);
	ResetWDT(0);
	KillTimer(1);	
}

/////////////////////////////////////////////////////////////////////////////
// CWDTDlg dialog

CWDTDlg::CWDTDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CWDTDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CWDTDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CWDTDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CWDTDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CWDTDlg, CDialog)
	//{{AFX_MSG_MAP(CWDTDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
//	ON_BN_CLICKED(IDC_BUTTON1, OnButton1)
	ON_BN_CLICKED(IDC_BUTTON2, OnButton2)
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_BUTTON3, OnButton3)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CWDTDlg message handlers

BOOL CWDTDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	if(!IMCLoadDriver(1))
	{
		AfxMessageBox("没有检测到看门狗驱动!");
	}

	WORD TimeValue;// changed by will 2013/1/10
	TimeValue=60;// 1 分钟更新一次？ 也许需要改
    SetupWDT(TimeValue);// changed by will 2013/1/10
	SetTimer(1,3000,NULL);// changed by will 2013/1/10
	//GetDlgItem(IDC_BUTTON1)->EnableWindow(false);// changed by will 2013/1/10
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CWDTDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CWDTDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CWDTDlg::OnTimer(UINT nIDEvent) 
{
	// TODO: Add your message handler code here and/or call default
	WORD TimeValue;
//	char temp[255];// changed by will 2013/1/10
	//GetDlgItemText(IDC_EDIT1,temp,255);// changed by will 2013/1/10

	//TimeValue=atoi(temp);// changed by will 2013/1/10
	TimeValue=60;// 1 分钟更新一次？ 也许需要改
	ResetWDT(TimeValue);
	//======================================
	CDialog::OnTimer(nIDEvent);
}

void CWDTDlg::OnButton3() 
{
	// TODO: Add your control notification handler code here
	
}
