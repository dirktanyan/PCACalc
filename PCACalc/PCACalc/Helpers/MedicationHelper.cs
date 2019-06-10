using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using PCACalc.Models;
using SQLite;


namespace PCACalc.Helpers
{
    public class MedicationHelper
    {
        static SQLiteConnection sqliteconnection;

        public MedicationHelper()
        {
            sqliteconnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            sqliteconnection.CreateTable<Med>();

        }

        // Get list of Medications
        public List<Med> GetAllMeds()
        {
            return (from data in sqliteconnection.Table<Med>() select data).ToList();
        }
        
        // Get specific Medication
        public Med GetMed(int id)
        {
            return sqliteconnection.Table<Med>().FirstOrDefault(t => t.ID == id);
        }

        // Insert new Medication
        public void InsertMed(Med med)
        {
            sqliteconnection.Insert(med);
        }

        // Update Medication
        public void UpdateMed(Med med)
        {
            sqliteconnection.Update(med);
        }

        // Delete Medication
        public void DeleteMed(int id)
        {
            sqliteconnection.Delete<Med>(id);
        }
    }
}
