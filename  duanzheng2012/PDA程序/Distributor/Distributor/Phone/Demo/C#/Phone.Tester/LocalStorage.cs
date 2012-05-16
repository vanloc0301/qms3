#define DEBUG

using System;

using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SEUIC.Phone.Tester
{
    public class LocalStorage
    {
        public LocalStorage()
        {

        }

        private void InitTest()
        {
            bool b=Phone.LocalStorage.DB.SQLCE.CheckDBFileIsExist();
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.CheckDBFileIsExist:" + b.ToString());
        }

        private void SaveClassToDBTest()
        {
            bool b;
            Phone.CallLog.CallLog callLog = new Phone.CallLog.CallLog();
            callLog.CallIDType = CallLog.CallerIDType.Available;
            callLog.CallType = CallLog.CallType.Incoming;
            callLog.Connected = true;
            callLog.Ended = true;
            callLog.EndTime = DateTime.Now;
            callLog.Name = "Test Name";
            callLog.NameType = "Home";
            callLog.Note = "Note null";
            callLog.Number = "13912345678";
            callLog.OutGoing = false;
            callLog.Roaming = true;
            callLog.StartTime = DateTime.Now.AddMinutes(-5);
            b=Phone.LocalStorage.DB.SQLCE.InsertCallLog(callLog);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB CallLog:" + b.ToString());


            Phone.PhoneBook.PhoneBook phoneBook = new Phone.PhoneBook.PhoneBook();
            phoneBook.Name = "User1";
            phoneBook.PhoneNumber = "13912345678";
            phoneBook.Unit = "user Unit";
            b = Phone.LocalStorage.DB.SQLCE.InsertPhoneBook(phoneBook);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB PhoneBook:" + b.ToString());


            Phone.SMS.SMSMessage smsMessage = new Phone.SMS.SMSMessage();
            smsMessage.Address = "Address 1";
            smsMessage.MessageStatus = SMS.MessageStatus.UnRead;
            smsMessage.MessageText = @"message test asdfasdfasdfasfdasdfasdfasdfasdfasdfasdfasdfasdfasdf";
            smsMessage.ReceiveTime = DateTime.Now;
            b = Phone.LocalStorage.DB.SQLCE.InsertSMSMessage(smsMessage);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB SMSMessage:" + b.ToString());

        }

        private void DeleteTest()
        {
            bool b;
            b = Phone.LocalStorage.DB.SQLCE.DeleteByID("CallLog", 1);
            Debug.WriteLineIf(!b, "DeleteByID(CallLog, 1):" + b.ToString());

            b = Phone.LocalStorage.DB.SQLCE.DeleteByID("PhoneBook", 1);
            Debug.WriteLineIf(!b, "DeleteByID(PhoneBook, 1):" + b.ToString());

            b = Phone.LocalStorage.DB.SQLCE.DeleteByID("SMSMessage", 1);
            Debug.WriteLineIf(!b, "DeleteByID(SMSMessage, 1):" + b.ToString());

        }


        private void GetObjectByIDTest()
        {
            object obj;
            Phone.CallLog.CallLog callLog = new Phone.CallLog.CallLog();
            callLog.DBID = 3;
            callLog.CallIDType = CallLog.CallerIDType.Available;
            callLog.CallType = CallLog.CallType.Incoming;
            callLog.Connected = true;
            callLog.Ended = true;
            callLog.EndTime = DateTime.Now;
            callLog.Name = "Test Name";
            callLog.NameType = "Home";
            callLog.Note = "Note null";
            callLog.Number = "13912345678";
            callLog.OutGoing = false;
            callLog.Roaming = true;
            callLog.StartTime = DateTime.Now.AddMinutes(-5);
            obj = Phone.LocalStorage.DB.SQLCE.GetObjectByID("CallLog", 3);
            Debug.WriteLineIf(obj != (object)callLog, "Phone.LocalStorage.DB.SQLCE.GetObjectByID CallLog:");


            Phone.PhoneBook.PhoneBook phoneBook = new Phone.PhoneBook.PhoneBook();
            phoneBook.DBID = 3;
            phoneBook.Name = "User1";
            phoneBook.PhoneNumber = "13912345678";
            phoneBook.Unit = "user Unit";
            obj = Phone.LocalStorage.DB.SQLCE.GetObjectByID("PhoneBook", 3);
            Debug.WriteLineIf(obj != (object)phoneBook, "Phone.LocalStorage.DB.SQLCE.GetObjectByID PhoneBook:");


            Phone.SMS.SMSMessage smsMessage = new Phone.SMS.SMSMessage();
            smsMessage.DBID = 3;
            smsMessage.Address = "Address 1";
            smsMessage.MessageStatus = SMS.MessageStatus.UnRead;
            smsMessage.MessageText = @"message test asdfasdfasdfasfdasdfasdfasdfasdfasdfasdfasdfasdfasdf";
            smsMessage.ReceiveTime = DateTime.Now;
            obj = Phone.LocalStorage.DB.SQLCE.GetObjectByID("SMSMessage", 3);
            Debug.WriteLineIf(obj != (object)smsMessage, "Phone.LocalStorage.DB.SQLCE.GetObjectByID SMSMessage:");

        }

        private void GetTest()
        {
            object obj;
            List<CallLog.CallLog> callLogList = Phone.LocalStorage.DB.SQLCE.GetCallLogByCallType(CallLog.CallType.Incoming);
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetCallLogByCallType :"+callLogList.Count);

            callLogList = Phone.LocalStorage.DB.SQLCE.GetCallLogByCallType(CallLog.CallType.Missed);
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetCallLogByCallType :" + callLogList.Count);

            callLogList = Phone.LocalStorage.DB.SQLCE.GetCallLogByCallType(CallLog.CallType.Outgoing);
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetCallLogByCallType :" + callLogList.Count);

            callLogList = Phone.LocalStorage.DB.SQLCE.GetCallLogByName("Test Name");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetCallLogByName :" + callLogList.Count);

            callLogList = Phone.LocalStorage.DB.SQLCE.GetCallLogByName("Name");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetCallLogByName :" + callLogList.Count);

            callLogList = Phone.LocalStorage.DB.SQLCE.GetCallLogByNumber("13912345678");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetCallLogByNumber :" + callLogList.Count);

            callLogList = Phone.LocalStorage.DB.SQLCE.GetCallLogByNumber("13912345600");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetCallLogByNumber :" + callLogList.Count);



            List<PhoneBook.PhoneBook> phoneBookList = Phone.LocalStorage.DB.SQLCE.GetPhoneBookByName("User1");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetPhoneBookByName :" + phoneBookList.Count);

            phoneBookList = Phone.LocalStorage.DB.SQLCE.GetPhoneBookByName("User2");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetPhoneBookByName :" + phoneBookList.Count);

            phoneBookList = Phone.LocalStorage.DB.SQLCE.GetPhoneBookByName("User2");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetPhoneBookByName :" + phoneBookList.Count);

            phoneBookList = Phone.LocalStorage.DB.SQLCE.GetPhoneBookByPhoneNumber("13912345678");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetPhoneBookByPhoneNumber :" + phoneBookList.Count);

            phoneBookList = Phone.LocalStorage.DB.SQLCE.GetPhoneBookByPhoneNumber("13912345600");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetPhoneBookByPhoneNumber :" + phoneBookList.Count);

            phoneBookList = Phone.LocalStorage.DB.SQLCE.GetPhoneBookByUnit("user Unit");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetPhoneBookByUnit :" + phoneBookList.Count);

            phoneBookList = Phone.LocalStorage.DB.SQLCE.GetPhoneBookByUnit("user Unit2");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetPhoneBookByUnit :" + phoneBookList.Count);



            List<SMS.SMSMessage> smsMessageList = Phone.LocalStorage.DB.SQLCE.GetSMSMessageByAddress("Address 1");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetSMSMessageByAddress :" + smsMessageList.Count);

            smsMessageList = Phone.LocalStorage.DB.SQLCE.GetSMSMessageByAddress("Address 2");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetSMSMessageByAddress :" + smsMessageList.Count);

            smsMessageList = Phone.LocalStorage.DB.SQLCE.GetSMSMessageByMessageStatus(SMS.MessageStatus.Readed);
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetSMSMessageByMessageStatus :" + smsMessageList.Count);

            smsMessageList = Phone.LocalStorage.DB.SQLCE.GetSMSMessageByMessageStatus(SMS.MessageStatus.UnRead);
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetSMSMessageByMessageStatus :" + smsMessageList.Count);

            smsMessageList = Phone.LocalStorage.DB.SQLCE.GetSMSMessageByMessageText("message test asdfasdfasdfasfdasdfasdfasdfasdfasdfasdfasdfasdfasdf");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetSMSMessageByMessageText :" + smsMessageList.Count);

            smsMessageList = Phone.LocalStorage.DB.SQLCE.GetSMSMessageByMessageText("message 1");
            Debug.WriteLine("Phone.LocalStorage.DB.SQLCE.GetSMSMessageByMessageText :" + smsMessageList.Count);

        }


        private void CallLogCollectionTest()
        {
            bool b;

            Phone.CallLog.CallLogCollection clc = new Phone.CallLog.CallLogCollection();
            List<int> iclc = new List<int>();
            foreach (Phone.CallLog.CallLog cl in clc)
            {
                iclc.Add(cl.DBID);
            }
            foreach (int icl in iclc)
            {
                b=Phone.LocalStorage.DB.SQLCE.DeleteByID("CallLog", icl);
                Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.DeleteByID CallLog:" + icl.ToString());
            }

            Phone.CallLog.CallLog callLog = new Phone.CallLog.CallLog();
            callLog.CallIDType = CallLog.CallerIDType.Available;
            callLog.CallType = CallLog.CallType.Incoming;
            callLog.Connected = true;
            callLog.Ended = true;
            callLog.EndTime = DateTime.Now;
            callLog.Name = "Test Name";
            callLog.NameType = "Home";
            callLog.Note = "Note null";
            callLog.Number = "13912345678";
            callLog.OutGoing = false;
            callLog.Roaming = true;
            callLog.StartTime = DateTime.Now.AddMinutes(-5);
            b = Phone.LocalStorage.DB.SQLCE.InsertCallLog(callLog);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB CallLog:" + b.ToString());

            callLog.CallIDType = CallLog.CallerIDType.Available;
            callLog.CallType = CallLog.CallType.Missed;
            callLog.Connected = false;
            callLog.Ended = false;
            callLog.EndTime = DateTime.Now;
            callLog.Name = "Test Name";
            callLog.NameType = "Home";
            callLog.Note = "Note null";
            callLog.Number = "13912345678";
            callLog.OutGoing = false;
            callLog.Roaming = true;
            callLog.StartTime = DateTime.Now.AddMinutes(-5);
            b = Phone.LocalStorage.DB.SQLCE.InsertCallLog(callLog);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB CallLog:" + b.ToString());

            callLog.CallIDType = CallLog.CallerIDType.Available;
            callLog.CallType = CallLog.CallType.Outgoing;
            callLog.Connected = true;
            callLog.Ended = true;
            callLog.EndTime = DateTime.Now;
            callLog.Name = "Test Name";
            callLog.NameType = "Home";
            callLog.Note = "Note null";
            callLog.Number = "13912345678";
            callLog.OutGoing = true;
            callLog.Roaming = true;
            callLog.StartTime = DateTime.Now.AddMinutes(-5);
            b = Phone.LocalStorage.DB.SQLCE.InsertCallLog(callLog);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB CallLog:" + b.ToString());

            callLog.CallIDType = CallLog.CallerIDType.Available;
            callLog.CallType = CallLog.CallType.Refuse;
            callLog.Connected = false;
            callLog.Ended = true;
            callLog.EndTime = DateTime.Now;
            callLog.Name = "Test Name";
            callLog.NameType = "Home";
            callLog.Note = "Note null";
            callLog.Number = "13912345678";
            callLog.OutGoing = false;
            callLog.Roaming = true;
            callLog.StartTime = DateTime.Now.AddMinutes(-5);
            b = Phone.LocalStorage.DB.SQLCE.InsertCallLog(callLog);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB CallLog:" + b.ToString());

            Phone.CallLog.CallLogCollection callcl = new Phone.CallLog.CallLogCollection();
            if (!(callcl.Count==4))
            {
                Debug.WriteLineIf(!b, "Phone.CallLog.CallLogCollection Count Error:" + b.ToString());
            }
            Phone.CallLog.CallLogCollection callcl1 = new Phone.CallLog.CallLogCollection(CallLog.CallType.Incoming);
            if (!(callcl1.Count == 1))
            {
                Debug.WriteLineIf(!b, "Phone.CallLog.CallLogCollection Incoming Count Error:" + b.ToString());
            }
            Phone.CallLog.CallLogCollection callcl2 = new Phone.CallLog.CallLogCollection(CallLog.CallType.Missed);
            if (!(callcl2.Count == 1))
            {
                Debug.WriteLineIf(!b, "Phone.CallLog.CallLogCollection Missed Count Error:" + b.ToString());
            }
            Phone.CallLog.CallLogCollection callcl3 = new Phone.CallLog.CallLogCollection(CallLog.CallType.Outgoing);
            if (!(callcl3.Count == 1))
            {
                Debug.WriteLineIf(!b, "Phone.CallLog.CallLogCollection Outgoing Count Error:" + b.ToString());
            }
            Phone.CallLog.CallLogCollection callcl4 = new Phone.CallLog.CallLogCollection(CallLog.CallType.Refuse);
            if (!(callcl4.Count == 1))
            {
                Debug.WriteLineIf(!b, "Phone.CallLog.CallLogCollection Refuse Count Error:" + b.ToString());
            }

            foreach (Phone.CallLog.CallLog icl in callcl)
            {
                Debug.WriteLine(icl.CallType.ToString() + icl.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }

        }


        private void PhoneBookCollectionTest()
        {
            bool b;

            Phone.PhoneBook.PhoneBookCollection clc = new Phone.PhoneBook.PhoneBookCollection();
            List<int> iclc = new List<int>();
            foreach (Phone.PhoneBook.PhoneBook cl in clc)
            {
                iclc.Add(cl.DBID);
            }
            foreach (int icl in iclc)
            {
                b = Phone.LocalStorage.DB.SQLCE.DeleteByID("PhoneBook", icl);
                Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.DeleteByID PhoneBook:" + icl.ToString());
            }

            Phone.PhoneBook.PhoneBook phoneBook = new Phone.PhoneBook.PhoneBook();
            phoneBook.Name = "User1";
            phoneBook.PhoneNumber = "13912345671";
            phoneBook.Unit = "user Unit";
            b = Phone.LocalStorage.DB.SQLCE.InsertPhoneBook(phoneBook);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB PhoneBook:" + b.ToString());

            phoneBook = new Phone.PhoneBook.PhoneBook();
            phoneBook.Name = "User1";
            phoneBook.PhoneNumber = "13912345672";
            phoneBook.Unit = "user Unit";
            b = Phone.LocalStorage.DB.SQLCE.InsertPhoneBook(phoneBook);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB PhoneBook:" + b.ToString());

            phoneBook = new Phone.PhoneBook.PhoneBook();
            phoneBook.Name = "User1";
            phoneBook.PhoneNumber = "13912345673";
            phoneBook.Unit = "user Unit";
            b = Phone.LocalStorage.DB.SQLCE.InsertPhoneBook(phoneBook);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB PhoneBook:" + b.ToString());

            phoneBook = new Phone.PhoneBook.PhoneBook();
            phoneBook.Name = "User1";
            phoneBook.PhoneNumber = "13912345674";
            phoneBook.Unit = "user Unit";
            b = Phone.LocalStorage.DB.SQLCE.InsertPhoneBook(phoneBook);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB PhoneBook:" + b.ToString());
            
            phoneBook.PhoneNumber = "13912345675";
            phoneBook.Unit = "user Unit";
            b = Phone.LocalStorage.DB.SQLCE.InsertPhoneBook(phoneBook);
            Debug.WriteLineIf(!b, "Phone.LocalStorage.DB.SQLCE.SaveClassToDB PhoneBook:" + b.ToString());


            PhoneBook.PhoneBookCollection pbc = new PhoneBook.PhoneBookCollection();
            if (!(pbc.Count==5))
            {
                Debug.WriteLineIf(!b, "Phone.PhoneBook.PhoneBookCollection Count Error:" + b.ToString());
            }

            phoneBook.PhoneNumber = "13912345676";
            phoneBook.Unit = "user Unit";
            pbc.Insert(0, phoneBook);
            if (!(pbc.Count == 6))
            {
                Debug.WriteLineIf(!b, "Phone.PhoneBook.PhoneBookCollection Count Error:" + b.ToString());
            }
            if (!pbc.Contains(phoneBook))
            {
                Debug.WriteLineIf(!b, "Phone.PhoneBook.PhoneBookCollection Contains Error:" + b.ToString());
            }
            pbc.Remove(phoneBook);

            int index=pbc.Add(phoneBook);
            if (pbc[index]!=phoneBook)
            {
                Debug.WriteLineIf(!b, "Phone.PhoneBook.PhoneBookCollection Add Error:" + b.ToString());
            }

            pbc.RemoveAt(index);

        }


        private void SMSMessageCollectionTest()
        {

        }

        public void Run()
        {
            InitTest();
            DeleteTest();
            SaveClassToDBTest();
            GetObjectByIDTest();
            GetTest();

            CallLogCollectionTest();
            PhoneBookCollectionTest();
        }
    }
}
