// WDTDlg.h : header file
//

#if !defined(AFX_WDTDLG_H__CCA3A05F_AEC0_49A2_9C96_6C4B55AE93A4__INCLUDED_)
#define AFX_WDTDLG_H__CCA3A05F_AEC0_49A2_9C96_6C4B55AE93A4__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CWDTDlg dialog

class CWDTDlg : public CDialog
{
// Construction
public:
	CWDTDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CWDTDlg)
	enum { IDD = IDD_WDT_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWDTDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CWDTDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	//afx_msg void OnButton1();
	afx_msg void OnButton2();
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnButton3();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_WDTDLG_H__CCA3A05F_AEC0_49A2_9C96_6C4B55AE93A4__INCLUDED_)
