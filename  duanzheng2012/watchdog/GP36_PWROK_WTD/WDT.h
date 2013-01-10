// WDT.h : main header file for the WDT application
//

#if !defined(AFX_WDT_H__C97F1F26_C20A_4C52_8832_C5B8A144A0E7__INCLUDED_)
#define AFX_WDT_H__C97F1F26_C20A_4C52_8832_C5B8A144A0E7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CWDTApp:
// See WDT.cpp for the implementation of this class
//

class CWDTApp : public CWinApp
{
public:
	CWDTApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWDTApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CWDTApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_WDT_H__C97F1F26_C20A_4C52_8832_C5B8A144A0E7__INCLUDED_)
