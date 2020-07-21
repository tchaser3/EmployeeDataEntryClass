/* Title:           Employee Date Entry Class
 * Date:            1-2-19
 * Author:          Terry Holmes
 * 
 * Description:     This is the class that runs Employee Date Entry Class */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace EmployeeDateEntryDLL
{
    public class EmployeeDateEntryClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        EmployeeDateEntryDataSet aEmployeeDateEntryDataSet;
        EmployeeDateEntryDataSetTableAdapters.employeedateentryTableAdapter aEmployeeDateEntryTableAdapter;

        InsertIntoEmployeeDateEntryInfoTableAdapters.QueriesTableAdapter aInsertIntoEmployeeDateEntryTableAdapter;

        FindEmployeeDataEntryByDateRangeDataSet aFindEmployeeDataEntryByDateRangeDataSet;
        FindEmployeeDataEntryByDateRangeDataSetTableAdapters.FindEmployeeDateEntryByDateRangeTableAdapter aFindEmployeeDataEntryByDateRangeTableAdapter;

        FindEmployeeDataEntryByEmployeeIDDataSet aFindEmployeeDataEntryByEmployeeIDDataSet;
        FindEmployeeDataEntryByEmployeeIDDataSetTableAdapters.FindEmployeeDateEntryByEmployeeIDTableAdapter aFindEmployeeDataEntryByEmployeeIDTableAdapter;

        FindERPLoginsDataSet aFindERPLoginsDataSet;
        FindERPLoginsDataSetTableAdapters.FindERPLoginsTableAdapter aFindERPLoginsTableAdapter;

        public FindERPLoginsDataSet FindERPLogins(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindERPLoginsDataSet = new FindERPLoginsDataSet();
                aFindERPLoginsTableAdapter = new FindERPLoginsDataSetTableAdapters.FindERPLoginsTableAdapter();
                aFindERPLoginsTableAdapter.Fill(aFindERPLoginsDataSet.FindERPLogins, datStartDate, datEndDate);
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Data Entry // Find ERP Logins " + ex.Message);
            }

            return aFindERPLoginsDataSet;
        }
        public FindEmployeeDataEntryByEmployeeIDDataSet FindEmployeeDateEntryByEmployeeID(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindEmployeeDataEntryByEmployeeIDDataSet = new FindEmployeeDataEntryByEmployeeIDDataSet();
                aFindEmployeeDataEntryByEmployeeIDTableAdapter = new FindEmployeeDataEntryByEmployeeIDDataSetTableAdapters.FindEmployeeDateEntryByEmployeeIDTableAdapter();
                aFindEmployeeDataEntryByEmployeeIDTableAdapter.Fill(aFindEmployeeDataEntryByEmployeeIDDataSet.FindEmployeeDateEntryByEmployeeID, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Date Entry Class // Find Employee Date Entry By Employee ID " + Ex.Message);
            }

            return aFindEmployeeDataEntryByEmployeeIDDataSet;
        }
        public FindEmployeeDataEntryByDateRangeDataSet FindEmployeeDataEntryByDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindEmployeeDataEntryByDateRangeDataSet = new FindEmployeeDataEntryByDateRangeDataSet();
                aFindEmployeeDataEntryByDateRangeTableAdapter = new FindEmployeeDataEntryByDateRangeDataSetTableAdapters.FindEmployeeDateEntryByDateRangeTableAdapter();
                aFindEmployeeDataEntryByDateRangeTableAdapter.Fill(aFindEmployeeDataEntryByDateRangeDataSet.FindEmployeeDateEntryByDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Date Entry Class // Find Employee Date Entry By Date Range " + Ex.Message);
            }

            return aFindEmployeeDataEntryByDateRangeDataSet;
        }
        public bool InsertIntoEmployeeDateEntry(int intEmployeeID, string strWindowEntered)
        {
            bool blnFatalError = false;

            try
            {
                aInsertIntoEmployeeDateEntryTableAdapter = new InsertIntoEmployeeDateEntryInfoTableAdapters.QueriesTableAdapter();
                aInsertIntoEmployeeDateEntryTableAdapter.InsertIntoEmployeeDateEntry(DateTime.Now, intEmployeeID, strWindowEntered);
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Date Entry Class // Insert Into Employee Date Entry " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public EmployeeDateEntryDataSet GetEmployeeDateEntryInfo()
        {
            try
            {
                aEmployeeDateEntryDataSet = new EmployeeDateEntryDataSet();
                aEmployeeDateEntryTableAdapter = new EmployeeDateEntryDataSetTableAdapters.employeedateentryTableAdapter();
                aEmployeeDateEntryTableAdapter.Fill(aEmployeeDateEntryDataSet.employeedateentry);
            }
            catch  (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Date Entry Class // Get Employee Data Entry Info " + Ex.Message);
            }

            return aEmployeeDateEntryDataSet;
        }
        private void UpdateEmployeeDateEntryDB(EmployeeDateEntryDataSet aEmployeeDateEntryDataSet)
        {
            try
            {
                aEmployeeDateEntryTableAdapter = new EmployeeDateEntryDataSetTableAdapters.employeedateentryTableAdapter();
                aEmployeeDateEntryTableAdapter.Update(aEmployeeDateEntryDataSet.employeedateentry);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Date Entry Class // Update Employee Data Entry DB " + Ex.Message);
            }
        }
    }
}
