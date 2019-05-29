using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace IntegrationPart.Tests
{
    [TestClass]
    public class IntegrationTestPart
    {
        // does not use original database
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = TestPartDBCopy");

        private void SetUpDB()
        {
            SqlCommand cmd = null;
            // "drop table if exists Part;" works from SQL Server 2016
            string setupsql = @"
            begin try drop table Part end try begin catch end catch
            create table Part
            (
                Partno     int             primary key,
                Partname   nvarchar(50)    not null,
                Price      decimal(10,2)   not null,
                Instock    int             not null
            );
            insert into Part
            values	(1, 'PartA', 25.25, 200),
		            (2, 'PartB', 3.5, 8),
                    (3, 'PartC', 6, 17)
            ";

            try
            {
                conn.Open();
                cmd = new SqlCommand(setupsql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
            finally
            {
                conn.Close();
            }
        }

        private void TearDown()
        {
            SqlCommand cmd = null;
            // "drop table if exists Part;" works from SQL Server 2016
            string teardownsql = @"
            begin try drop table Part end try begin catch end catch
            ";
            conn.Open();
            cmd = new SqlCommand(teardownsql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // Get part that exists
        [TestMethod]
        public void TestGetPartOK()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            Part p = pm.GetPart(2, conn);
            TearDown();
            Assert.AreEqual(p.partno, 2);
        }

        // Get part that does not exist
        [TestMethod]
        public void TestGetPartFail()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            Part p = pm.GetPart(4, conn);
            TearDown();
            Assert.AreEqual(p, null);
        }

        // Get all parts from database with parts
        [TestMethod]
        public void TestGetAllOK()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            ArrayList a = pm.GetAllParts(conn);
            TearDown();
            Assert.AreEqual(a.Count, 3);
        }

        // Get all parts from empty database
        [TestMethod]
        public void TestGetAllEmpty()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            pm.DeletePart(1, conn);
            pm.DeletePart(2, conn);
            pm.DeletePart(3, conn);
            ArrayList a = pm.GetAllParts(conn);
            TearDown();
            Assert.AreEqual(a.Count, 0);
        }

        // Update part
        [TestMethod]
        public void TestUpdatePartOK()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            Part p = pm.GetPart(2, conn);
            p.price = 1000.50m;
            int rowsupdated = pm.UpdatePart(p, conn);
            Part pnew = pm.GetPart(2, conn);
            TearDown();
            Assert.AreEqual(rowsupdated, 1);
            Assert.AreEqual(pnew.price, 1000.50m);
        }

        // Update part that does not exist
        [TestMethod]
        public void TestUpdatePartFail()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            Part p = pm.GetPart(2, conn);
            p.partno = 4;
            int rowsupdated = pm.UpdatePart(p, conn);
            TearDown();
            Assert.AreEqual(rowsupdated, 0);
        }

        // Create part 
        [TestMethod]
        public void TestCreatePartOK()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            Part p = new Part(4, "PartD", 34.50m, 25);
            int rowsupdated = pm.InsertPart(p, conn);
            Part pnew = pm.GetPart(4, conn);
            TearDown();
            Assert.AreEqual(rowsupdated, 1);
            Assert.AreEqual(pnew.partname, "PartD");
        }

        // Create part which duplicate primary key
        [TestMethod]
        public void TestCreatePartFail()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            Part p = new Part(2, "PartD", 34.50m, 25);
            int rowsupdated = pm.InsertPart(p, conn);
            TearDown();
            Assert.AreEqual(rowsupdated, 0);
        }

        // Delete part 
        [TestMethod]
        public void TestDeletePartOK()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            int rowsupdated = pm.DeletePart(2, conn);
            Part p = pm.GetPart(2, conn);
            TearDown();
            Assert.AreEqual(rowsupdated, 1);
            Assert.AreEqual(p, null);
        }

        // Delete part that does not exist
        [TestMethod]
        public void TestDeletePartFail()
        {
            SetUpDB();
            PartMapper pm = new PartMapper();
            int rowsupdated = pm.DeletePart(4, conn);
            ArrayList a = pm.GetAllParts(conn);
            TearDown();
            Assert.AreEqual(rowsupdated, 0);
            Assert.AreEqual(a.Count, 3);
        }
    }
}
